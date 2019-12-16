using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_Managment_System
{
    public partial class admin_score : System.Web.UI.Page
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["cs"]);

        private string sql = "exec get_score_detail";

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

        private void InitGridView4()
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "sco");
                GridView4.DataSource = ds.Tables["sco"];
                GridView4.DataBind();
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

        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            InitGridView4();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            InitGridView4();
        }

        protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            conn.Open();
            string key = GridView4.DataKeys[e.RowIndex]["课程号"].ToString();
            string key1 = GridView4.DataKeys[e.RowIndex]["学号"].ToString();
            string sql = "delete from score where cour_id = \'" + key + "\'" + "and stu_id = \'" + key1 + "\'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlTransaction tran = conn.BeginTransaction();
            cmd.Transaction = tran;
            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                Lable4.Text = "删除成功！";
            }
            catch (Exception ex)
            {
                tran.Rollback();
                Lable4.Text = "删除失败！";
            }
            finally
            {
                conn.Close();
            }
            InitGridView4();
        }

        protected void GridView4_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView4.EditIndex = e.NewEditIndex;
            InitGridView4();
        }

        protected void GridView4_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string cour_id = ((TextBox)GridView4.Rows[e.RowIndex].Cells[1].Controls[0]).Text.Trim();
            string stu_id = ((TextBox)GridView4.Rows[e.RowIndex].Cells[4].Controls[0]).Text.Trim();
            string score = ((TextBox)GridView4.Rows[e.RowIndex].Cells[6].Controls[0]).Text.Trim();
            string sql = string.Format("exec update_gv4 '{0}', '{1}', '{2}'", cour_id, stu_id, score);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            cmd.Transaction = tran;
            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                Lable4.Text = "修改成功！";
            }
            finally
            {
                conn.Close();
                GridView4.EditIndex = -1;
                InitGridView4();
            }
        }

        protected void GridView4_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView4.EditIndex = -1;
            InitGridView4();
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_jwxt.aspx");
        }
    }
}