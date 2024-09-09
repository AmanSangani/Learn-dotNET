using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddressBook.AdminPanel.Auth
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text != "" && txtPassword.Text != "")
            {
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

                    #region Store Procedure, Parameters and Execute 

                    cmdObj.CommandText = "PR_User_ValidateLogin";

                    cmdObj.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmdObj.Parameters.AddWithValue("@Password", txtPassword.Text);

                    SqlDataReader sdrObj = cmdObj.ExecuteReader();

                    #endregion Store Procedure, Parameters and Execute 

                    #region Assign Value to Session
                    if (sdrObj.HasRows)
                    {
                        while(sdrObj.Read())
                        {
                            Session["UserID"] = sdrObj["UserID"].ToString();
                            Response.Redirect("~/index.aspx");
                            break;
                        }
                    }
                    else
                    {
                        lblMessage.Text = "No Such User...";
                    }
                    #endregion Assign Value to Session

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
            }
        }
    }
}