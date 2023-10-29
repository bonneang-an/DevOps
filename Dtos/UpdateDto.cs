using System.ComponentModel.DataAnnotations;

namespace Student.Dtos
{
    public record UpdatePersonDto
    {
            [Required]
            public required string Name { get; init; }
            [Required]
            public required string Gender  {get;init;} 
            public DateTimeOffset CreatedDate {get; init;}
    }
}