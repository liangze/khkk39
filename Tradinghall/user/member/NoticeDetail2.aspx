<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeDetail2.aspx.cs" Inherits="Tradinghall.user.member.NoticeDetail2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript">
        function back() {
            window.history.go(-1);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" class="stdform">
        <div class="center_content">
            <h2><%=GetLanguage("NewsBulletin")%><%--订单明细--%></h2>
            <h6 style="text-align: center;">
                <span style="font-size: 21px;">
                    <asp:Literal ID="ltTitle" runat="server"></asp:Literal></span></h6>
            <div>&nbsp;</div>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("ReleaseTime") %><!--发布时间-->：</label>
                        <span class="field">
                            <input name="txtPublishTime" type="text" id="txtPublishTime" runat="server" class="input_reg" disabled="disabled" />
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("Publisher")%><!--发布者-->：</label>
                        <span class="field">
                            <input name="txtPublisher" type="text" id="txtPublisher" runat="server" class="input_reg" disabled="disabled" />
                        </span>
                    </p>
                   
                </div>
            </div>
            <div>&nbsp;</div>
            <div class="filter">
                <asp:Literal ID="ltContent" runat="server"></asp:Literal>
            </div>
        </div>
    </form>
</body>
</html>
