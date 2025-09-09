namespace homepageV2.Data.Models.Generic;

public abstract class PaginatedObject
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
}