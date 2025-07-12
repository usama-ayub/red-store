using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopApi.Interfaces;

namespace eShopApi.Shared
{
    public class DataBaseSetting : IDataBaseSetting
    {
        public required string ConnectionString { get; set; }
        public required string DatabaseName { get; set; }
    }
}