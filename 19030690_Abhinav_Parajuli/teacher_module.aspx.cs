using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _19030690_Abhinav_Parajuli
{
    public partial class teacher_module : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            string teacher_id = Session["id"].ToString();
            Session.Remove("id");

            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"select T.TEACHER_NAME, T.TEACHER_ID, T.EMAIL, M.MODULE_NAME, M.CREDIT_HOUR
                             FROM TEACHER T 
                            inner join TEACHER_MODULE TM on TM.TEACHER_ID = T.TEACHER_ID
                            inner join MODULE M on M.MODULE_CODE = TM.MODULE_CODE 
                            WHERE TM.TEACHER_ID = " + teacher_id;
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("TeacherModule");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            TeacherModuleGridview.DataSource = dt;
            TeacherModuleGridview.DataBind();


        }
    }
}