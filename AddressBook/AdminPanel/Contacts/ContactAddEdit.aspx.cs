using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace AddressBook.AdminPanel.Contacts
{
    public partial class ContactAddEdit : System.Web.UI.Page
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ContactCategoryFill();
            }
        }
        #endregion Page Load

        #region Contact Category Fill

        private void ContactCategoryFill()
        {
            #region Establish Connection
            SqlConnection connObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Establish Connection

            try
            {
                #region Connection and Command object
                if (connObj.State != ConnectionState.Open)
                {
                    connObj.Open();
                }

                SqlCommand cmdObj = connObj.CreateCommand();


                cmdObj.CommandType = CommandType.StoredProcedure;

                #endregion Connection and Command object

                #region Store Procedure, Execute and Read/Bind Data

                cmdObj.CommandText = "PR_ContactCategory_SelectAll";

                SqlDataReader sdrObj = cmdObj.ExecuteReader();

                cblContactCategory.DataSource = sdrObj;
                cblContactCategory.DataTextField = "ContactCategoryName";
                cblContactCategory.DataValueField = "ContactCategoryID";
                cblContactCategory.DataBind();

                #endregion Store Procedure, Execute and Read/Bind Data

            }
            #region Exception Handling
            catch (SqlException sqlEx)
            {
                Response.Write("Error: " + sqlEx.Message);
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

        #endregion Contact Category Fill

        #region Button : Save
        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            #region Local Varialble
            SqlString strContactName = SqlString.Null;
            SqlString strContactNo = SqlString.Null;
            String FolderPath = "";
            String AbsolutePath = "";
            String strContactImage = "";
            #endregion Local Varialble

            #region Server Side Validation
            if (
                txtContactName.Text.Trim() == "" ||
                txtContactNo.Text.Trim() == "" 
            )
            {
                lblMsj.Text += "Enter Required Fields...";
                return;
            }

            #endregion Server Side Validation

            #region Establish Connection
            SqlConnection connObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Establish Connection

            try
            {
                #region Connection and Command object
                if (connObj.State != ConnectionState.Open)
                {
                    connObj.Open();
                }

                SqlCommand cmdObj = connObj.CreateCommand();


                cmdObj.CommandType = CommandType.StoredProcedure;

                #endregion Connection and Command object

                #region File Handling

                if (fuContactImg.HasFile)
                {
                    try
                    {
                        FolderPath = "~/Content/images/";
                        AbsolutePath = Server.MapPath(FolderPath);

                        if (!Directory.Exists(AbsolutePath))
                        {
                            Directory.CreateDirectory(AbsolutePath);
                        }

                        fuContactImg.SaveAs(AbsolutePath + fuContactImg.FileName.ToString().Trim());
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message.ToString());
                    }

                }

                #endregion File Handling

                #region Parameters

                strContactName = txtContactName.Text.Trim();
                strContactNo = txtContactNo.Text.Trim();
                strContactImage = FolderPath.ToString().Trim() + fuContactImg.FileName.ToString().Trim();

                cmdObj.Parameters.AddWithValue("@UserID", Session["UserID"]);
                cmdObj.Parameters.AddWithValue("@ContactName", strContactName);
                cmdObj.Parameters.AddWithValue("@ContactNo", strContactNo);
                cmdObj.Parameters.AddWithValue("@ContactImg", strContactImage);

                #endregion Parameters

                #region Add-Mode / Edit-Mode

                if (Page.RouteData.Values["OperationName"].ToString() == "Edit" && Page.RouteData.Values["ContactID"] != null)
                {
                    #region Edit-Mode

                    //cmdObj.CommandText = "PR_City_UpdateByPK_UserID";
                    //cmdObj.ExecuteNonQuery();
                    //Response.Redirect("~/AdminPanel/City/CityList.aspx");

                    #endregion Edit-Mode
                }
                else
                {
                    #region Add-Mode

                    cmdObj.Parameters.Add("@ContactID", SqlDbType.Int, 4);
                    cmdObj.Parameters["@ContactID"].Direction = ParameterDirection.Output;

                    cmdObj.CommandText = "PR_Contact_Insert";

                    cmdObj.ExecuteNonQuery();

                    String ContactID = cmdObj.Parameters["@ContactID"].Value.ToString();

                    lblMsj.Text = "Data Inserted Successfully...ContactID: " + ContactID;

                    txtContactName.Text = "";
                    
                    txtContactNo.Text = "";

                    #endregion Add-Mode
                }

                #endregion Add-Mode / Edit-Mode

            }
            #region Exception Handling
            catch (SqlException sqlEx)
            {
                Response.Write("Error: " + sqlEx.Message);
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
        #endregion Button : Save

        #region Button : Cancel
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel/Contact/list");
        }
        #endregion Button : Cancel

    }
}