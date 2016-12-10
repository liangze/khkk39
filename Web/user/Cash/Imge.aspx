<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Imge.aspx.cs" Inherits="Web.user.Cash.Imge" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
            <h2><%=GetLanguage("ViewDocument")%><%--查看凭证--%></h2>
            <h6 style="text-align: center;">
                <span style="font-size: 21px;">
                    <asp:Literal ID="ltTitle" runat="server"></asp:Literal></span></h6>
            <div>&nbsp;</div>
         
            <div>&nbsp;</div>
            
            <div class="filter">
                <%--<asp:Literal ID="ltContent" runat="server"></asp:Literal>--%>
                <asp:Image ID="Image1"  runat="server" AlternateText = "您没有上传凭证" Width="100%" />
            </div>
        </div>
    </form>
</body>
</html>
