
using ApplicationCore.DTO;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using AutoMapper;


namespace ApplicationCore.Services
{
    public class PersonService : IPersonService
    {
        IPersonRepository _personRepository;
        IMapper _mapper;
        public PersonService(
            IPersonRepository personRepository,
            IMapper mapper
        )
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Add(PersonPostDto personDto)
        {
            Person person = _mapper.Map<Person>(personDto);

            person.Id = Guid.NewGuid();

            var personId = await _personRepository.AddPerson(person);

            return personId;
        }

        public async Task<List<PersonGetDto>> GetAll()
        {
            var persons = await _personRepository.GetAllPersonsAsync();

            List<PersonGetDto> result = persons.Select(e => _mapper.Map<PersonGetDto>(e)).ToList();

            return result;
        }

        public async Task Update(PersonPutDto personDto)
        {

            Person person = _mapper.Map<Person>(personDto);

            await _personRepository.UpdatePerson(person);
        }

        

    }
}
