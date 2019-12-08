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
    public partial class teacher : System.Web.UI.Page
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["cs"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            Get_the_stu();
            InitGridView();
        }
        private void Get_the_stu()
        {
            conn.Open();
            Label1.Text = "教师";
            string s = string.Format("exec get_this_tea '{0}'", Session["username"].ToString());
            SqlCommand cmd = new SqlCommand(s, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Label2.Text = dr["id"].ToString();
                Label3.Text = dr["stu_name"].ToString();
            }
            conn.Close();
        }
        private void InitGridView()
        {
            string sql = string.Format("exec get_all_cour_tea '{0}'", Session["username"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "stu");
                GridView1.DataSource = ds.Tables["stu"];
                GridView1.DataBind();
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
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            InitGridView();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            InitGridView();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            InitGridView();
        }
    }
}
