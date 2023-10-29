namespace Student.Entities
{
    public record Person
    {
            public Guid Id {get;init;}
            public required string Name { get; init; }
            public required string Gender  {get;init;} 
            public DateTimeOffset CreatedDate {get; init;}
    }
}