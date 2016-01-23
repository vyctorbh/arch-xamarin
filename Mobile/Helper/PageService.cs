﻿using Definition.Interfaces;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace Mobile.Helper
{
    public class PageService : IPageService
    {

        private readonly IDictionary<Type, Type> _pagesByType = new Dictionary<Type, Type>();

        public Page Build(Type pageType, object parameter)
        {
            ConstructorInfo constructor = null;
            object[] parameters = null;

            if (parameter == null)
            {
                constructor = pageType.GetTypeInfo()
                    .DeclaredConstructors
                    .FirstOrDefault(c => !c.GetParameters().Any());

                parameters = new object[] { };
            }
            else
            {
                constructor = pageType.GetTypeInfo()
                    .DeclaredConstructors
                    .FirstOrDefault(
                        c =>
                        {
                            var p = c.GetParameters();
                            return p.Count() == 1
                                   && p[0].ParameterType == parameter.GetType();
                        });

                parameters = new[]
                            {
                                        parameter
                                    };
            }

            if (constructor == null)
                throw new InvalidOperationException(
                    "No suitable constructor found for page " + pageType.ToString());

            var page = constructor.Invoke(parameters) as Page;

            // Assign Binding Context
            if (_pagesByType.ContainsKey(pageType))
                page.BindingContext = ServiceLocator.Current.GetInstance<object>(_pagesByType[pageType].ToString());
            else
                throw new InvalidOperationException(
                    "No suitable view model found for page " + pageType.ToString());

            return page;
        }
               
        public void Map(Type pageType, Type viewModelType)
        {
            lock (_pagesByType)
            {
                if (_pagesByType.ContainsKey(pageType))
                {
                    _pagesByType[pageType] = viewModelType;
                }
                else
                {
                    _pagesByType.Add(pageType, viewModelType);
                }
            }
        }
    }
}
