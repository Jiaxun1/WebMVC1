using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using PetaPoco;

namespace DAL.Implement
{
    public class PersonService : IPersonService
    {
        public IList<Person> GetPersons()
        {
            var db = new Database("conn");
            return db.Fetch<Person>("select * from person;");
        }
    }
}
