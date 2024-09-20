using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Addressbook
{
    public partial class City : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCityData();
            }
        }
        private void BindCityData()
        {
            SqlConnection objcon = new SqlConnection();
            objcon.ConnectionString = "Data Source = LAPTOP-NUIFP4D9\\SQLEXPRESS; Initial Catalog = AddressBook; Integrated Security=true; ";

            objcon.Open();
            SqlCommand objcmd = objcon.CreateCommand();
            objcmd.CommandType = CommandType.Text;
            objcmd.CommandText = "Select CityID,CityName,CityCode from City";
            SqlDataReader objsdr = objcmd.ExecuteReader();

            //StateList.DataSource = objsdr;
            //StateList.DataBind();
            GridViewCity.DataSource = objsdr;
            GridViewCity.DataBind();
            objcon.Close();
        }
    }
}