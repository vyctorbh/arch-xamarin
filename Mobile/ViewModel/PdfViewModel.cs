using Definition.Enums;
using Definition.Interfaces;
using Definition.Interfaces.Messenger;
using GalaSoft.MvvmLight.Command;
using Mobile.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.ViewModel
{
	public class PdfViewModel : BaseViewModel
	{
		private IDefaultMessenger _defaultMessenger = null;

		public PdfViewModel(IAppLoader appLoader, MainModel mainModel, IDefaultMessenger defaultMessenger) : base(defaultMessenger)
		{
			_defaultMessenger = defaultMessenger;
		}

		private string _title = "Default Message";
		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				_title = value;
				RaisePropertyChanged(() => Title);
			}
		}

		private string _data = "Default Message";
		public string Data
		{
			get
			{
				return _data;
			}
			set
			{
				_data = value;
				RaisePropertyChanged(() => Data);
			}
		}

		private string _content = "Default Message";
		public string Content
		{
			get
			{
				return MainModel.ItemNews.image;
			}
			set
			{
				_content = value;
				RaisePropertyChanged(() => Content);
			}
		}

		private UrlWebViewSource _contentHtml = new UrlWebViewSource();
		public UrlWebViewSource ContentHtml
		{
			get
			{
				return _contentHtml;
			}
			set
			{
				_contentHtml = value;
				RaisePropertyChanged(() => ContentHtml);
			}
		}

		public override void Subscribe()
		{
			_defaultMessenger.RegisterNotification(this, ReceiveNotification);
		}

		private void ReceiveNotification(string message)
		{
			if (message.Contains("Basic"))
				Message = message;
			else
			{
				_details.ID = Convert.ToInt32(message);
				this.Escreva();
			}
		}

		public void Escreva()
		{
			var detalhe = MainModel.ItemNews;
			this.Content = detalhe.image;
		}

		private void ReceiveNotification(DetailsModel message)
		{
			details = message;
		}

		private DetailsModel _details = new DetailsModel();
		public DetailsModel details
		{
			get
			{
				return _details;
			}
			set
			{
				_details = value;
				RaisePropertyChanged(() => details);
			}
		}

		private string _message = "Default Message";
		public string Message
		{
			get
			{
				return _message;
			}
			set
			{
				_message = value;
				RaisePropertyChanged(() => Message);
			}
		}
	}
}
