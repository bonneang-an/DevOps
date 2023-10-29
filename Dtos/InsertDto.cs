using System.ComponentModel.DataAnnotations;

namespace Student.Dtos
{
    public record InsertPersonDto
    {
            [Required]
            public required string Name { get; init; }
            [Required]
            public required string Gender  {get;init;} 
            public DateTimeOffset CreatedDate {get; init;}
    }
}