namespace Web.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    using Model;

    public class CategoryOutputDataModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Category, CategoryOutputDataModel>> ToDataModel
        {
            get
            {
                return c => new CategoryOutputDataModel()
                {
                    Name = c.Name,
                    Id = c.Id
                };
            }
        }

        public static Expression<Func<CategoryOutputDataModel, Category>> ToModel
        {
            get
            {
                return c => new Category()
                {
                    Id = c.Id,
                    Name = c.Name
                };
            }
        }
    }
}