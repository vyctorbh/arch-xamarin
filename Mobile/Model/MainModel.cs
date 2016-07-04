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
        public string nome { get; set; }
        public string address { get; set; }
        public int qtdrows { get; set; }
        public string cidade { get; set; }
        public bool IsLoading { get; set; }

        public ObservableCollection<MainModel> Items
        {
            get;
            set;
        }

        public MainModel()
        {
            this._addressservice = null;
        }

        public MainModel(IAddressService addressservice)
        {
            this._addressservice = addressservice;
        }

        public async Task List(string search, string latitude, string longitude, string numberpage, string skippage)
        {
            /*this.IsLoading = true;
            if (String.IsNullOrEmpty(search))
            {
                search = "Belo Horizonte";
            }

            ((AddressService)_addressservice).numberpage = numberpage;
            ((AddressService)_addressservice).skippage = skippage;

            var items = await this._addressservice.Search(search, latitude, longitude);

            this.Items = new ObservableCollection<MainModel>();
            //if(listaddress != null)
            //    this.Items.Add(new MainModel() { nome = listaddress.address, id = 1 });

            int i = 1;

            foreach (var item in items.listaddress)
            {
                this.Items.Add(new MainModel() { address = item.address, nome = item.description, cidade = item.cidade.nome, id = item.id, qtdrows = Convert.ToInt32(item.qtdrows) });
                i++;
            }
            Task.Delay(1000);
            this.IsLoading = false;*/
        }
    }
}
