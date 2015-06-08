namespace Web.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class CommentInputDataModel
    {
        [Required]
        public string Content { get; set; }
    }
}