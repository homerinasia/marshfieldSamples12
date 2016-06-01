using System.ServiceModel;
using System.Collections.Generic;

namespace WcfJsonRestService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Person> getAllPersons();

        [OperationContract]
        IEnumerable<Person> getPersonById(string Id);
    }
}