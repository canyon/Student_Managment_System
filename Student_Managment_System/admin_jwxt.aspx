<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_jwxt.aspx.cs" Inherits="Student_Managment_System.admin_jwxt" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <link type="text/css" rel="stylesheet" href="style/all_admin.css" />
        <style type="text/css">

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

                <div class="gv1">
                    学生：
                    <asp:Button ID="Button1" runat="server" Text="学生信息管理" OnClick="Button1_Click" />
                </div>

                <div class="gv2">
                    教师：
                    <asp:Button ID="Button3" runat="server" Text="教师信息管理" OnClick="Button3_Click" />
                </div>

                <div class="gv3">
                    课程：
                    <asp:Button ID="Button5" runat="server" Text="课程信息管理" OnClick="Button5_Click" />
                </div>

                <div class="gv4">
                    成绩：
                    <asp:Button ID="Button7" runat="server" Text="成绩信息管理" OnClick="Button7_Click" />
                </div>
            </div>
        </form>
    </body>

    </html>