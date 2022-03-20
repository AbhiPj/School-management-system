using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using Oracle.ManagedDataAccess.Client;


namespace _19030690_Abhinav_Parajuli
{
    public partial class Students : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT STUDENT_ID, STUDENT_NAME, STUDENT_ADDRESS FROM STUDENT";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("student");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            studentGridView.DataSource = dt;
            studentGridView.DataBind();

        }


        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            studentGridView.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(studentGridView.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM student WHERE student_Id =" + ID))
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
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != studentGridView.EditIndex)
            {
                
               // (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";


            }
            //this.BindGrid();
            studentGridView.EditIndex = -1;

        }

        protected void onRowUpdating(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(studentGridView.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM student WHERE student_Id =" + ID))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
            studentGridView.EditIndex = -1;
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            // insert code
            string name = txtname.Text.ToString();
            string address = txtaddress.Text.ToString();
            string module_code = moduleDropdown.SelectedValue.ToString();
            



            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            if (btnSubmit.Text == "Button")
            {
                OracleCommand cmd = new OracleCommand("Insert into student(Student_Name, Student_Address)Values('" + name + "','" + address + "')");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                OracleCommand get_module_id = new OracleCommand("SELECT MAX(STUDENT_ID) FROM STUDENT");
                get_module_id.Connection = con;
                con.Open();
                OracleDataReader dr2 = get_module_id.ExecuteReader();
                dr2.Read();
                string student_id = dr2.GetString(0);
                con.Close();


                OracleCommand insert_student_module = new OracleCommand("INSERT INTO STUDENT_MODULE(STUDENT_ID, MODULE_CODE)Values('" + student_id + "','" + module_code + "')");
                insert_student_module.Connection = con;
                con.Open();
                insert_student_module.ExecuteNonQuery();
                con.Close();

            }

            else if (btnSubmit.Text == "Update")
            {
                //get ID for the Update
                string ID = txtID.Text.ToString();
                OracleCommand cmd = new OracleCommand("update student set Student_name = '" + name + "', Student_address = '" + address + "' where Student_Id = " + ID);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                btnSubmit.Text = "Button";
                studentGridView.EditIndex = -1;
            }



            txtname.Text = "";
            txtaddress.Text = "";

            this.BindGrid();
            //studentGridView.EditIndex = -1;

        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            // get id for data update
            txtID.Text = this.studentGridView.Rows[e.NewEditIndex].Cells[2].Text;
            txtname.Text = this.studentGridView.Rows[e.NewEditIndex].Cells[3].Text.ToString().TrimStart().TrimEnd(); // (row.Cells[2].Controls[0] as TextBox).Text;
            txtaddress.Text = this.studentGridView.Rows[e.NewEditIndex].Cells[4].Text;
            btnSubmit.Text = "Update";
            //studentGridView.EditIndex = -1;

            // For foreging key
            //string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //OracleCommand cmd = new OracleCommand();
            //OracleConnection con = new OracleConnection(constr);
            //con.Open();
            //cmd.Connection = con;
            //cmd.CommandText = "select FieldValue,FieldName from setupinfo where Name = 'Gender'";
            //cmd.CommandType = CommandType.Text;

            //DataTable dt = new DataTable("Setup");

            //using (OracleDataReader sdr = cmd.ExecuteReader())
            //{
            //    dt.Load(sdr);
            //}

            //con.Close();

            //ddlGender.DataSource = dt;
            //ddlGender.DataTextField = "FieldName";
            //ddlGender.DataValueField = "FieldValue";
            //ddlGender.DataBind();

            // end foreign key

            // ddlGender.Items.FindByValue(this.gvAuthor.Rows[e.NewEditIndex].Cells[3].Text).Selected = true;





        }
    }
}