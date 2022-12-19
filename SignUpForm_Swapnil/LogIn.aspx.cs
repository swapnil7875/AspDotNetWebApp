using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignUpForm_Swapnil
{
    public partial class LogIn : System.Web.UI.Page
    {
        private string checkMail ;
        private string checkPass ;
        private string ipMail ;
        SqlConnection SqlCon = new SqlConnection("Data Source=.;Initial Catalog=TestDB;Integrated Security = True");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                divmail.Visible = true;
                ep.Visible = false;
                Span1.Visible = false;
                Span2.Visible = false;
                divpassd.Visible = false;
                divgenPass.Visible = false;
            }
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            ipMail = txtEmail.Text;
            SqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("Select Email, Pass from UserData where Email ='" + ipMail + "'", SqlCon);
            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                checkMail = (reader.GetValue(0).ToString() == null) ? string.Empty : reader.GetValue(0).ToString();
                checkPass = (reader.GetValue(1).ToString() == null) ? string.Empty : reader.GetValue(1).ToString();

            }

            if (checkMail == null){
                //ep.InnerText = "";
                ep.Visible = true;
                return;
            }
            else if (checkPass == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password note generated yet, Please cnt to genPass..!')", true);
                divmail.Visible = false;
                divgenPass.Visible = true;
            }
            else
            {
                divmail.Visible = false;
                divpassd.Visible = true;
            }
            SqlCon.Close();
        }

        protected void btnpass_Click(object sender, EventArgs e)
        {
            string EntPass = txtPass.Text;
            ipMail = hdnEmailID.Value;
            SqlCon.Open();
            SqlCommand sqlCommand = new SqlCommand("Select Email, Pass from UserData where Email ='" + ipMail + "'", SqlCon);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            checkPass = (reader.GetValue(1).ToString() == null) ? string.Empty : reader.GetValue(1).ToString();
            if (checkPass == EntPass)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Log In successful')", true);
            }
            else
            {
                Span1.Visible = true;
            }
            return;

        }

        protected void btnGenPass_Click(object sender, EventArgs e)
        {
            ipMail = hdnEmailID.Value;
            string pass1 = txtpass1.Text;
            string pass2 = txtpassConf.Text;
            if(pass1==pass2)
            {
                SqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand("update UserData set Pass = '" + pass2 + "' where Email= '" + ipMail + "'", SqlCon);
                sqlCommand.ExecuteNonQuery();
                SqlCon.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password generated')", true);
                divgenPass.Visible = false;
                divmail.Visible = false;
                divpassd.Visible = true;
                Span2.Visible = false;
                checkPass = pass1;
            }
            else
            {
                Span2.Visible = true;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password mismatch')", true);
                divmail.Visible = false;
                divgenPass.Visible = true;
            }
            
        }
    }
}