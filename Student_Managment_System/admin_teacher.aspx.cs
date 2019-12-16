using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_Managment_System
{
    public partial class admin_teacher : System.Web.UI.Page
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["cs"]);
        private string sql = "exec get_tea_detail";

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

        private void InitGridView2()
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "tea");
                GridView2.DataSource = ds.Tables["tea"];
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // 得到该控件
            GridView theGrid = sender as GridView;
            int newPageIndex = 0;
            if (e.NewPageIndex == -3)
            {
                //点击了Go按钮
                TextBox txtNewPageIndex = null;

                //GridView较DataGrid提供了更多的API，获取分页块可以使用BottomPagerRow 或者TopPagerRow，当然还增加了HeaderRow和FooterRow
                GridViewRow pagerRow = theGrid.BottomPagerRow;

                if (pagerRow != null)
                {
                    //得到text控件
                    txtNewPageIndex = pagerRow.FindControl("txtNewPageIndex") as TextBox;
                }
                if (txtNewPageIndex != null)
                {
                    //得到索引
                    newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
                }
            }
            else
            {
                //点击了其他的按钮
                newPageIndex = e.NewPageIndex;
            }
            //防止新索引溢出
            newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
            newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;

            //得到新的值
            theGrid.PageIndex = newPageIndex;

            //重新绑定
            InitGridView2();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            InitGridView2();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            conn.Open();
            string key = GridView2.DataKeys[e.RowIndex]["学号"].ToString();
            string sql = "delete from teacher where tea_id = \'" + key + "\'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlTransaction tran = conn.BeginTransaction();
            cmd.Transaction = tran;
            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                Lable2.Text = "删除成功！";
            }
            catch (Exception)
            {
                tran.Rollback();
                Lable2.Text = "删除失败！已回滚！";
            }
            finally
            {
                conn.Close();
            }
            InitGridView2();
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            InitGridView2();
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            InitGridView2();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            sql = string.Format("exec get_tea_by_id '{0}'", TextBox1.Text.Trim());
            InitGridView2();
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_jwxt.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            InitGridView2();
        }
    }
}