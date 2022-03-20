using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _19030690_Abhinav_Parajuli
{
    public partial class Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT TEACHER_ID, TEACHER_NAME,EMAIL FROM TEACHER";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("teacher");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            teacherGridView.DataSource = dt;
            teacherGridView.DataBind();

        }


        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            teacherGridView.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(teacherGridView.DataKeys[e.RowIndex].Values[0]);
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(constr))
                {
                    using (OracleCommand cmd = new OracleCommand("DELETE FROM TEACHER WHERE TEACHER_Id =" + ID))
                    {

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                this.BindGrid();
            }catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('error')", true);
            }


        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != teacherGridView.EditIndex)
            {

                // (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";


            }
            //this.BindGrid();
            teacherGridView.EditIndex = -1;

        }

        protected void onRowUpdating(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(teacherGridView.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM TEACHER WHERE TEACHER_ID =" + ID))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
            teacherGridView.EditIndex = -1;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // insert code
            string name = txtTeacherName.Text.ToString();
            string email = txtEmail.Text.ToString();
            string address_id = addressDropdown.SelectedValue.ToString();
            string module_code = moduleDropdown.SelectedValue.ToString();

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            if (btnSubmit.Text == "Button")
            {
                OracleCommand insert_teacher = new OracleCommand("INSERT into teacher(Teacher_Name, email)Values('" + name + "','" + email + "')");
                insert_teacher.Connection = con;
                con.Open();
                insert_teacher.ExecuteNonQuery();
                con.Close();

                /*OracleCommand get_teacher_id = new OracleCommand("SELECT MAX(TEACHER_ID) FROM TEACHER");
                get_teacher_id.Connection = con;
                con.Open();
                OracleDataReader dr = get_teacher_id.ExecuteReader();
                dr.Read();
                string teacher_Id = dr.GetString(0);
                con.Close();


                OracleCommand insert_teacher_address = new OracleCommand("INSERT INTO TEACHER_ADDRESS(TEACHER_ID, ADDRESS_ID)Values('" + teacher_Id + "','" + address_id + "')");
                insert_teacher_address.Connection = con;
                con.Open();
                insert_teacher_address.ExecuteNonQuery();
                con.Close();

                OracleCommand insert_teacher_module = new OracleCommand("INSERT INTO TEACHER_MODULE(TEACHER_ID, MODULE_CODE)Values('" + teacher_Id + "','" + module_code + "')");
                insert_teacher_module.Connection = con;
                con.Open();
                insert_teacher_module.ExecuteNonQuery();
                con.Close();*/


                con.Close();
            }

            else if (btnSubmit.Text == "Update")
            {
                //get ID for the Update
                string ID = txtID.Text.ToString();
                OracleCommand cmd = new OracleCommand("update teacher set Teacher_name = '" + name + "', email = '" + email + "' where Teacher_id = " + ID);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                btnSubmit.Text = "Button";
                teacherGridView.EditIndex = -1;
            }



            txtTeacherName.Text = "";
            txtEmail.Text = "";

            this.BindGrid();
            //studentGridView.EditIndex = -1;

        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            // get id for data update
            txtID.Text = this.teacherGridView.Rows[e.NewEditIndex].Cells[3].Text;
            txtTeacherName.Text = this.teacherGridView.Rows[e.NewEditIndex].Cells[4].Text.ToString().TrimStart().TrimEnd();
            txtEmail.Text = this.teacherGridView.Rows[e.NewEditIndex].Cells[5].Text.ToString().TrimStart().TrimEnd(); 

            btnSubmit.Text = "Update";
        }


        protected void OnSelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Session["id"] = this.teacherGridView.Rows[e.NewSelectedIndex].Cells[3].Text;
            Server.Transfer("teacher_module.aspx");
        }
    }
}