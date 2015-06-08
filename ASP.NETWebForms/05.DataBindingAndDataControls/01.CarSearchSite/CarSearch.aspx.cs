using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.CarSearchSite
{
    public partial class CarSearch : System.Web.UI.Page
    {
        private List<Producer> cars = new List<Producer>
        {
            new Producer() { Brand = "BMV", Model = "320", },
            new Producer() { Brand = "BMV", Model = "520", },
            new Producer() { Brand = "Audi", Model = "A4", },
            new Producer() { Brand = "Audi", Model = "A5", },
            new Producer() { Brand = "Mazda", Model = "2", },
            new Producer() { Brand = "Mazda", Model = "4", },
            new Producer() { Brand = "Mercedes", Model = "SLK" },

            new Producer() {  Brand = "BMV", Model = "x5" },
            new Producer() {  Brand = "BMV", Model = "x6" },
            new Producer() {  Brand = "Audi", Model = "320" },
            new Producer() {  Brand = "Audi", Model = "320" },
            new Producer() {  Brand = "Land Rover", Model = "1" },
            new Producer() {  Brand = "Land Rover", Model = "2" },

            new Producer() { Brand = "Kamaz", Model = "1" },
            new Producer() { Brand = "Zil", Model = "2" },
            new Producer() { Brand = "Mercedes", Model = "3" },
        };

        private List<Extra> extras = new List<Extra>()
        {
            new Extra() { Id = 1, Name = "Electric windows" },
            new Extra() { Id = 1, Name = "Leather Seats" },
            new Extra() { Id = 1, Name = "Door mats.." },
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var brands = cars.Select(b => b.Brand);
                var hashedBrands = new HashSet<string>(brands);
                this.DdlMake.DataSource = hashedBrands;
                this.DdlMake.DataBind();
            }

            var selectedBrand = this.DdlMake.SelectedValue;

            this.DdlModel.DataSource = this.cars.Where(c => c.Brand == selectedBrand).Select(c => c.Model);
            this.DdlModel.DataBind();

            if (!IsPostBack)
            {
                this.CblExtras.DataSource = extras.Select(a => a.Name).ToArray();
                this.CblExtras.DataBind();

                this.RbEngines.DataSource = new[] { "Diesel", "Gas", "Petrol" };
                this.RbEngines.DataBind();
            }


        }

        protected void Page_PreRender(object sender, EventArgs e)
        {

        }

        protected void DdlMake_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            var selectedExtras = new List<string>();
            foreach (ListItem extra in this.CblExtras.Items)
	        {
		        if (extra.Selected)
	            {
                    selectedExtras.Add(extra.Value);
	            }
	        }

            this.LiteralResult.Text = string.Format("Car producer : {0}; \n Model: {1}; \n Extras: {2}; \n Engine: {3};", this.DdlMake.SelectedValue, this.DdlModel.SelectedValue, string.Join(", ", selectedExtras), this.RbEngines.SelectedValue); 
        }
    }
}