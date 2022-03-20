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
    public partial class Assignment : System.Web.UI.Page
    {
        private OracleConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string department_id = DepartmentDropdown.SelectedValue.ToString();
                string assignment_type = AssignmentType.Text;

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                OracleConnection con = new OracleConnection(constr);

                if (btnSubmit.Text == "Button")
                {
                    OracleCommand cmd = new OracleCommand("INSERT INTO Assignment(ASSIGNMENT_TYPE, DEPARTMENT_ID)Values('" + assignment_type + "','" + department_id + "')");
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                else if (btnSubmit.Text == "Update")
                {
                    //get ID for the Update
                    string ID = txtID.Text.ToString();
                    OracleCommand cmd = new OracleCommand("update assignment set assignment_type = '" + assignment_type + "', Department_ID = '" + department_id + "' where assignment_Id = " + ID);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    btnSubmit.Text = "Button";
                    assignmentGridview.EditIndex = -1;
                }
                this.BindGrid();
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')" , true);

            }

        }

        private void BindGrid()
        {
            string department_id = DepartmentDropdown.SelectedValue.ToString();
            string assignment_type = AssignmentType.Text;

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                OracleCommand cmd = new OracleCommand();
                OracleConnection con = new OracleConnection(constr);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = @"SELECT BERKELEY_COLLEGE.ASSIGNMENT.ASSIGNMENT_ID, BERKELEY_COLLEGE.ASSIGNMENT.ASSIGNMENT_TYPE, BERKELEY_COLLEGE.DEPARTMENT.DEPARTMENT_ID,BERKELEY_COLLEGE.DEPARTMENT.DEPARTMENT_NAME
                                FROM BERKELEY_COLLEGE.ASSIGNMENT INNER JOIN
                                BERKELEY_COLLEGE.DEPARTMENT ON BERKELEY_COLLEGE.ASSIGNMENT.DEPARTMENT_ID = BERKELEY_COLLEGE.DEPARTMENT.DEPARTMENT_ID";
                cmd.CommandType = CommandType.Text;

                DataTable dt = new DataTable("assignment");

                using (OracleDataReader sdr = cmd.ExecuteReader())
                {
                    dt.Load(sdr);
                }

                con.Close();

            assignmentGridview.DataSource = dt;
            assignmentGridview.DataBind();

        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            // get id for data update
            txtID.Text = this.assignmentGridview.Rows[e.NewEditIndex].Cells[2].Text;
            AssignmentType.Text = this.assignmentGridview.Rows[e.NewEditIndex].Cells[3].Text.ToString().TrimStart().TrimEnd(); 
            DepartmentDropdown.SelectedValue = this.assignmentGridview.Rows[e.NewEditIndex].Cells[4].Text;
            btnSubmit.Text = "Update";
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(assignmentGridview.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM ASSIGNMENT WHERE ASSIGNMENT_ID =" + ID))
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

    }
}