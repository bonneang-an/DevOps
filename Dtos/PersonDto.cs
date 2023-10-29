namespace Student.Dtos
{
    public record PersonDto
    {
            public Guid Id {get;init;}
            public required string Name { get; init; }
            public required string Gender  {get;init;} 
            public DateTimeOffset CreatedDate {get; init;}
    }
}