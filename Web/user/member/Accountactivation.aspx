<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accountactivation.aspx.cs" Inherits="Web.user.member.Accountactivation" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link href="../../css/style.css" rel="stylesheet" type="text/css" media="all" />

    <%-- <script>
	function focusAndSelect(obj) {
		obj.focus();
		obj.select();
	}
</script>--%>
    <script type="text/javascript">


        function doSubmit(thisform) {

            if (thisform.OldPin.value == "") {
                focusAndSelect(thisform.OldPin);
                alert("Enter old ePin.");
                return false;
            }

            if (thisform.NewPin.value == "") {
                focusAndSelect(thisform.NewPin);
                alert("请输入新的二级密码.");
                return false;
            }

            if (thisform.NewPin.value.length < 5) {
                focusAndSelect(thisform.NewPin);
                alert("新二级密码需5字位以上");
                return false;
            }

            if (thisform.ConfirmPin.value == "") {
                focusAndSelect(thisform.ConfirmPin);
                alert("Enter new retype ePin.");
                return false;
            }

            if (thisform.NewPin.value != thisform.ConfirmPin.value) {
                focusAndSelect(thisform.ConfirmPin);
                alert("新二级密码不符合");
                return false;
            }

            return true;
        }

    </script>
    <title>MfcClub</title>
</head>
<body>

    <div class="center_content">

        <div class="left_content">
            <div class="sidebarmenu">
            </div>
        </div>

        <div class="right_content" style="height:800px;">
            <h2>
                <%=GetLanguage("AccountActivation")%><%--账户激活--%>
            </h2>
            <form name="pwd" class="stdform" runat="server">

                <div class="row-fluid">
                    <div class="span6">
                        <div class="control-group">
                            <label for="memid">
                                <%=GetLanguage("Accountname")%><%-- 账户名--%>：
                            </label>
                            <div class="field">
                                <input name="txtUserCode" type="text" id="txtUserCode" runat="server" class="input_reg" disabled="disabled" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="memid">
                                <%=GetLanguage("MembershipLevels")%><%--会员级别--%>：
                            </label>
                            <div class="field">
                                <input name="LevelName" type="text" id="LevelName" runat="server" class="input_reg" disabled="disabled" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="memid">
                                <%=GetLanguage("RegistrationAmount")%><%--注册金额--%>：
                            </label>
                            <div class="field">
                                <input name="txtRegMoney" type="text" id="txtRegMoney" runat="server" class="input_reg" disabled="disabled" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="memid">
                                <%=GetLanguage("Registeredcurrency")%>  <%--注册点数--%>：
                            </label>
                            <div class="field">
                                <input name="txtRegisterPoint" type="text" id="txtRegisterPoint" runat="server" class="input_reg" disabled="disabled" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="memid">
                                <%=GetLanguage("ActivationPoints")%> <%--激活点数--%>：
                            </label>
                            <div class="field">
                                <input name="txtActivationPoint" type="text" id="txtActivationPoint" runat="server" class="input_reg" disabled="disabled" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="memid">
                                <%=GetLanguage("ActivationState")%> <%--激活状态--%>：
                            </label>
                            <div class="field">
                                <input name="txtActivationState" type="text" id="txtActivationState" runat="server" class="input_reg" disabled="disabled" />
                            </div>
                        </div>
                        <div class="action">

                            <asp:Button ID="Button1" runat="server" Text="" OnClick="Button_Click" />
                        </div>
                    </div>
                </div>
            </form>
        </div>

    </div>


</body>
</html>
