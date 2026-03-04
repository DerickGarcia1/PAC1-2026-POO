using Microsoft.EntityFrameworkCore;
using PersonsApp.Constans;
using PersonsApp.DataBase;
using PersonsApp.Dtos.Common;
using PersonsApp.Dtos.Persons;

namespace PersonsApp.Services.Persons
{
    public class PersonServices : IPersonService
    {
        private readonly PersonsDbContext _context;

        public PersonServices(PersonsDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<PersonDto>> GetOneByIdAsync(Guid id)
        {
            var personEntity = await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);

            if (personEntity is null)
            {
                return new ResponseDto<PersonDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Message = HttpMessageResponse.REGISTER_NOT_FOUND,
                    Status = false,
                };
            }

            return new ResponseDto<PersonDto>
            {
                StatusCode  = HttpStatusCode.OK,
                Message = HttpMessageResponse.REGISTER_FOUND,
                Data  = new PersonDto
                {
                    Id = personEntity.Id,
                    DNI = personEntity.DNI,
                    FirstName = personEntity.FirstName,
                    LastName = personEntity.LastName,
                    BirthDate = personEntity.BirthDate,
                    Gender = personEntity.Gender
                }
            };
        }
    }
}