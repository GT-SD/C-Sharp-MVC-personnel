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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Worker_has_Children
    {
        public int ID_Rec { get; set; }
        [Required]
        [Display(Name = "Номер ребенка- Имя")]
        public int Children_ID_Children { get; set; }
        [Required]
        [Display(Name = "Табельный номер - ФИО студента")]
        public int Worker_N_worker { get; set; }
    
        public virtual Children Children { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
