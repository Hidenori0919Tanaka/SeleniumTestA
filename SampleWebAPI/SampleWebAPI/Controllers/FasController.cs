using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleWebAPI.Controllers
{
    public class FasController : ApiController
    {
        // GET: api/Fas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Fas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Fas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Fas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Fas/5
        public void Delete(int id)
        {
        }
    }
}
