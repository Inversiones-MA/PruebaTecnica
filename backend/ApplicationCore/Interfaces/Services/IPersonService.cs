using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Services
{
    public interface IPersonService
    {
        Task<Guid> Add(Person person);

        Task<List<Person>> GetAll();

    }
}
