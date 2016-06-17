using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using IoCWebApi.Services;
using Serilog;

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
            var allPersons = repository.GetAllPersons().ToList();

            Log.Debug("Loaded persons: {@Persons}", allPersons);

            return allPersons;
        }
    }
}
