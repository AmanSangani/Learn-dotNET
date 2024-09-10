using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddressBook.Content
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"]  == null)
            {
                Response.Redirect("~/AdminPanel/Auth/Login.aspx");
            }
            else
            {
                String DisplayName = "";
                String email = "";

                #region Establish Connection

                SqlConnection connObj = new SqlConnection();

                connObj.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;

                #endregion Establish Connection

                try
                {
                    #region Connection and Command Object

                    if (connObj.State != ConnectionState.Open)
                    {
                        connObj.Open();
                    }

                    SqlCommand cmdObj = new SqlCommand();

                    cmdObj.Connection = connObj;

                    cmdObj.CommandType = CommandType.StoredProcedure;

                    #endregion Connection and Command Object

                    #region Store Procedure, Execute and Read/Bind Data

                    cmdObj.CommandText = "PR_User_SelectByPK";

                    cmdObj.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

                    SqlDataReader sdrObj = cmdObj.ExecuteReader();

                    while(sdrObj.Read())
                    {
                        if (!sdrObj["DisplayName"].Equals(DBNull.Value))
                        {
                            DisplayName = sdrObj["DisplayName"].ToString();
                        }
                        if (!sdrObj["email"].Equals(DBNull.Value))
                        {
                            email = sdrObj["email"].ToString();
                        }
                        break;
                    }

                    #endregion Store Procedure, Execute and Read/Bind Data
                }

                #region Exception Handling
                catch (SqlException sqlEx)
                {
                    Response.Write("SQL Error: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                }
                #endregion Exception Handling

                #region Close Connection
                finally
                {
                    if (connObj.State == ConnectionState.Open)
                    {
                        connObj.Close();
                    }
                }
                #endregion Close Connection

                lblUsernameMsj.Text = "Hello " + DisplayName + "  |  Email: " + email;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/AdminPanel/Auth/Login.aspx");
        }
    }
}