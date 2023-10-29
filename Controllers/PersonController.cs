using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Student.Dtos;
using Student.Entities;
using Repositories;
using System.Runtime.CompilerServices;

namespace Student.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PersonController: ControllerBase
    {
        private readonly IPersonRepository _Repository;
        public PersonController(IPersonRepository repository)
        {
            _Repository = repository ;
        }
        [HttpGet]
        public async Task<IEnumerable<PersonDto>> GetPeopleAsync()
        {
            var result = (await _Repository.GetPeopleAsync()).Select(x => x.AsDto());
            return result;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> GetPersonAsync(Guid id)
        {
            var result = await _Repository.GetPersonAsync(id);
            if (result is null)
            {
                return NotFound();
            }

            return result.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> CreatePersonAsync(InsertPersonDto model)
        {
            Person person =  new(){
                Id = Guid.NewGuid(),
                Name = model.Name,
                Gender = model.Gender,
                CreatedDate =  DateTimeOffset.UtcNow
            };

            await _Repository.InsertAsync(person);

            return CreatedAtAction(nameof(GetPersonAsync), new {id= person.Id}, person.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePersonAsync(Guid id,UpdatePersonDto personDto)
        {
            var existingPerson = await _Repository.GetPersonAsync(id);

            if(existingPerson is null)
            {
                return NotFound();
            }

            Person updatePerson = existingPerson with 
            {
                Name = personDto.Name,
                Gender = personDto.Gender
            };

            await _Repository.UpdateAsync(updatePerson);

            return NoContent();
        }

         [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePersonAsync(Guid id)
        {
            var existingPerson = await _Repository.GetPersonAsync(id);
            if(existingPerson is null)
            {
                    return NotFound();
            }
            await _Repository.DeleteAsync(existingPerson.Id);

            return NoContent();
        }
      
    }
}