using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Addressbook
{
    public partial class Country : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountryData();
            }
        }
        private void BindCountryData()
        {

            SqlConnection objcon = new SqlConnection();
            objcon.ConnectionString = "Data Source = LAPTOP-NUIFP4D9\\SQLEXPRESS; Initial Catalog = AddressBook; Integrated Security=true; ";

            objcon.Open();
            SqlCommand objcmd = objcon.CreateCommand();
            objcmd.CommandType=CommandType.StoredProcedure;
            objcmd.CommandText = "PR_Country_SelectAll";
            SqlDataReader objsdr = objcmd.ExecuteReader();
            GridViewCountry.DataSource = objsdr;
            GridViewCountry.DataBind();
            objcon.Close();
            
        }
    }
}