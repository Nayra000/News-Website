using System;
using System.Collections.Generic;

namespace ITI_Final.Models
{
    public partial class Category
    {
        public Category()
        {
            News = new HashSet<News>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Describtion { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
