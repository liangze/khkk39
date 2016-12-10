<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="finddoChangePwdloginapy.aspx.cs" Inherits="Web.user.member.finddoChangePwdloginapy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
  
</head>
<body>
   <div class="center_content">
       <div class="left_content">
        </div>
        <div class="right_content">
            <h2>
               <%=GetLanguage("RecoverPaypassword") %> <%--找回支付密码--%>

            </h2>
    	 
     	 <p></p>
            <form name="pwd" class="stdform" runat="server">
                <div class="row-fluid">
                    <div class="span6">
                        <div class="control-group">
                            <label for="memid"> 
                               <%=GetLanguage("ContactPhone")%> <%--手机号码--%>/<%=GetLanguage("EMail") %><%--邮箱--%>:
                            </label>
                            <div class="field">
                                <input name="txtPhonMailNum" id="txtPhonMailNum" class="input_reg" runat="server"/><%--手机号码或者邮箱--%>
                             	   		
                            </div>
                            <div class="control-group">
                            <label for="memid"> 
                              <%=GetLanguage("NewPaymentpPassword")%>  <%--新支付密码--%>:
                            </label>
                            <div class="field">
                                <input name="txtNewSecondPwd" id="txtNewSecondPwd" class="input_reg" runat="server" type="password" /><%--新支付密码--%>
                              	   		
                            </div>
                        </div>
                            <div class="control-group">
                            <label for="memid"> 
                                <%=GetLanguage("ConfirmPayPassword")%><%--确认密码--%>:
                            </label>
                            <div class="field">
                                <input name="txtRPSecondPwd" id="txtRPSecondPwd" class="input_reg" runat="server" type="password" /><%--确认新支付密码--%>
                              	   		
                            </div>
                        </div>
                        </div>
                        <div class="action">
                            <asp:Button ID="btnSecond" runat="server" class="btn" OnClick="btnSecond_Click" />
                        </div>
                    </div>
                </div>
            </form>
        </div>
   </div>
</body>
</html>
