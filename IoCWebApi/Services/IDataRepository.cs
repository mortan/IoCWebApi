using System.Collections.Generic;

namespace IoCWebApi.Services
{
    public interface IDataRepository
    {
        IEnumerable<string> GetAllPersons();
    }
}