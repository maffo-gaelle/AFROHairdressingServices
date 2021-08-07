﻿using HairdressingServices.Api.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.Api.Models.Global.Repositories
{
    public interface ILocalityRepository
    {
        void Add(Locality locality);
        void Update(Locality locality);
        void Delete(string codePostal);
        Locality Get(string codePostal);
        IEnumerable<Locality> Get();
        bool ExistsLocality(Locality locality);
    }
}
