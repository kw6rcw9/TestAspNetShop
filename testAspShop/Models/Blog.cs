using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;


namespace testAspShop.Models;

public class Blog
{
    [Key]
    [BindNever]

    
    public int Id { get; set; }
    [Display(Name = "Введите название")]
    [Required(ErrorMessage = "Название обязательно для заполнения")]
    public string? Title { get; set; }
    [Display(Name = "Введите анонс")]
    [Required(ErrorMessage = "Анонс обязателен для заполнения")]
    public string? Annons { get; set; }
    [Display(Name = "Введите текст")]
    [Required(ErrorMessage = "Текст обязательно для заполнения")]
    public string? FullText { get; set; }

}
