using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITI_Final.Models
{
    public partial class News
    {
        public int Id { get; set; }

        [DisplayName("عنوان الخبر")]
        public string? Title { get; set; }

        [DisplayName("التاريخ")]
        public DateTime? Date { get; set; }

        [DisplayName("الصورة")]
        public string? Image { get; set; }

        [DisplayName("النص")]
        public string? Topic { get; set; }

        [DisplayName("الفْة")]
        public int? IdCat { get; set; }

        [DisplayName("الفْة")]
        public virtual Category? IdCatNavigation { get; set; }
    }
}
