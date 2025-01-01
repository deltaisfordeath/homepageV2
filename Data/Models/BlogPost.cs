using System.ComponentModel.DataAnnotations;

namespace HomepageV2.Data.Models;

public class BlogPost
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    [MaxLength(255)]
    public string Title { get; set; } = "";
    [MaxLength(62000)]
    public string Body { get; set; } = "";
}