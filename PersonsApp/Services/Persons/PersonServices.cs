using Microsoft.EntityFrameworkCore;
using PersonsApp.Constans;
using PersonsApp.DataBase;
using PersonsApp.Dtos.Common;
using PersonsApp.Dtos.Countries;
using PersonsApp.Dtos.Persons;
using PersonsApp.Entites;
using PersonsApp.Mappers;

namespace PersonsApp.Services.Persons
{
    public class PersonServices : IPersonService
    {
        private readonly PersonsDbContext _context;
        private readonly int PAGE_SIZE;
        private readonly int PAGE_SIZE_LIMIT;
        public PersonServices(PersonsDbContext context, IConfiguration configuratioin)
        {
            _context = context;
            PAGE_SIZE = configuratioin.GetValue<int>("PageSize");
            PAGE_SIZE_LIMIT = configuratioin.GetValue<int>("PageSizeLimit");
        }

        public async Task<ResponseDto<PageDto<List<PersonDto>>>> GetPageAsync(string searchTerm = "", int page = 1, int pageSize = 10)
        {

            page = Math.Abs(page);
            pageSize = Math.Abs(pageSize);
            pageSize = pageSize <= 0 ? PAGE_SIZE : pageSize;
            pageSize = pageSize > PAGE_SIZE_LIMIT ? PAGE_SIZE_LIMIT : pageSize;

            int startIndex = (page - 1) * pageSize;

            IQueryable<PersonEntity> personsQuery = _context.Persons.Include(p => p.Country);

            if(!string.IsNullOrEmpty(searchTerm))
            {
                personsQuery = personsQuery.Where( x => (x.DNI + " " + x.FirstName + " " + x.LastName).Contains(searchTerm));
            }

            int totalRows = await personsQuery.CountAsync();

            var personsEntity = await personsQuery
            .OrderBy(x => x.FirstName)
            .Skip(startIndex)
            .Take(pageSize)
            .ToListAsync();

            var personsDto = PersonMapper.ListEntityToListDto(personsEntity);

            return new ResponseDto<PageDto<List<PersonDto>>>
            {
                StatusCode = HttpStatusCode.OK,
                Status = true,
                Message = HttpMessageResponse.REGISTERS_FOUND,
                Data = new PageDto<List<PersonDto>>
                {
                    CurrentPage = page == 0 ? 1 : page,
                    PageSize = pageSize,
                    TotalItems = totalRows,
                    TotalPages = (int)Math.Ceiling((double)totalRows/pageSize),
                    Items = personsDto,
                    HasNextPage = startIndex + pageSize <PAGE_SIZE_LIMIT && 
                        page < (int)Math.Ceiling((double)totalRows/pageSize), 
                        HasPreviousPage = page > 1
                }
            };
        }

        public async Task<ResponseDto<PersonDto>> GetOneByIdAsync(string id)
        {
            var personEntity = await _context.Persons
            .Include(p => p.Country)
            .FirstOrDefaultAsync(p => p.Id == id);

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
                Status = true,
                Data  = new PersonDto
                {
                    Id = personEntity.Id,
                    DNI = personEntity.DNI,
                    FirstName = personEntity.FirstName,
                    LastName = personEntity.LastName,
                    BirthDate = personEntity.BirthDate,
                    Gender = personEntity.Gender,
                    Country = new CountryOneDto
                    {
                        Id = personEntity.CountryId,
                        Name = personEntity.Country.Name
                    }
                }
            };
        }
    
        public async Task<ResponseDto<PersonActionResponseDto>> CreateAsync(PersonCreateDto dto)
        {
            PersonEntity personEntity = PersonMapper.CreateDtoToEntity(dto);

            _context.Persons.Add(personEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<PersonActionResponseDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = HttpMessageResponse.REGISTER_CREATED,
                Status = true,
                Data = new PersonActionResponseDto
                {
                    Id = personEntity.Id
                }
            };
        }

        public async Task<ResponseDto<PersonActionResponseDto>> EditAsync(string id, PersonEditDto dto)
        {
            var personEntity = await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);

            if(personEntity is null)
            {
                return new ResponseDto<PersonActionResponseDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = HttpMessageResponse.REGISTER_NOT_FOUND,
                };
            }

            var personEntityUpdated = PersonMapper.EditDtoToEntity(personEntity, dto);

            _context.Persons.Update(personEntityUpdated);

            await _context.SaveChangesAsync();

            return new ResponseDto<PersonActionResponseDto>
            {
                StatusCode = HttpStatusCode.OK,
                Status = true,
                Message = HttpMessageResponse.REGISTER_UPDATED,
                Data = new PersonActionResponseDto
                {
                    Id = id
                }
            };
        }

        public async Task<ResponseDto<PersonActionResponseDto>> DeleteAsync(string id)
        {
            var personEntity = await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);

            if(personEntity is null)
            {
                return new ResponseDto<PersonActionResponseDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = HttpMessageResponse.REGISTER_NOT_FOUND,
                };
            }

            _context.Persons.Remove(personEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<PersonActionResponseDto>
            {
                StatusCode = HttpStatusCode.OK,
                Status = true,
                Message = HttpMessageResponse.REGISTER_DELETED,
                Data = new PersonActionResponseDto
                {
                    Id = id
                }
            };
        }
    }
}
