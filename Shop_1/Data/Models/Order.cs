using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Shop_1.Data.Models
{
    /// <summary>
    /// Модель для заказа
    /// </summary>
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Введите имя")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина имени не менее 3 символов")]
        public string Name { get; set; }

        [Display(Name = "Введите фамилию")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина фамилии не менее 3 символов")]
        public string SurName { get; set; }

        [Display(Name = "Введите адрес")]
        [StringLength(50)]
        [Required(ErrorMessage = "Длина адреса не менее 3 символов")]
        public string Adress { get; set; }

        [Display(Name = "Номер телефон")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера телефона не менее 10 символов")]
        public string Phone { get; set; }

        [Display(Name = "email")]
        [StringLength(35)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Длина email не менее 5 символов")]
        public string Email { get; set; }


        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// Описание всех товаров, которые приобретают
        /// </summary>
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
