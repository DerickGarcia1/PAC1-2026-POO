using Microsoft.AspNetCore.Mvc;
using PersonsApp.Entites;
using PersonsApp.Services.Persons;


namespace PersonsApp.controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly List<PersonEntity> _persons;
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;

            _persons = new List<PersonEntity>
            {
                new PersonEntity
                {
                    DNI = "1411200100485",
                FirstName = "Derick",
                LastName = "Garcia",
                Gender = "Masculino",
                BirthDate = DateTime.Parse("02/04/2001")
                },

                new PersonEntity
                {
                    DNI = "1411200100486",
                FirstName = "Maria",
                LastName = "Jose",
                Gender = "femenino",
                BirthDate = DateTime.Parse("15/03/2001")
                },

                new PersonEntity
                {
                    DNI = "1411200100487",
                FirstName = "carlos",
                LastName = "peña",
                Gender = "masculino",
                BirthDate = DateTime.Parse("27/08/2001")
                }
            };
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_persons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOne(Guid id)
        {
            var result = await _personService.GetOneByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        

        [HttpPost]
        public ActionResult Create(PersonEntity person)
        {
            var personExist = _persons.Any(p => p.DNI == person.DNI);

            if (!personExist)
            {
                _persons.Add(person); 
                return Created(); 
            }

            //Console.WriteLine(person.DNI);
            return BadRequest(new {Message = "el DNI ya esta registrado"});
            
        }

        [HttpPut("{dni}")]
        public IActionResult Update(string dni, PersonEntity person)
        {
            var oldperson = _persons.FirstOrDefault(p => p.DNI == dni);

            if (oldperson is null)
            {
                return NotFound(new {Message = "Persona no encontrada."});
            }

            _persons.Remove(oldperson);
            _persons.Add(person);

            Console.WriteLine($"Persona actualizadas: {person.DNI} - {person.FirstName} {person.LastName}");
            
            return Ok(new {Message = "Registro editado exitosamente"});
        }

        [HttpDelete("{dni}")]
            public IActionResult Delete(string dni)
            {
                var person = _persons.FirstOrDefault(p => p.DNI == dni);

                if (person is null)
                {
                    return NotFound(new { message = "Persona no encontrada" });
                }

                _persons.Remove(person);
                Console.WriteLine($"Persona Eliminada: {person.DNI} - {person.FirstName} {person.LastName}");
                return Ok(new { message = "Persona eliminada correctamente" });
            }
    }
}