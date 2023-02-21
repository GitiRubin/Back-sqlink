using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IPersonService
    {
        List<PersonDTO> GetAll();
        Task<PersonDTO> Add(PersonDTO p);
        PersonDTO Update(PersonDTO p, int id);
        ListsOfPeople GetLists();
         
    }
}
