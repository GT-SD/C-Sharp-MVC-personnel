//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kursovaya_MVC
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Work_wrk_Result
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Число должно быть положительным")]
        [Display(Name = "Таблеьный номер")]
        public int N_worker { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 100 символов")]
        [Display(Name = "ФИО")]
        public string Full_Name { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 11 символов")]
        [Display(Name = "Паспорт")]
        public string Passport { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 100 символов")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Birthday { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 20 символов")]
        [Display(Name = "Пол")]
        public string Sex { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 20 символов")]
        [Display(Name = "Должность")]
        public string Post { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "Число должно быть положительным")]
        [Display(Name = "Кол-во детей")]
        public Nullable<int> Аmount_of_children { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 100 символов")]
        [Display(Name = "Наименование отдела")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Дата начала работы")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Date_Start { get; set; }
        [Required]
        [Display(Name = "Дата окончания работы")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Date_End { get; set; }
    }
}
