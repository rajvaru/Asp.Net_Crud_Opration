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
            objcmd.CommandText = "Select CityID,CityName,STDCode from City";
            SqlDataReader objsdr = objcmd.ExecuteReader();

            //StateList.DataSource = objsdr;
            //StateList.DataBind();
            GridViewCity.DataSource = objsdr;
            GridViewCity.DataBind();
            objcon.Close();
        }
        protected void GridViewCity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (int.TryParse(e.CommandArgument.ToString(), out int CityID))
            {
                if (e.CommandName == "DeleteRecord")
                {
                    DeleteCity(CityID);
                }
                else if (e.CommandName == "EditRecord")
                {
                    EditCity(CityID);
                }
            }
          
        }

        private void DeleteCity(int CityID)
        {
            SqlConnection objcon = new SqlConnection("Data Source=LAPTOP-NUIFP4D9\\SQLEXPRESS;Initial Catalog=AddressBook;Integrated Security=true;");

            objcon.Open();
            SqlCommand objcmd = new SqlCommand("DELETE FROM City WHERE CityID = @CityID", objcon);
            objcmd.Parameters.AddWithValue("@CityID", CityID);
            objcmd.ExecuteNonQuery(); // Execute delete command
            BindCityData(); // Refresh GridView after deletion
        }

        private void EditCity(int CityID)
        {
            Response.Redirect("CityAddEdit.aspx?CityID=" + CityID);
        }
    }
}