namespace Web.DataModels
{
    using Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class ArticleInputDataModel
    {
        public ArticleInputDataModel()
        {
            this.Tags = new HashSet<string>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string Category { get; set; }

        public ICollection<string> Tags { get; set; }
    }
}