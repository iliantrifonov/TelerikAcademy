namespace Web.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    using Model;

    public class TagOutputDataModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Tag, TagOutputDataModel>> ToDataModel
        {
            get
            {
                return t => new TagOutputDataModel()
                {
                    Id = t.Id,
                    Name = t.Name
                };
            }
        }
     }
}