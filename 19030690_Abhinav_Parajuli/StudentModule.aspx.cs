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
            cmd.CommandText = @"SELECT BERKELEY_COLLEGE.STUDENT.STUDENT_ID, BERKELEY_COLLEGE.STUDENT.STUDENT_NAME, BERKELEY_COLLEGE.MODULE.MODULE_CODE, BERKELEY_COLLEGE.MODULE.MODULE_NAME FROM BERKELEY_COLLEGE.STUDENT INNER JOIN 
                                BERKELEY_COLLEGE.STUDENT_MODULE ON BERKELEY_COLLEGE.STUDENT.STUDENT_ID = 
                                BERKELEY_COLLEGE.STUDENT_MODULE.STUDENT_ID INNER JOIN BERKELEY_COLLEGE.MODULE ON BERKELEY_COLLEGE.STUDENT_MODULE.MODULE_CODE = BERKELEY_COLLEGE.MODULE.MODULE_CODE";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("StudentAttendance");

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
            int student_id = Convert.ToInt32(attendanceGridview.DataKeys[e.RowIndex].Values[0]);
            int module_code = Convert.ToInt32(attendanceGridview.DataKeys[e.RowIndex].Values[2]);

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM STUDENT_MODULE WHERE STUDENT_ID = '"+ student_id +"' AND MODULE_CODE = '" + module_code + "' "))
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


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // insert code
                string student_id = studentDropdown.SelectedValue.ToString();
                string module_id = moduleDropdown.SelectedValue.ToString();





                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                OracleConnection con = new OracleConnection(constr);

                if (btnSubmit.Text == "Button")
                {
                    OracleCommand cmd = new OracleCommand("INSERT INTO STUDENT_MODULE(STUDENT_ID, MODULE_CODE)Values('" + student_id + "','" + module_id + "')");
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                this.BindGrid();
            }
            catch(Exception ex)
            {

            }


        }
    }
}