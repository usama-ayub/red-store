using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopApi.Interfaces
{
    public interface ICloudinarySetting
    {
        string CloudName { get; set; }

        string APIKey { get; set; }
        string APISecret { get; set; }
    }
}