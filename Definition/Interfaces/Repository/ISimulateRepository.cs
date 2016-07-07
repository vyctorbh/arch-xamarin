using Definition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definition.Interfaces.Repository
{
    public interface ISimulateRepository
    {
		Task<Result<Simulate>> Get(int id);
    }
}
