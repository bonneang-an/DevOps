using Student.Dtos;
using Student.Entities;

namespace Student
{
    public static class Extensions
    {
        public static PersonDto AsDto(this Person x)
        {
            return new PersonDto{
                Id = x.Id,
                Name = x.Name,
                Gender = x.Gender,
                CreatedDate = x.CreatedDate
            };
        }
    }
    
}