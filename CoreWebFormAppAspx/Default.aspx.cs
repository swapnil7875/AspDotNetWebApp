using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoreWebFormAppAspx
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRecord();
            }
        }

        SqlConnection sqlCon = new SqlConnection("Data Source=192.168.100.8;Initial Catalog=Test;User ID=DBA;Password=DB@123");

        void LoadRecord()
        {
            SqlCommand sqlCmd = new SqlCommand("select * from EmpCrud", sqlCon);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("Insert into EmpCrud values('" + int.Parse(txtEmpId.Text) + "','" + txtEmpName.Text + "','" + DropDownList1.SelectedValue + "','" + double.Parse(txtContact.Text) + "')", sqlCon);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('succesfully Inserted');", true);
                LoadRecord();
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                string temp = "alert('" + msg + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", temp, true);
            }
           
        }

        protected void Update_Click(object sender, EventArgs e)
        {

            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("Update EmpCrud set EmpName= ' " + txtEmpName.Text + " ', Designation= ' " + DropDownList1.Text + " ', Contact= ' " + double.Parse(txtContact.Text) + " ' where EmpId ='" + int.Parse(txtEmpId.Text) + "'", sqlCon);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('succesfully updated');", true);
            LoadRecord();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            sqlCon.Open();
            string deleteStr = ("delete from EmpCrud where EmpId ='" + int.Parse(txtEmpId.Text) + "'");
            SqlCommand sqlCmd = new SqlCommand(deleteStr, sqlCon);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('succesfully deleted');", true);
            LoadRecord();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCmd = new SqlCommand("select * from EmpCrud where EmpId ='" + int.Parse(txtEmpId.Text) + "'", sqlCon);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void Get_Click(object sender, EventArgs e)
        {
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("Select * from EmpCrud where EmpId ='" +int.Parse(txtEmpId.Text)+ "'", sqlCon);
            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                txtEmpId.Text =reader.GetValue(0).ToString();
                txtEmpName.Text =reader.GetValue(1).ToString();
                DropDownList1.SelectedValue =reader.GetValue(2).ToString(); 
                txtContact.Text =reader.GetValue(3).ToString();
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            datepicker.Visible = true;
        }

        protected void datepicker_SelectionChanged1(object sender, EventArgs e)
        {

            txtdtp.Text = datepicker.SelectedDate.ToShortDateString(); // just use this method to get dd/MM/yyyy  
            datepicker.Visible = false;
        }


    }
}