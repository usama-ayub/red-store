using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopApi.Interfaces
{
    public interface IDataBaseSetting
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}