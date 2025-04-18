using Qiro.Client.Features.Blogs.DTOs;
using System.Net.Http.Json;

namespace Qiro.Client.Features.Blogs.Services;

public class BlogService(HttpClient httpClient)
{
    const string blogLocation = "blogging/";
    List<BlogMetadataDto>? cache = null;

    public async Task<List<BlogMetadataDto>> GetAllBlogsAsync()
    {
        if (cache != null)
            return cache;

        var result = await httpClient.GetFromJsonAsync<List<BlogMetadataDto>>(Path.Combine(blogLocation, "blogs.json"));

        cache = result ?? [];

        return cache;
    }

    public async Task<BlogMetadataDto?> GetBlogMetadataByIdAsync(Guid id)
    {
        var blogs = await GetAllBlogsAsync();
        return blogs.FirstOrDefault(b => b.Id == id);
    }

    public async Task<BlogPostDto?> GetBlogPostByIdAsync(Guid id)
    {
        var metadata = await GetBlogMetadataByIdAsync(id);

        if (metadata == null) return null;

        try
        {
            var content = await httpClient.GetStringAsync(Path.Combine(blogLocation, metadata.Location));
            return new BlogPostDto(content, metadata);
        }
        catch
        {
            return null;
        }
    }
}
