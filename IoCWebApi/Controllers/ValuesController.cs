using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IoCWebApi.Services;

namespace IoCWebApi.Controllers
{
    [AllowAnonymous]
    public class ValuesController : ApiController
    {
        private readonly IDataRepository repository;

        public ValuesController(IDataRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            repository.Authenticate();

            return repository.GetAllPersons();
        }
    }
}
