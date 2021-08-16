using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace JokeMachine
{
    public class Authorization
    {
        private readonly IConfiguration _config;

        public Authorization(IConfiguration config)
        {
            _config = config;
        }
        public bool IsAuthorized(string apiKey)
        {
            var key = _config.GetValue<string>("Api-Key");
            return apiKey == key;
        }
    }
}
