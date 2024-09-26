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
    public partial class CountryAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Request.QueryString["CountryID"] != null)
                {
                    EditCountry(Convert.ToInt32(Request.QueryString["CountryID"]));
                }
            }
        }
        public void EditCountry(int CountryID)
        {
            SqlConnection objConn = new SqlConnection("Data Source=LAPTOP-NUIFP4D9\\SQLEXPRESS;Initial Catalog=AddressBook;Integrated Security=true;");

            //SqlConnection objConn = new SqlConnection("Data Source=LAPTOP-NUIFP4D9\\SQLEXPRESS;Initial Catalog=AddressBook;Integrated Security=True;");
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.Text;
            objCmd.CommandText = "SELECT CountryID, CountryName, CountryCode FROM [dbo].[Country] WHERE CountryID = " + CountryID;
            SqlDataReader dr = objCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            objConn.Close();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow drow in dt.Rows)
                {
                    txtCountryID.Text = drow["CountryID"].ToString();
                    txtCountryName.Text = drow["CountryName"].ToString();
                    txtCountryCode.Text = drow["CountryCode"].ToString();
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
            if (Request.QueryString["CountryID"] != null)
            {
                objCmd.CommandText = "UPDATE [dbo].[Country] SET CountryName='" + txtCountryName.Text.Trim() + "', CountryCode='" + txtCountryCode.Text.Trim() + "' WHERE CountryID=" + Request.QueryString["CountryID"].ToString();
                objCmd.ExecuteNonQuery();
            }
            else
            {
                objCmd.CommandText = "INSERT INTO [dbo].[Country] (CountryId, CountryName, CountryCode) VALUES ('" + txtCountryID.Text.Trim() + "','" + txtCountryName.Text.Trim() + "','" + txtCountryCode.Text.Trim() + "')";
                objCmd.ExecuteNonQuery();
            }
            objConn.Close();
            Response.Redirect("~/Country.aspx");

        }
        /*private void BindCountryDropdown()
        {
            SqlConnection objConn = new SqlConnection("Data Source=LAPTOP-NUIFP4D9\\SQLEXPRESS;Initial Catalog=AddressBook;Integrated Security=true;");
            objConn.Open();

            SqlCommand objCmd = new SqlCommand("SELECT CountryID, CountryName FROM dbo.Country", objConn);
            SqlDataReader dr = objCmd.ExecuteReader();

            ddlCountryID.DataSource = dr;
            ddlCountryID.DataValueField = "CountryID";
            ddlCountryID.DataTextField = "CountryName";
            ddlCountryID.DataBind();

            // Adding a default "Select Country" option
            ddlCountryID.Items.Insert(0, new ListItem("Select Country", "0"));

            objConn.Close();
        }*/
        protected void btnAdd_Click(object sender, EventArgs e)
        {


            SqlConnection objConn = new SqlConnection("Data Source=LAPTOP-NUIFP4D9\\SQLEXPRESS;Initial Catalog=AddressBook;Integrated Security=true;");
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.Text;

            // Set the command timeout to 60 seconds (default is 30 seconds)
            objCmd.CommandTimeout = 60;

            // Do not insert the CountryID, as it's an identity column and auto-incremented
            objCmd.CommandText = "INSERT INTO [dbo].[Country] (CountryName, CountryCode) VALUES (@CountryName, @CountryCode)";

            objCmd.Parameters.AddWithValue("@CountryName", txtCountryName.Text.Trim());
            objCmd.Parameters.AddWithValue("@CountryCode", txtCountryCode.Text.Trim());

            objCmd.ExecuteNonQuery();
            objConn.Close();

            // Redirect to the Country list page
            Response.Redirect("~/Country.aspx");
        }

    }
}