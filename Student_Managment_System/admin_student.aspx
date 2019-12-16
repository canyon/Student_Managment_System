<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_student.aspx.cs" Inherits="Student_Managment_System.admin_student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <link type="text/css" rel="stylesheet" href="style/all_admin.css" />
        <style type="text/css">            
            .gv1,
            .gv2 {
                position: absolute;
                top: 20%;
                width: 1063px;
                left: 0px;
            }
            
            .gv3,
            .gv4 {
                position: absolute;
                top: 60%;
                width: 500px;
            }
            
            .gv2,
            .gv4 {
                left: 40%;
            }
            
            .gv22 {}
            
            .gv21 {}
            
            .gv12 {}
            
            .gv11 {}
        </style>
        <title>管理员</title>
    </head>

    <body>
        <form id="form1" runat="server">
            <div style="text-align: center;">
                <h1>学生信息管理系统</h1>
            </div>
            <div>

                <div style="text-align: center;">
                    身份：
                    <asp:Label ID="Label1" runat="server" Text="NULL"></asp:Label>
                    工号：
                    <asp:Label ID="Label2" runat="server" Text="NULL"></asp:Label>
                </div>
                <br />

                <asp:Button ID="home" runat="server" Text="回到主页" OnClick="home_Click" />

                <div class="gv1">
                    <asp:Label ID="Lable1" runat="server" Text="Label"></asp:Label>
                    学生：
                    <asp:Button ID="Button1" runat="server" Text="输出学生表" OnClick="Button1_Click" />
                    查找：<asp:Button ID="Button2" runat="server" Text="查找学生" OnClick="Button2_Click" />
                    <asp:TextBox ID="TextBox1" runat="server" placeholder="请输入学号"></asp:TextBox>
                        <asp:GridView Width="1054px" 
                            CssClass="gv11" 
                            ID="GridView1" runat="server" 
                            AllowPaging="true" 
                            OnPageIndexChanging="GridView1_PageIndexChanging" 
                            OnRowDeleting="GridView1_RowDeleting" 
                            OnRowEditing="GridView1_RowEditing" 
                            OnRowUpdating="GridView1_RowUpdating" 
                            OnRowCancelingEdit="GridView1_RowCancelingEdit">
                            <Columns>
                                <asp:CommandField ShowDeleteButton="true" ShowEditButton="true" HeaderText="操作" />

                            </Columns>

                            <PagerTemplate>
                                当前第:
                                <%--//((GridView)Container.NamingContainer)就是为了得到当前的控件--%>
                                    <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                    页/共:
                                    <%--//得到分页页面的总数--%>
                                        <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                        页
                                        <%--//如果该分页是首分页，那么该连接就不会显示了.同时对应了自带识别的命令参数CommandArgument--%>
                                            <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page" Visible='<%#((GridView)Container.NamingContainer).PageIndex != 0 %>'>首页</asp:LinkButton>
                                            <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'>上一页</asp:LinkButton>
                                            <%--//如果该分页是尾页，那么该连接就不会显示了--%>
                                                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
                                                <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
                                                转到第
                                                <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
                                                <%--//这里将CommandArgument即使点击该按钮e.newIndex 值为3 --%>
                                                    <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2" CommandName="Page" Text="GO" />
                            </PagerTemplate>
                        </asp:GridView>

                </div>

            </div>
        </form>
    </body>

    </html>