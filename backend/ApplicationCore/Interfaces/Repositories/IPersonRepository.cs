using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Task<Guid> AddPerson(Person person);
        Task<List<Person>> GetAllPersonsAsync();
        Task UpdatePerson(Person person);
    }
}
