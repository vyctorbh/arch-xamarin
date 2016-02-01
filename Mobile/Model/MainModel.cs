using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Definition.Interfaces;
using Definition.Interfaces.Service;
using DataService;

namespace Mobile.Model
{
    public class MainModel : BaseModel
    {
        IAddressService _addressservice;

        public int id { get; set; }
        public string link { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public string image { get; set; }
        public string content { get; set; }
        public bool IsLoading { get; set; }

        public ObservableCollection<MainModel> Items
        {
            get;
            set;
        }

        public static MainModel ItemNews { get; set; }

        public MainModel()
        {
            this._addressservice = null;
        }

        public MainModel(IAddressService addressservice)
        {
            this._addressservice = addressservice;
        }

        public async Task List(string search, string latitude, string longitude, string numberpage, string skippage, string token)
        {
            this.IsLoading = true;
            latitude = token;

            ((AddressService)_addressservice).numberpage = numberpage;
            ((AddressService)_addressservice).skippage = skippage;

            var items = await this._addressservice.Search(search, latitude, longitude);

            this.Items = new ObservableCollection<MainModel>();
            //f(listaddress != null)
            //    this.Items.Add(new MainModel() { nome = listaddress.address, id = 1 });

            int i = 1;

            foreach (var item in items.listaddress)
            {
                this.Items.Add(new MainModel() { title = item.title, link = item.link, id = item.ID, date = item.date, image = item.image.guid, content = item.content });
                i++;
            }
            //Task.Delay(1000);
            this.IsLoading = false;
        }
    }
}
