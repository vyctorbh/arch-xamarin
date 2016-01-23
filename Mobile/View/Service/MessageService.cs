using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.View.Service
{
    public class MessageService : Mobile.ViewModel.Service.IMessageService
    {
        #region IMessageService implementation

        public async System.Threading.Tasks.Task ShowAsync(string message)
        {
            await Mobile.App.Current.MainPage.DisplayAlert("Atenção", message, "ok");
        }

        #endregion

        public MessageService()
        {
        }
    }
}
