using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace testAspShop.Models
{
    public class Order
    {
        [BindNever]
        
        public int Id { get; set; }
        [Display(Name = "Введите имя")]
        [Required(ErrorMessage = "Имя обязательно для заполнения")]
        [StringLength(100, ErrorMessage ="Имя должно быть менее 30 символов")]
        public string Name { get; set; }
        [Display(Name = "Введите фамилию")]
        [Required(ErrorMessage = "Фамилия обязательно для заполнения")]
        [StringLength(100, ErrorMessage = "Фамилия должна быть менее 30 символов")]
        public string Surname { get; set; }
        [Display(Name = "Введите адрес")]
        [Required(ErrorMessage = "Адрес обязателен для заполнения")]
        [StringLength(100, ErrorMessage = "Адрес должен быть менее 30 символов")]
        public string Adress { get; set; }
        [Display(Name = "Введите номер телефона")]
        [Required(ErrorMessage = "Номер телефона обязателен для заполнения")]
        [StringLength(100, ErrorMessage = "Номер должен быть менее 30 символов")]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Введите Email")]
        [Required(ErrorMessage = "Email обязателен для заполнения")]
        [StringLength(100, ErrorMessage = "Email должен быть менее 30 символов")]
        [EmailAddress(ErrorMessage = "Вы ввели не Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Ваша корзина пуста")]
        public string Cart { get; set; }
    }
}
