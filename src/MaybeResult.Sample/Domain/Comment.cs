namespace MaybeResult.Sample.Domain;

public class Comment
{
    protected Comment(CommentId id, Person person, Markup content, DateTime dateTimeCreated, DateTime dateTimeUpdated)
    {
        Id = id;
        Person = person;
        Content = content;
        DateTimeCreated = dateTimeCreated;
        DateTimeUpdated = dateTimeUpdated;
    }

    public CommentId Id { get; protected init; }
    public Person Person { get; protected set; }
    public Markup Content { get; protected set; }
    public DateTime DateTimeCreated { get; protected init; }
    public DateTime DateTimeUpdated { get; protected set; }

    public static Result<Comment> Create(Person person, Markup content)
    {
        var currentDateTime = DateTime.UtcNow;
        // The instance method to map one result
        return Result.Map(CommentId.Create(), id => new Comment(id, person, content, currentDateTime, currentDateTime));
    }

    public override string ToString()
    {
        return $"{{ CommentId: {Id.Value}, Person: '{Person.FirstName} {Person.LastName}', Content: '{Content.Value}', DateTimeCreated: {DateTimeCreated}, DateTimeUpdated: {DateTimeUpdated}}}";
    }
}
