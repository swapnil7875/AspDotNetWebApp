using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;
using System.Configuration;

namespace SignUpForm_Swapnil
{
    public partial class SIgnUp : System.Web.UI.Page
    {
        string checkMail = "";
        string userMail = "";
        string PanFilePath = "";
        string AadPathFrontImg = "";
        string AadPathBackImg = "";
        SqlConnection SqlCon = new SqlConnection("Data Source=.;Initial Catalog=TestDB;Integrated Security = True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {

                string checkPanNo = @"^[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}$";
                bool isPANValid = Regex.IsMatch(txtPanNumber.Text.ToString().Trim(), checkPanNo);
                if (isPANValid == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter the valid pan number')", true);
                    txtPanNumber.Text = "";
                    return;
                }

                HttpPostedFile filePan = Request.Files["FilePan"];
                if (filePan != null && filePan.ContentLength > 0)
                {
                    string fname = Path.GetFileName(filePan.FileName);
                    filePan.SaveAs(Server.MapPath(Path.Combine("~/App_Data/", fname)));
                     PanFilePath = Server.MapPath(Path.Combine("~/App_Data/", fname));
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select the pan')", true);
                    return;
                }

                HttpPostedFile FileAadFront = Request.Files["FileAadFront"];
                if (FileAadFront != null && FileAadFront.ContentLength > 0)
                {
                    string fname = Path.GetFileName(FileAadFront.FileName);
                    filePan.SaveAs(Server.MapPath(Path.Combine("~/App_Data/", fname)));
                     AadPathFrontImg = Server.MapPath(Path.Combine("~/App_Data/", fname));
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Front Aadhar Imgage')", true);
                    return;
                }

                HttpPostedFile FileAadBack = Request.Files["FileAadBack"];
                if (FileAadBack != null && FileAadBack.ContentLength > 0)
                {
                    string fname = Path.GetFileName(FileAadBack.FileName);
                    filePan.SaveAs(Server.MapPath(Path.Combine("~/App_Data/", fname)));
                     AadPathBackImg = Server.MapPath(Path.Combine("~/App_Data/", fname));
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Back Aadhar Imgage')", true);
                    return;
                }

            }
            catch
            {

            }
            try
            {
                SqlCon.Open();
                userMail = txtEmail.Text;
                SqlCommand sqlCmd = new SqlCommand("Select Email from UserData where Email ='" + userMail + "'", SqlCon);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                     checkMail = reader.GetValue(0).ToString();
                }
                SqlCon.Close();

                if (checkMail.ToLower() != userMail.ToLower())
                {
                    SqlCon.Open();
                    SqlCommand Cmd = new SqlCommand("Sp_UserRegistration", SqlCon);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    Cmd.Parameters.AddWithValue("@MiddleName", txtMidName.Text);
                    Cmd.Parameters.AddWithValue("@LastName", txtLstName.Text);
                    Cmd.Parameters.AddWithValue("@DOB", txtDate.Text.ToString());
                    Cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    Cmd.Parameters.AddWithValue("@City", txtCity.Text);
                    Cmd.Parameters.AddWithValue("@State", txtState.Text);
                    Cmd.Parameters.AddWithValue("@Pin_Code", txtPinCode.Text);
                    Cmd.Parameters.AddWithValue("@mobileNo", txtMoNo.Text);
                    Cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    Cmd.Parameters.AddWithValue("@PanNo", txtPanNumber.Text);
                    Cmd.Parameters.AddWithValue("@PanPath", PanFilePath);
                    Cmd.Parameters.AddWithValue("@AadharNo", txtAadhar.Text);
                    Cmd.Parameters.AddWithValue("@AadharFrontImg", AadPathFrontImg);
                    Cmd.Parameters.AddWithValue("@AadharBackImg", AadPathBackImg);
                    Cmd.Parameters.AddWithValue("@Gender", DropDownList1.Text);
                    Cmd.Parameters.AddWithValue("@ReturnCode", 0);
                    Cmd.Parameters.AddWithValue("@ReturnDesc", "");
                    Cmd.ExecuteNonQuery();
                    SqlCon.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registration successful')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email alredy exist')", true);
                }
               
                

            }
            catch(Exception ex)
            {
                string msg = "alert(" +"'" + ex.Message + "'" + ")";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", msg , true);
            }
        }

    }
}