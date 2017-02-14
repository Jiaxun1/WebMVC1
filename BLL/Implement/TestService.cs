using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface;
using DAL;
using DAL.Interface;

namespace BLL.Implement
{
    public class TestService : ITestService
    {
        private IPersonService personService;

        public TestService(IPersonService personService)
        {
            this.personService = personService;
        }

        public string GetName()
        {
            return "Tom";
        }

        public IList<Person> GetPersons()
        {
            return this.personService.GetPersons();
        }
    }
}
