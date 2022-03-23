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
    public partial class Add_teacher_module : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT BERKELEY_COLLEGE.TEACHER.TEACHER_ID, BERKELEY_COLLEGE.TEACHER.TEACHER_NAME, BERKELEY_COLLEGE.MODULE.MODULE_CODE, BERKELEY_COLLEGE.MODULE.MODULE_NAME, BERKELEY_COLLEGE.MODULE.CREDIT_HOUR 
                                FROM BERKELEY_COLLEGE.TEACHER INNER JOIN BERKELEY_COLLEGE.TEACHER_MODULE ON BERKELEY_COLLEGE.TEACHER.TEACHER_ID = 
                                BERKELEY_COLLEGE.TEACHER_MODULE.TEACHER_ID INNER JOIN BERKELEY_COLLEGE.MODULE ON BERKELEY_COLLEGE.TEACHER_MODULE.MODULE_CODE = 
                                BERKELEY_COLLEGE.MODULE.MODULE_CODE";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("TeacherModule");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string teacher_id = TeacherDropdown.SelectedValue.ToString();
                string module_code = ModuleDropdown.SelectedValue.ToString();

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                OracleConnection con = new OracleConnection(constr);


                    //Getting all Teacher Id and module_code for validation
                    OracleCommand all_id = new OracleCommand("SELECT TEACHER_ID,MODULE_CODE FROM TEACHER_MODULE");
                    all_id.Connection = con;
                    con.Open();
                    OracleDataReader odr = all_id.ExecuteReader();
                    odr.Read();
                    List<string> teacherList = new List<string>();
                    List<string> moduleList = new List<string>();

                    if (odr.HasRows)
                    {
                        while (odr.Read())
                        {
                            teacherList.Add(odr.GetString(0));
                            moduleList.Add(odr.GetString(1));

                        }
                    }
                    con.Close();
                    


                    /*if (!teacherList.Contains(teacher_id) && !moduleList.Contains(module_code))
                    {
                        //insert into bridge entity

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('already exists')", true);
                    }*/



                    int c = 0;
                    bool exists = false;
                    foreach (string tlist in teacherList)
                    {
                        if(tlist == teacher_id)
                        {
                                if (tlist == teacher_id && moduleList[c] == module_code)
                                {
                                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('nice')", true);
                                exists = true;
                                }
                        }
                        c = c + 1;

                    }
                    if (exists)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('exists')", true);

                    }
                    else
                    {
                        OracleCommand insert_teacher_module = new OracleCommand("INSERT into TEACHER_MODULE(Teacher_ID, MODULE_CODE)Values('" + teacher_id + "','" + module_code + "')");
                    insert_teacher_module.Connection = con;
                        con.Open();
                        insert_teacher_module.ExecuteNonQuery();
                        con.Close();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('added')", true);
                    }

                this.BindGrid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')" , true);
            }           
            }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            int ModuleC = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[2]);

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM TEACHER_MODULE WHERE TEACHER_ID = '"+ ID + "' AND MODULE_CODE = '" + ModuleC +  "'"))
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

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = -1;


            // get id for data update

            TeacherDropdown.SelectedValue = this.GridView1.Rows[e.NewEditIndex].Cells[2].Text;
            ModuleDropdown.SelectedValue = this.GridView1.Rows[e.NewEditIndex].Cells[4].Text;
            btnSubmit.Text = "Update";

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {

                // (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";


            }
            this.BindGrid();
            GridView1.EditIndex = -1;

        }



    }
} 
