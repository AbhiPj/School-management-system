using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string teacher_id = TeacherDropdown.SelectedValue.ToString();
                string module_code = ModuleDropdown.SelectedValue.ToString();

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                OracleConnection con = new OracleConnection(constr);

                if (btnSubmit.Text == "Button")
                {
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
                        OracleCommand insert_teacher_module = new OracleCommand("INSERT INTO TEACHER_MODULE(TEACHER_ID, MODULE_CODE)Values('" + teacher_id + "','" + module_code + "')");
                        insert_teacher_module.Connection = con;
                        con.Open();
                        insert_teacher_module.ExecuteNonQuery();
                        con.Close();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('added')", true);

                    }



                    //studentGridView.EditIndex = -1;

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')" , true);
            }           
            }

        }
    } 
