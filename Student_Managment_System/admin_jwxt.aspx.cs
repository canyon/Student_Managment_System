using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_Managment_System
{
    public partial class admin_jwxt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Get_the_stu();
            }
            else
            {

            }
        }
        private void Get_the_stu()
        {
            Label1.Text = "管理员";
            Label2.Text = Session["username"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin_student.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin_teacher.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin_course.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin_score.aspx");
        }
    }
}