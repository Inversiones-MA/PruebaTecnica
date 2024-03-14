
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;


namespace ApplicationCore.Services
{
    public class PersonService : IPersonService
    {
        IPersonRepository _personRepository;

        public PersonService(
            IPersonRepository personRepository
        )
        {
            _personRepository = personRepository;
        }

        public async Task<Guid> Add(Person person)
        {
            var personId = await _personRepository.AddPerson(person);

            return personId;
        }

        public async Task<List<Person>> GetAll()
        {
            var persons = await _personRepository.GetAllPersonsAsync();

            return persons;
        }

        
    }
}
