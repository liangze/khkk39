<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doChangePwdloginapy.aspx.cs" Inherits="Web.user.member.doChangePwdloginapy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server" class="stdform">
    <div class="right_content">
        <h2><%=GetLanguage("PayPasswordgai")%><%--更改支付密码--%></h2>
        <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("OldPaymentpPassword")%>：
                        </label>
                        <div class="field">
                            <input name="txtSecondPwd" id="txtSecondPwd" class="input_reg" runat="server" type="password" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("NewPaymentpPassword")%>：
                        </label>
                        <div class="field">
                            <input name="txtNewSecondPwd" id="txtNewSecondPwd" class="input_reg" runat="server" type="password" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("ConfirmPayPassword")%>：
                        </label>
                        <div class="field">
                            <input name="txtRPSecondPwd" id="txtRPSecondPwd" class="input_reg" runat="server" type="password" />
                        </div>
                    </div>
                    <div class="action">
                        <asp:Button ID="btnSecond" runat="server" class="btn" OnClick="btnSecond_Click" />
                    </div>
                </div>
            </div>
    
    </div>
    </form>
</body>
</html>
