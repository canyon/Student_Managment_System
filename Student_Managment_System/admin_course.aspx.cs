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
    public partial class admin_course : System.Web.UI.Page
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["cs"]);
        private string sql = "exec get_course_detail";
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



        private void InitGridView3()
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "cour");
                GridView3.DataSource = ds.Tables["cour"];
                GridView3.DataBind();
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

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            InitGridView3();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            InitGridView3();
        }


        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            conn.Open();
            string key = GridView3.DataKeys[e.RowIndex]["课程号"].ToString();
            string sql = "delete from course where cour_id = \'" + key + "\'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlTransaction tran = conn.BeginTransaction();
            cmd.Transaction = tran;
            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                Lable3.Text = "删除成功！";
            }
            catch (Exception ex)
            {
                tran.Rollback();
                Lable3.Text = "删除失败！";
            }
            finally
            {
                conn.Close();
            }
            InitGridView3();
        }

        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView3.EditIndex = e.NewEditIndex;
            InitGridView3();
        }

        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string tea_id = ((TextBox)GridView3.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string tea_name = ((TextBox)GridView3.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string cour_id = ((TextBox)GridView3.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string sql = string.Format("exec update_gv3 '{0}', '{1}', '{2}'", cour_id, tea_id, tea_name);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            cmd.Transaction = tran;
            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                Lable3.Text = "修改成功！";
                GridView3.EditIndex = -1;
                InitGridView3();
            }
            catch (Exception)
            {
                tran.Rollback();
                Lable3.Text = "修改失败！";
            }
            finally
            {
                conn.Close();
            }
        }

        protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView3.EditIndex = -1;
            InitGridView3();
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_jwxt.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            sql = string.Format("exec get_cour_by_id '{0}'", TextBox1.Text.Trim());
            InitGridView3();
        }
    }
}