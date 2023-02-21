using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ListsOfPeople
    {
        public List<CorrectPerson> CorrectIdPeople { get; set; }=new List<CorrectPerson>();
        public List<IncorrectPerson> IncorrectIdPeople { get; set; }=new List<IncorrectPerson>();

    }
}
