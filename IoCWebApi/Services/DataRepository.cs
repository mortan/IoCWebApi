using System.Collections;
using System.Collections.Generic;

namespace IoCWebApi.Services
{
    class DataRepository : IDataRepository
    {
        public void Authenticate()
        {
            // Do Stuff
        }

        public IEnumerable<string> GetAllPersons()
        {
            // TODO: Hier würde man an die Datenbank gehen
            return new List<string> { "John", "Derp" };
        }
    }
}