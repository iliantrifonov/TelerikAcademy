using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3.WebPhotoAlbum
{
    public partial class WebPhotoAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static Slide[] GetSlides()
        {
            return new Slide[]{
                new Slide("Images/c0.jpg", "cat0", "Cat 0"),
                new Slide("Images/c1.jpg", "cat1", "Cat 1"),
                new Slide("Images/c2.jpg", "cat2", "Cat 2"),
                new Slide("Images/c3.jpg", "cat3", "Cat 3"),
                new Slide("Images/c4.jpg", "cat4", "Cat 4"),
                new Slide("Images/c5.jpg", "cat5", "Cat 5")
            };
        }
    }
}