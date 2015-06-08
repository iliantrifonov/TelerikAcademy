using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_03.CountryInfoSystem
{
    public partial class Contries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void TownsListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.TownsListView.InsertItemPosition = InsertItemPosition.None;
        }

        protected void ButtonInsertTown_Click(object sender, EventArgs e)
        {
            this.TownsListView.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void CountriesGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            var context = new CountriesInfoEntities();
            using (context)
            {
                var country = new Country()
                {
                    Name = ViewState["Name"].ToString(),
                    Population = int.Parse(ViewState["Population"].ToString()),
                    Language = ViewState["Language"].ToString(),
                    ContinentId = int.Parse(ViewState["ContinentId"].ToString())
                };
                context.Countries.Add(country);
                context.SaveChanges();
                this.CountriesGrid.DataBind();
                ViewState["Name"] = "";
                ViewState["Population"] = "";
                ViewState["Language"] = "";
                ViewState["ContinentId"] = "";
            }
        }

        protected void CountryNameInsertTb_PreRender(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            ViewState["Name"] = tb.Text;
        }

        protected void CountryPopulationBind_PreRender(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            var text = tb.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {
                ViewState["Population"] = int.Parse(text);
            }
        }

        protected void CountinentId_PreRender(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            var text = tb.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {
                ViewState["ContinentId"] = int.Parse(text);
            }
        }

        protected void ContinentsListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            (sender as ListView).InsertItemPosition = InsertItemPosition.None;
        }
    }
}