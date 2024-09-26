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

        protected void GridViewCountry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (int.TryParse(e.CommandArgument.ToString(), out int CountryID))
            {
                if (e.CommandName == "DeleteRecord")
                {
                    DeleteCountry(CountryID);
                }
                else if (e.CommandName == "EditRecord")
                {
                    EditCountry(CountryID);
                }
            }
            else
            {
                // Handle invalid StateID here
            }
        }
        private void DeleteCountry(int CountryID)
        {
            SqlConnection objcon = new SqlConnection("Data Source=LAPTOP-NUIFP4D9\\SQLEXPRESS;Initial Catalog=AddressBook;Integrated Security=true;");

            objcon.Open();
            SqlCommand objcmd = new SqlCommand("DELETE FROM Country WHERE CountryID = @CountryID", objcon);
            objcmd.Parameters.AddWithValue("@CountryID", CountryID);
            objcmd.ExecuteNonQuery(); // Execute delete command
            BindCountryData(); // Refresh GridView after deletion
        }

        private void EditCountry(int CountryID)
        {
            Response.Redirect("CountryAddEdit.aspx?CountryID=" + CountryID);
        }

        
    }
}