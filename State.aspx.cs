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
    public partial class State : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStateData();
            }
        }

        private void BindStateData()
        {
            SqlConnection objcon = new SqlConnection("Data Source=LAPTOP-NUIFP4D9\\SQLEXPRESS;Initial Catalog=AddressBook;Integrated Security=true;");
            objcon.Open();
            SqlCommand objcmd = objcon.CreateCommand();
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "PR_State_SelectAll";
            SqlDataReader objsdr = objcmd.ExecuteReader();
            GridViewState.DataSource = objsdr;
            GridViewState.DataBind();  
        }

        protected void GridViewState_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (int.TryParse(e.CommandArgument.ToString(), out int stateID))
            {
                if (e.CommandName == "DeleteRecord")
                {
                    DeleteState(stateID);
                }
                else if (e.CommandName == "EditRecord")
                {
                    EditState(stateID);
                }
            }
            else
            {
                // Handle invalid StateID here
            }
        }

        private void DeleteState(int stateID)
        {
            SqlConnection objcon = new SqlConnection("Data Source=LAPTOP-NUIFP4D9\\SQLEXPRESS;Initial Catalog=AddressBook;Integrated Security=true;");

            objcon.Open();
            SqlCommand objcmd = new SqlCommand("DELETE FROM State WHERE StateID = @StateID", objcon);
            objcmd.Parameters.AddWithValue("@StateID", stateID);
            objcmd.ExecuteNonQuery(); // Execute delete command
            BindStateData(); // Refresh GridView after deletion
        }

        private void EditState(int StateID)
        {
            Response.Redirect("StateAddEdit.aspx?StateID=" + StateID);
        }
    }
}
