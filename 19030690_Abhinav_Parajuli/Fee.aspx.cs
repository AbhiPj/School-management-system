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
    public partial class Fee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string student_id = StudentDropdown.SelectedValue.ToString();
            string department_id = DepartmentDropdown.SelectedValue.ToString();
            string fee_status = FeeStatusDropdown.SelectedValue.ToString();





            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            if (btnSubmit.Text == "Button")
            {
                OracleCommand cmd = new OracleCommand("INSERT INTO FEE(STUDENT_ID, DEPARTMENT_ID, FEE_STATUS)Values('" + student_id + "','" + department_id + "' , '" + fee_status + "')");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

        }
    }
}