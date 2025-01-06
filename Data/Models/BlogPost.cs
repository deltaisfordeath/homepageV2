using System.ComponentModel.DataAnnotations;
using homepageV2.Data.Models.Generic;
using Microsoft.EntityFrameworkCore;

namespace HomepageV2.Data.Models;

[Index(nameof(BlogPost.Url), IsUnique = true)]

public class BlogPost: PaginatedObject
{
    public string Body { get; private set; }
    [Required]
    public string Url { get; private set; }
}