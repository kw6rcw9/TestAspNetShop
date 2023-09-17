using System.ComponentModel.DataAnnotations;


namespace testAspShop.Models;

public class Blog
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Annons { get; set; }
    public string? FullText { get; set; }

}
