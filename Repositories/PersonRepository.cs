using System;
using System.Collections.Generic;
using Student.Entities;
namespace Repositories
{
 
    public class PersonRepsitory: IPersonRepository
    {
        private readonly List<Person> people = new()
        {
            new Person {Id = Guid.NewGuid(),Name = "Raksmey",Gender = "M",CreatedDate = DateTimeOffset.UtcNow},
            new Person {Id = Guid.NewGuid(),Name = "Raksmy",Gender = "F",CreatedDate = DateTimeOffset.UtcNow},
        };

       

        public async Task<IEnumerable<Person>> GetPeopleAsync()
        {
            return await Task.FromResult(people);
        }

        public async Task<Person?> GetPersonAsync(Guid id)
        {
            Person? person = people.Where(x=> x.Id == id).FirstOrDefault(); 
                if(person is not null){
                    return await Task.FromResult(person);
                }

            return null;

        }

        public async Task InsertAsync(Person person)
        {
             people.Add(person);
             await Task.CompletedTask;
        }

        public async Task UpdateAsync(Person person)
        {
           var index = people.FindIndex(e => e.Id == person.Id);
           people[index] = person;
           await Task.CompletedTask;
        }
         public async Task DeleteAsync(Guid id)
        {
             var index = people.FindIndex(e => e.Id == id);
             people.RemoveAt(index);
             await Task.CompletedTask;
        }
    }
    
}