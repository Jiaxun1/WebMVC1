using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Interface
{
    public interface ITestService
    {
        string GetName();

        IList<Person> GetPersons();
    }
}
