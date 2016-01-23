﻿using Definition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definition.Interfaces.Repository
{
    public interface IAddressRepository
    {
        Task<Result<Address>> Search(string search, string latitude, string longitude);
    }
}
