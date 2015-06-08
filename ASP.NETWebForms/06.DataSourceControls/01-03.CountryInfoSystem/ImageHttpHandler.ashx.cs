using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace _01_03.CountryInfoSystem
{
    public class ImageHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.QueryString["Id"]))
            {
                var countryId = context.Request.QueryString["Id"].ToString();
                if (!string.IsNullOrEmpty(countryId))
                {
                    var result = RetrieveFlagImage(int.Parse(countryId));
                    if (result != null)
                    {
                        context.Response.BinaryWrite(result);
                        context.Response.End();
                    }
                }
            }
        }

        private byte[] RetrieveFlagImage(int id)
        {
            var db = new CountriesInfoEntities();
            var country = db.Countries.Find(id);
            if (country != null)
            {
                return country.Flag;
            }

            return null;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}