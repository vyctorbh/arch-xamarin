using ApiRepository.Repository;
using Definition.Interfaces.Repository;
using Definition.Interfaces.Service;
using Definition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    /// <summary>
    /// Will be used to authenticate with the API. This example uses REST and JWT
    /// </summary>
    public class AddressService : IAddressService
    {
        IAuthenticationRepository _authenticationRepository;
        IAddressRepository _addressrepository;

        public string numberpage { get; set; }
        public string skippage { get; set; }

        public AddressService(IAddressRepository addressrepository)
        {
            _addressrepository = addressrepository;
        }

        public async Task<AddressReturn> Search(string search, string latitude, string longitude)
        {
            AddressReturn ret = new AddressReturn();
            ((AddressRepository)_addressrepository).numberpage = this.numberpage;
            ((AddressRepository)_addressrepository).skippage = this.skippage;

            var result = await _addressrepository.Search(search, latitude, longitude);
            ret.listaddress = result.Values;
            return ret;
        }

    }
}
