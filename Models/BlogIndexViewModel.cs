using HomepageV2.Data.Models;
using homepageV2.Data.Models.Generic;

namespace homepageV2.Models;

public class BlogIndexViewModel
{
    public List<PaginatedObject> Items { get; set; }
    public bool HasNextPage { get; set; }
}
