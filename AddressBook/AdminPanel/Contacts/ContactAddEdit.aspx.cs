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

                #region Routes

                if (Page.RouteData.Values["OperationName"] != null)
                {
                    #region Add Route
                    if (Page.RouteData.Values["OperationName"].ToString() == "Add")
                    {
                        lblAddEdit.Text = Page.RouteData.Values["OperationName"].ToString();
                    }
                    #endregion Add Route

                    #region Edit Route
                    else if (Page.RouteData.Values["OperationName"].ToString() == "Edit")
                    {
                        if (Page.RouteData.Values["ContactID"] != null)
                        {
                            lblAddEdit.Text = Page.RouteData.Values["OperationName"].ToString();
                            rfvContactImg.Enabled = false;
                            FillControlsOnEdit(Page.RouteData.Values["ContactID"].ToString().Trim());
                        }
                        else
                        {
                            Response.Redirect("~/AdminPanel/Contact/List");
                        }
                    }
                    #endregion Edit Route

                    #region Invalid Route
                    else
                    {
                        Response.Redirect("~/AdminPanel/Contact/List");
                    }
                    #endregion Invalid Route

                }

                #endregion Routes
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

        #region Fill Control on Edit
        private void FillControlsOnEdit(String ContactID)
        {
            #region Establish Connection

            SqlConnection connObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

            #endregion Establish Connection

            try
            {
                #region Connection and Command Object

                if (connObj.State != ConnectionState.Open)
                {
                    connObj.Open();
                }

                SqlCommand cmdObj = connObj.CreateCommand();

                cmdObj.CommandType = CommandType.StoredProcedure;

                #endregion Connection and Command Object

                #region Store Procedure, Parameters and Execute
                cmdObj.CommandText = "PR_Contact_SelectByPK_UserID";

                cmdObj.Parameters.AddWithValue("@UserID", Session["UserID"]);
                cmdObj.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());

                SqlDataReader sdrObj = cmdObj.ExecuteReader();
                #endregion Store Procedure, Parameters and Execute

                #region Assign Values to Controls
                if (sdrObj.HasRows)
                {
                    while (sdrObj.Read())
                    {
                        if (!sdrObj["ContactName"].Equals(DBNull.Value))
                        {
                            txtContactName.Text = sdrObj["ContactName"].ToString();
                        }
                        if (!sdrObj["ContactNo"].Equals(DBNull.Value))
                        {
                            txtContactNo.Text = sdrObj["ContactNo"].ToString();
                        }
                        if (!sdrObj["ContactImg"].Equals(DBNull.Value))
                        {
                            imgContact.ImageUrl = sdrObj["ContactImg"].ToString();
                            hfContactImg.Value = sdrObj["ContactImg"].ToString();
                        }
                        break;
                    }
                }
                else
                {
                    lblMsj.Text += "No Data for selected Country : " + ContactID.ToString();
                }
                #endregion Assign Values to Controls

            }
            #region Exception Handling
            catch (SqlException sqlEx)
            {
                Response.Write("Sql Exception: " + sqlEx.Message);
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

        #endregion Fill Control on Edit

        #region Button : Save
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                lblMsj.Text = "Validation failed. Please check the fields.";
                return; 
            }

            #region Local Variables
            SqlString strContactName = SqlString.Null;
            SqlString strContactNo = SqlString.Null;
            String FolderPath = "";
            String AbsolutePath = "";
            String strContactImage = "";
            #endregion Local Variables

            #region Server Side Validation
            if (txtContactName.Text.Trim() == "" || txtContactNo.Text.Trim() == "")
            {
                lblMsj.Text += "Enter Required Fields...";
                return;
            }

            string contactNo = txtContactNo.Text.Trim();
            string phonePattern = @"^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(contactNo, phonePattern))
            {
                lblMsj.Text = "Invalid Contact Number format.";
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
                    // If a new file is uploaded, save it and assign its path to strContactImage
                    try
                    {
                        FolderPath = "~/Content/images/";
                        AbsolutePath = Server.MapPath(FolderPath);

                        if (!Directory.Exists(AbsolutePath))
                        {
                            Directory.CreateDirectory(AbsolutePath);
                        }

                        fuContactImg.SaveAs(AbsolutePath + fuContactImg.FileName.ToString().Trim());
                        strContactImage = FolderPath + fuContactImg.FileName.ToString().Trim();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message.ToString());
                    }
                }
                else
                {
                    // If no file is uploaded, retain the existing image stored in hfContactImg
                    strContactImage = hfContactImg.Value;
                }
                #endregion File Handling

                #region Parameters
                strContactName = txtContactName.Text.Trim();
                strContactNo = txtContactNo.Text.Trim();

                cmdObj.Parameters.AddWithValue("@UserID", Session["UserID"]);
                cmdObj.Parameters.AddWithValue("@ContactName", strContactName);
                cmdObj.Parameters.AddWithValue("@ContactNo", strContactNo);
                cmdObj.Parameters.AddWithValue("@ContactImg", strContactImage);
                #endregion Parameters

                #region Add-Mode / Edit-Mode
                if (Page.RouteData.Values["OperationName"].ToString() == "Edit" && Page.RouteData.Values["ContactID"] != null)
                {
                    #region Edit-Mode
                    cmdObj.Parameters.AddWithValue("@ContactID", Page.RouteData.Values["ContactID"].ToString());
                    cmdObj.CommandText = "PR_Contact_UpdateByPK_UserID";
                    cmdObj.ExecuteNonQuery();
                    Response.Redirect("~/AdminPanel/Contact/List");
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

                    foreach (ListItem listCategory in cblContactCategory.Items)
                    {
                        if (listCategory.Selected)
                        {
                            SqlCommand cmdCategoryWiseContact = connObj.CreateCommand();
                            cmdCategoryWiseContact.CommandType = CommandType.StoredProcedure;
                            cmdCategoryWiseContact.Parameters.AddWithValue("@ContactID", ContactID);
                            cmdCategoryWiseContact.Parameters.AddWithValue("@CategoryID", listCategory.Value.ToString());
                            cmdCategoryWiseContact.CommandText = "PR_CategoryWiseContact_Insert";
                            cmdCategoryWiseContact.ExecuteNonQuery();
                        }
                    }

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