using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeesApi.Services
{
    public class RedisPricingLookup : ILookupPricing
    {
        private readonly IDistributedCache _cache;

        public RedisPricingLookup(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<int> GetPricingAsync()
        {
            Byte[] cachedData;
            try
            {
                cachedData = await _cache.GetAsync("pricing");
            } 
            catch (Exception ex)
            {
                throw ex;
            }
            if (cachedData != null)
            {
                var storedResp = Encoding.UTF8.GetString(cachedData);
                var pricingInfo = JsonSerializer.Deserialize<PricingInfo>(storedResp);
                return pricingInfo.price;
            }
            else
            {
                return -42;
            }
        }
    }

    public class PricingInfo
    {
        public int price { get; set; }
    }
}
