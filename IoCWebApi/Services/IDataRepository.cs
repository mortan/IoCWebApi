using System.Collections;
using System.Collections.Generic;

namespace IoCWebApi.Services
{
    public interface IDataRepository
    {
        void Authenticate();

        IEnumerable<string> GetAllPersons();
    }
}