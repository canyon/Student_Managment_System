<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Student_Managment_System.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <link type="text/css" rel="stylesheet" href="style/style.css" />
    <title>管理员登录</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="text-align: center;">
                <h1>学生信息管理系统</h1>
            </div>
            <div class="dowebok">
                <div class="logo"></div>

                <div class="form-item">
                    <asp:TextBox ID="username" runat="server" placeholder="管理员账号"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="username"
                        ErrorMessage="管理员账号不能为空！"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator CssClass="validator" ID="RegularExpressionValidator1" runat="server"
                        ControlToValidate="username"
                        ErrorMessage="请输入3位的管理员账号！"
                        EnableClientScript="true"
                        ValidationExpression="\d{3}"
                        Display="Dynamic">
                    </asp:RegularExpressionValidator>
                </div>

                <div class="form-item">
                    <asp:TextBox ID="password" runat="server" TextMode="Password" placeholder="密码"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="username"
                        ErrorMessage="密码不能为空！"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>


                <div class="form-item">
                    <asp:Button ID="submit" runat="server" Text="登 录" OnClick="submit_Click" />
                    <%--<button id="submit">登 录</button>--%>
                </div>

                <%--<div class="reg-bar">

                    <a class="reg" href="reg.aspx">立即注册</a>
                    <a class="forget" href="forget.aspx">忘记密码</a>
                </div>--%>
            </div>
        </div>
    </form>
</body>
</html>
