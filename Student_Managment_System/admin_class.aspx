<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_class.aspx.cs" Inherits="Student_Managment_System.admin_class" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <style type="text/css">
            * {
                margin: 0;
                padding: 0;
            }
            
            html {
                height: 100%;
            }
            
            body {
                height: 100%;
                background: #fff url(style/images/Eagle&Waterfall.jpg) 50% 50% no-repeat;
                background-size: cover;
            }
           
            .gv12 {}
           
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


        </div>
    </form>
</body>
</html>
