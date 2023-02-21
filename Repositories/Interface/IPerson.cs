using Repositories.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IPerson
    {
        List<Person> GetAll();
        Person Add(Person p);
        Person Update(Person p, int id);

    }
}
