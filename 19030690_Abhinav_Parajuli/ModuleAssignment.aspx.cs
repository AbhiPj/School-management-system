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
    public partial class ModuleAssignment : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT BERKELEY_COLLEGE.STUDENT.STUDENT_ID, BERKELEY_COLLEGE.STUDENT.STUDENT_NAME, BERKELEY_COLLEGE.MODULE.MODULE_CODE, BERKELEY_COLLEGE.MODULE.MODULE_NAME, BERKELEY_COLLEGE.ASSIGNMENT.ASSIGNMENT_ID, BERKELEY_COLLEGE.ASSIGNMENT.ASSIGNMENT_TYPE, BERKELEY_COLLEGE.MODULE_ASSIGNMENT.GRADE, BERKELEY_COLLEGE.MODULE_ASSIGNMENT.STATUS FROM BERKELEY_COLLEGE.STUDENT INNER JOIN BERKELEY_COLLEGE.MODULE_ASSIGNMENT ON BERKELEY_COLLEGE.STUDENT.STUDENT_ID = BERKELEY_COLLEGE.MODULE_ASSIGNMENT.STUDENT_ID INNER JOIN BERKELEY_COLLEGE.MODULE ON BERKELEY_COLLEGE.MODULE_ASSIGNMENT.MODULE_CODE = BERKELEY_COLLEGE.MODULE.MODULE_CODE INNER JOIN BERKELEY_COLLEGE.ASSIGNMENT ON BERKELEY_COLLEGE.MODULE_ASSIGNMENT.ASSIGNMENT_ID = BERKELEY_COLLEGE.ASSIGNMENT.ASSIGNMENT_ID";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable("ModuleAssignment");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();
            mdGridview.DataSource = dt;
            mdGridview.DataBind();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            // insert code
            string assignment = AssignmentDropdown.SelectedValue.ToString();
            string student = StudentDropdown.SelectedValue.ToString();
            string module = ModuleDropdown.SelectedValue.ToString();
            string grade = GradeDropdown.SelectedValue.ToString();
            string status = "Pass";
            if (grade == "F")
            {
                status = "Fail";
            }
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            if (btnSubmit.Text == "Button")
            {
                OracleCommand cmd = new OracleCommand("Insert into module_assignment(Assignment_ID, Student_ID, Module_Code,grade,status)" +
                    "Values('" + assignment + "','" + student + "','" + module + "','" + grade + "','" + status + "')");

                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

            else if (btnSubmit.Text == "Update")
            {
                //get ID for the Update
                /*string ID = txtID.Text.ToString();
                OracleCommand cmd = new OracleCommand("UPDATE ADDRESS set ADDRESS = '" + address + "' where ADDRESS_ID = " + ID);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                btnSubmit.Text = "Button";
                mdGridview.EditIndex = -1;*/
            }

            this.BindGrid();
            //studentGridView.EditIndex = -1;

        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int StudentID = Convert.ToInt32(mdGridview.DataKeys[e.RowIndex].Values[0]);
            string ModuleCode = Convert.ToString(mdGridview.DataKeys[e.RowIndex].Values[2]);
            int AssignmentID = Convert.ToInt32(mdGridview.DataKeys[e.RowIndex].Values[4]);

            string constr = ConfigurationManager.ConnectionStrings["BerkeleyCollege"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM MODULE_ASSIGNMENT WHERE STUDENT_ID = '" + StudentID + "' " +
                    "AND ASSIGNMENT_ID = '" + AssignmentID + "' AND MODULE_CODE = '" + ModuleCode + "' "))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
        }

    }
}