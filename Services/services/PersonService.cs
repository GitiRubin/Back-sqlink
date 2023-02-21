using Common;
using Newtonsoft.Json;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service.services
{
    public class PersonService : IPersonService
    {
        private  List<PersonDTO> people=new List<PersonDTO>();
        private  ListsOfPeople listsOfPeople=new ListsOfPeople();
        static HttpClient client = new HttpClient();

        public async Task<PersonDTO> Add(PersonDTO p)
        {

            people.Add(p);
            if (p.Id.ToString().Length == 9 && p.Id.ToString().All(c => c >= '0' && c <= '9'))
                listsOfPeople.CorrectIdPeople.Add(await GetCorrectWithID(p));
            else listsOfPeople.IncorrectIdPeople.Add(new IncorrectPerson { Age = p.Age, FullName = p.FirstName + " " + p.LastName, IdPerson = p.Id });
            return p;
        }
        public ListsOfPeople GetLists()
        {
            
            return listsOfPeople;
        }

        public List<PersonDTO> GetAll()
        {
            return people;
        }

        public PersonDTO Update(PersonDTO p, int id)
        {
            PersonDTO updatePerson = people.Single(p => p.Id == id);
            updatePerson = p;
            return p;
        }

        

        static public async Task<CorrectPerson> GetCorrectWithID(PersonDTO person)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://api-sq.azurewebsites.net/People", person);
            //response.EnsureSuccessStatusCode();

            var p= await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CorrectPerson>(p);
        }
    }
}
