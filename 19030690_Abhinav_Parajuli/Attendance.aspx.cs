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
    public partial class Attendance : System.Web.UI.Page
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


            attendanceGridview.DataSource = dt;
            attendanceGridview.DataBind();

        }


        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            attendanceGridview.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(attendanceGridview.DataKeys[e.RowIndex].Values[0]);
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
            //studentGridView.EditIndex = -1;
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != attendanceGridview.EditIndex)
            {

                // (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";


            }
            //this.BindGrid();
            attendanceGridview.EditIndex = -1;

        }

        protected void onRowUpdating(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(attendanceGridview.DataKeys[e.RowIndex].Values[0]);
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
            attendanceGridview.EditIndex = -1;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            // insert code
            string attendance = txtattendance.Text.ToString();
            string student_id = studentDropdown.SelectedValue.ToString();
            string module_id = moduleDropdown.SelectedValue.ToString();





            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            if (btnSubmit.Text == "Button")
            {
                //OracleCommand cmd2 = new OracleCommand("SELECT MAX(TEACHER_ID) FROM TEACHER");
                //OracleCommand cmd3 = new OracleCommand("Insert into teacher_address(Teacher_id, address_id)Values('" + name + "','" + email + "')");



                OracleCommand update_attendance = new OracleCommand("UPDATE STUDENT_MODULE SET ATTENDANCE = '" + attendance + "' WHERE STUDENT_ID = '" + student_id +  "' AND MODULE_CODE = " + module_id );
                //OracleCommand cmd = new OracleCommand("update teacher set Teacher_name = '" + name + "', email = '" + email + "' where Teacher_id = " + ID);

                update_attendance.Connection = con;
                con.Open();
                update_attendance.ExecuteNonQuery();
                con.Close();
            }

            else if (btnSubmit.Text == "Update")
            {
                //get ID for the Update
                string ID = txtID.Text.ToString();
                OracleCommand update_attendance = new OracleCommand("UPDATE STUDENT_MODULE SET ATTENDANCE = '" + attendance + "' WHERE STUDENT_ID = '" + student_id + "' AND MODULE_ID = " + module_id );

                //OracleCommand cmd = new OracleCommand("update teacher set Teacher_name = '" + attendance + "', email = '" + attendance + "' where Teacher_id = " + ID);

                update_attendance.Connection = con;
                con.Open();
                update_attendance.ExecuteNonQuery();
                con.Close();
                btnSubmit.Text = "Button";
                attendanceGridview.EditIndex = -1;
            }



            txtattendance.Text = "";

            this.BindGrid();
            //studentGridView.EditIndex = -1;

        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            // get id for data update
            txtID.Text = this.attendanceGridview.Rows[e.NewEditIndex].Cells[2].Text;
            txtattendance.Text = this.attendanceGridview.Rows[e.NewEditIndex].Cells[3].Text.ToString().TrimStart().TrimEnd();
            btnSubmit.Text = "Update";
        }
    }
}