using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizatChallengeServer
{
    public class BaseController : ControllerBase
    {
        private readonly JsonSerializerSettings _jsonSettings;

        public BaseController()
        {
            _jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DefaultValueHandling = DefaultValueHandling.Include,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        protected ObjectResult OkJson(object value)
        {
            try
            {
                var json = JsonConvert.SerializeObject(value, _jsonSettings);
                return Ok(json);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
