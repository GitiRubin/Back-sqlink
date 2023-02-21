using Repositories.Entitiy;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.repository
{
    internal class PersonRepository : IPerson
    {
        private readonly List<Person> people;
        public PersonRepository(List<Person> people)
        {
            this.people = people;
        }
    
        public Person Add(Person p)
        {
            people.Add(p);
            return p;
        }

        public List<Person> GetAll()
        {
            return people;
        }

        public Person Update(Person p, int id)
        {
            Person updatePerson = people.Single(p => p.Id == id);
            updatePerson = p;
            return updatePerson;
        }
    }
}
