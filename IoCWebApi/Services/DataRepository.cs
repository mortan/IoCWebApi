using System.Collections.Generic;

namespace IoCWebApi.Services
{
    class DataRepository : IDataRepository
    {
        public IEnumerable<string> GetAllPersons()
        {
            return new List<string> { "John", "Derp" };
        }
    }
}