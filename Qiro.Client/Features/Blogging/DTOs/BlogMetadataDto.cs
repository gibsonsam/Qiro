namespace Qiro.Client.Features.Blogs.DTOs;

public class BlogMetadataDto
{
    public required Guid Id { get; set; }
    public required string Author { get; set; }
    public required DateTime PublishedOn { get; set; }
    public required string Title { get; set; }
    public required string Location { get; set; }
}
