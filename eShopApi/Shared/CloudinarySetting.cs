using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopApi.Interfaces;

namespace eShopApi.Shared
{
    public class CloudinarySetting : ICloudinarySetting
    {
        public string CloudName { get; set; }
        public string APIKey { get; set; }
        public string APISecret { get; set; }
    }
}