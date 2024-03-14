using ApplicationCore.DTO;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Services
{
    public interface IPersonService
    {
        Task<Guid> Add(PersonPostDto personDto);

        Task<List<PersonGetDto>> GetAll();

    }
}
