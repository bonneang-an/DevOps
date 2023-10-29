using Student.Entities;

namespace Repositories
{
       public interface IPersonRepository
    {
        Task<Person?> GetPersonAsync(Guid id);
        Task<IEnumerable<Person>> GetPeopleAsync();
        Task InsertAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(Guid id);
    }
}
