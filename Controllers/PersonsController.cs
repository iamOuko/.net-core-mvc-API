using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/persons")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepo _repository;
        private readonly IMapper _mapper;

        public PersonsController(IPersonRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<PersonReadDto>> GetAllPersons()
        {
            var personItems = _repository.GetAllPersons();

            return Ok(_mapper.Map<IEnumerable<PersonReadDto>>(personItems));
        }

        [HttpGet("{id}", Name = "GetPersonById")]
        public ActionResult<PersonReadDto> GetPersonById(int id)
        {
            var personItem = _repository.GetPersonById(id);
            if (personItem != null)
            {
                return Ok(_mapper.Map<PersonReadDto>(personItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PersonReadDto> CreatePerson(PersonCreateDto personCreateDto)
        {
            var personModel = _mapper.Map<Person>(personCreateDto);
            _repository.CreatePerson(personModel);
            _repository.SaveChanges();

            var personReadDto = _mapper.Map<PersonReadDto>(personModel);

            return CreatedAtRoute(nameof(GetPersonById), new { Id = personReadDto.Id }, personReadDto);


        }

        [HttpPut("{id}")]
        public ActionResult UpdatePerson(int id, PersonUpdateDto personUpdateDto)
        {
            var personModelFromRepo = _repository.GetPersonById(id);
            if (personModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(personUpdateDto, personModelFromRepo);

            _repository.UpdatePerson(personModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialPersonUpdate(int id, JsonPatchDocument<PersonUpdateDto> patchDoc)
        {
            var personModelFromRepo = _repository.GetPersonById(id);
            if(personModelFromRepo == null)
            {
                return NotFound();
            }

            var personToPatch = _mapper.Map<PersonUpdateDto>(personModelFromRepo);
            patchDoc.ApplyTo(personToPatch, ModelState);
            if(!TryValidateModel(personToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(personToPatch, personModelFromRepo);

            _repository.UpdatePerson(personModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            var personModelFromRepo = _repository.GetPersonById(id);
            if (personModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeletePerson(personModelFromRepo);
            _repository.SaveChanges();

            return NoContent();

        }

       

    }
}
