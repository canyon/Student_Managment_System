using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_Managment_System
{
    public partial class admin : System.Web.UI.Page
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["cs"]);

        private void Alert(string msg)
        {
            Response.Write(string.Format("<script language=javascript>alert('{0}');</script>", msg));
        }

        private void UserLogin()
        {
            string user = username.Text;
            string pwd = password.Text;
            string sql_1 = string.Format("exec check_admin_id '{0}'", user);
            string sql_2 = string.Format("exec check_admin_passwd '{0}', '{1}'", user, pwd);
            SqlCommand cmd_1 = new SqlCommand(sql_1, conn);
            SqlCommand cmd_2 = new SqlCommand(sql_2, conn);
            try
            {
                conn.Open();
                if ((int)cmd_1.ExecuteScalar() == 0)
                {
                    Alert("管理员不存在！");
                }
                else
                {
                    if ((int)cmd_2.ExecuteScalar() == 0)
                    {
                        Alert("密码错误！");
                    }
                    else
                    {
                        Session["username"] = user;
                        Session["group"] = user.ToCharArray()[1].ToString();
                        Response.Redirect("admin_jwxt.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Alert(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            UserLogin();
        }
    }
}