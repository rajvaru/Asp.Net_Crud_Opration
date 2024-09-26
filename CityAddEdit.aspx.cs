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
    public partial class CityAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindStateDropdown();

                if (Request.QueryString["CityID"] != null)
                {
                    EditCity(Convert.ToInt32(Request.QueryString["CityID"]));
                }
            }

        }
        public void EditCity(int CityID)
        {
            SqlConnection objConn = new SqlConnection("Data Source=LAPTOP-NUIFP4D9\\SQLEXPRESS;Initial Catalog=AddressBook;Integrated Security=true;");
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.Text;
            objCmd.CommandText = "SELECT CityID, CityName, STDCode FROM [dbo].[City] WHERE CityID = " + CityID;
            SqlDataReader dr = objCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            objConn.Close();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow drow in dt.Rows)
                {
                    txtCityID.Text = drow["CityID"].ToString();
                    txtCityName.Text = drow["CityName"].ToString();
                    txtSTDCode.Text = drow["STDCode"].ToString();
                    break;
                }
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection objConn = new SqlConnection("Data Source=LAPTOP-NUIFP4D9\\SQLEXPRESS;Initial Catalog=AddressBook;Integrated Security=true;");
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.Text;

            if (Request.QueryString["CityID"] != null)
            {
                // Updating an existing city
                objCmd.CommandText = "UPDATE [dbo].[City] SET CityName=@CityName, STDCode=@STDCode WHERE CityID=@CityID";
                objCmd.Parameters.AddWithValue("@CityName", txtCityName.Text.Trim());
                objCmd.Parameters.AddWithValue("@STDCode", txtSTDCode.Text.Trim());
                objCmd.Parameters.AddWithValue("@CityID", Request.QueryString["CityID"].ToString());
            }
            else
            {
                // Inserting a new city
                objCmd.CommandText = "INSERT INTO [dbo].[City] (CityName, STDCode) VALUES (@CityName, @STDCode)";
                objCmd.Parameters.AddWithValue("@CityName", txtCityName.Text.Trim());
                objCmd.Parameters.AddWithValue("@STDCode", txtSTDCode.Text.Trim());
            }

            objCmd.ExecuteNonQuery();
            objConn.Close();

            // Redirect to City list page
            Response.Redirect("~/City.aspx");
        }

        private void BindStateDropdown()
        {
            SqlConnection objConn = new SqlConnection("Data Source=LAPTOP-NUIFP4D9\\SQLEXPRESS;Initial Catalog=AddressBook;Integrated Security=true;");
            objConn.Open();

            SqlCommand objCmd = new SqlCommand("SELECT StateID, StateName FROM dbo.State", objConn);
            SqlDataReader dr = objCmd.ExecuteReader();

            ddlStateID.DataSource = dr;
            ddlStateID.DataValueField = "StateID";
            ddlStateID.DataTextField = "StateName";
            ddlStateID.DataBind();

            // Adding a default "Select State" option
            ddlStateID.Items.Insert(0, new ListItem("Select State", "0"));

            objConn.Close();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection objConn = new SqlConnection("Data Source=LAPTOP-NUIFP4D9\\SQLEXPRESS;Initial Catalog=AddressBook;Integrated Security=true;");
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.Text;

            int StateId = Convert.ToInt32(ddlStateID.SelectedValue); // Get the selected StateID

            objCmd.CommandText = "INSERT INTO [dbo].[City] (CityName, STDCode, StateID) VALUES (@CityName, @STDCode, @StateID)";

            objCmd.Parameters.AddWithValue("@CityName", txtCityName.Text.Trim());
            objCmd.Parameters.AddWithValue("@STDCode", txtSTDCode.Text.Trim()); // Use STDCode here
            objCmd.Parameters.AddWithValue("@StateID", StateId); // Adding StateID parameter

            objCmd.ExecuteNonQuery();
            objConn.Close();

            // Redirect to the City list page
            Response.Redirect("~/City.aspx");
        }


    }
}