﻿using ApiRepository.Repository;
using Common;
using DataService;
using Definition.Enums;
using Definition.Interfaces;
using Definition.Interfaces.Messenger;
using Definition.Interfaces.Repository;
using Definition.Interfaces.Service;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Mobile.Messenger;
using Mobile.Model;
using Mobile.Stack;
using Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile
{
    public class AppLoader : IAppLoader
    {
        private static AsyncLock _lock = new AsyncLock();
        private IDictionary<StackEnum, IStack> _stacks = null;
        private StackEnum? _currentStack = null;

        public AppLoader()
        {

            // Sequence is important here

            // Load Navigation Stacks
            InitializeStacks();

            // Load Repositories
            InitializeRepositories();

            // Load Data Services
            InitializeDataServices();

            // Load Messengers
            InitializeMessengers();

            // Load Models
            InitializeModels();
            
        }

        /// <summary>
        /// Loads all the navigation stacks
        /// </summary>
        private void InitializeStacks()
        {
            _stacks = new Dictionary<StackEnum, IStack>();
            _stacks.Add(StackEnum.Authentication, new AuthenticationStack());
            _stacks.Add(StackEnum.Main, new MainStack(this));
        }
        
        private void InitializeRepositories()
        {
            SimpleIoc.Default.Register<IAuthenticationRepository>(() => new AuthenticationRepository(Config.BaseLoginUrl, Config.client_id, Config.secret_id));
            SimpleIoc.Default.Register<IExampleRepository>(() => new ExampleRepository(Config.BaseUrl, "examples"));
            SimpleIoc.Default.Register<IAddressRepository>(() => new AddressRepository(Config.BaseUrl));
			SimpleIoc.Default.Register<ISimulateRepository>(() => new SimulateRepository(Config.BaseUrl));
        }

        private void InitializeDataServices()
        {
            SimpleIoc.Default.Register<IAuthenticationService>(() => new AuthenticationService(ServiceLocator.Current.GetInstance<IAuthenticationRepository>()));
            SimpleIoc.Default.Register<IExampleService>(() => new ExampleService(ServiceLocator.Current.GetInstance<IExampleRepository>()));
            SimpleIoc.Default.Register<IAddressService>(() => new AddressService(ServiceLocator.Current.GetInstance<IAddressRepository>()));
			SimpleIoc.Default.Register<ISimulateService>(() => new SimulateService(ServiceLocator.Current.GetInstance<ISimulateRepository>()));
        }
        
        private void InitializeMessengers()
        {
            SimpleIoc.Default.Register<IDefaultMessenger>(() => new DefaultMessenger());
            DependencyService.Register<Mobile.ViewModel.Service.IMessageService, Mobile.View.Service.MessageService>();
        }

        private void InitializeModels()
        {
            SimpleIoc.Default.Register(() => new LoginModel(ServiceLocator.Current.GetInstance<IAuthenticationService>()));
            SimpleIoc.Default.Register(() => new MainModel(ServiceLocator.Current.GetInstance<IAddressService>()));
        }
      

        /// <summary>
        /// Automatically create an instance of and register any ViewModel found in the namespace
        /// Mobile.ViewModel
        /// </summary>
        public void InitializeViewModels()
        {
            string @namespace = "Mobile.ViewModel";

            var query = from t in typeof(App).GetTypeInfo().Assembly.DefinedTypes
                        where t.IsClass && !t.IsSealed && t.Namespace == @namespace && t.Name != "BaseViewModel"
                        select t;

            foreach (var t in query.ToList())
            {
                var defaultConstructor = t.DeclaredConstructors.First();

                object instance = null;

                if (defaultConstructor.GetParameters().Count() == 0)
                   instance = (BaseViewModel)Activator.CreateInstance(t.AsType());
                else
                {
                    List<object> parameters = new List<object>();
                    foreach (var p in defaultConstructor.GetParameters())
                    {
                        parameters.Add(ServiceLocator.Current.GetInstance(p.ParameterType));
                    }

                    instance = (BaseViewModel)Activator.CreateInstance(t.AsType(), parameters.ToArray());
                }

                // Subscribe to all messenger events
                ((BaseViewModel)instance).Subscribe();

                SimpleIoc.Default.Register(() => instance, t.ToString());
            }

        }


        /// <summary>
        /// Changes the MainPage of the mobile app to the chosen stack
        /// </summary>
        /// <param name="stack"></param>
        public async Task LoadStack(StackEnum stack)
        {
            using (var releaser = await _lock.LockAsync())
            {
                if (stack == _currentStack)
                    return;

                // Unregister all current services
                UnRegisterServices();

                var stackInstance = _stacks[stack];

                // Register Services
                await stackInstance.RegisterServices();

                // Change MainPage
                App.Current.MainPage = stackInstance.MainPage;

                _currentStack = stack;
            }
        }

        /// <summary>
        /// Unregisters all services registered within this class
        /// </summary>
        private void UnRegisterServices()
        {
            SimpleIoc.Default.Unregister<IExtNavigationService>();
            SimpleIoc.Default.Unregister<IDialogService>();
        }
    }
}
