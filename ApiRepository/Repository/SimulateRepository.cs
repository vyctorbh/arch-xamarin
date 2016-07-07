using Definition.Interfaces.Repository;
using Definition.Model;
using RestSharp.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Definition;

namespace ApiRepository.Repository
{
	public class SimulateRepository : BaseRepository, ISimulateRepository
	{
		public SimulateRepository(string baseUrl)
		{
			_client.DefaultRequestHeaders
							  .Accept
							  .Add(new MediaTypeWithQualityHeaderValue("application/json"));

			_client.BaseAddress = new Uri(baseUrl);
		}

		public new Task<Result<Simulate>> Get(int id)
		{
			throw new NotImplementedException();
		}
	}
}
