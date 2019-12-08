<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Student_Managment_System.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <link type="text/css" rel="stylesheet" href="style/style.css" />
    <title>登录</title>
</head>
<body>
    <form id="form1" runat="server" >
        <div style="text-align: center;">
            <h1>学生信息管理系统</h1>
        </div>

        <div class="dowebok" aria-busy="True">
            <div class="logo"></div>
            <div class="form-item">
                <asp:TextBox ID="username" runat="server" placeholder="学工号"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="username"
                    ErrorMessage="学工号不能为空！"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator CssClass="validator" ID="RegularExpressionValidator1" runat="server"
                    ControlToValidate="username"
                    ErrorMessage="请输入10位的学工号！"
                    EnableClientScript="true"
                    ValidationExpression="\d{10}"
                    Display="Dynamic">
                </asp:RegularExpressionValidator>
            </div>

            <div class="form-item">
                <asp:TextBox ID="password" runat="server" TextMode="Password" placeholder="密码"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="password"
                    ErrorMessage="密码不能为空！"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>

            <div class="form-item">
                <asp:Button ID="submit" runat="server" Text="登 录" OnClick="submit_Click" />
                <%--<button id="submit">登 录</button>--%>
            </div>

            <div class="reg-bar">

                <%--<a class="reg" href="www.dlmu.edu.cn">看看海大</a>--%>
                <a class="forget" href="admin.aspx">管理员登录</a>
            </div>
        </div>

    </form>
</body>
</html>
