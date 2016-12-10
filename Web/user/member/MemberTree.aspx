<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberTree.aspx.cs" Inherits="Web.user.member.MemberTree" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <%-- <link href="../../css/style.css" rel="stylesheet" type="text/css" media="all" />--%>
    <link rel="stylesheet" type="text/css" href="../../style/base.css" />
    <link rel="stylesheet" type="text/css" href="../../style/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../../style/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../../Scripts/Common.js"></script>
    <script src="../../Scripts/main-layout.js" type="text/javascript"></script>
    <script src="../../JS/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="../../JS/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../JS/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../JS/jquery.ui.mouse.js" type="text/javascript"></script>
    <script src="../../JS/jquery.ui.draggable.js" type="text/javascript"></script>
    <style type="text/css">
        #draggable {
            padding: 0.5em;
            float: left;
            margin: 0 10px 10px 0;
            border: none;
        }

        .div1 {
            float: left;
            margin: 10px;
            margin-left: 3px;
            font-size: 11px;
            color: #fff;
            margin-right: 3px;
            width: 66px;
            background-color: #2C8025;
            text-align: center;
            height: 28px;
            vertical-align: middle;
        }
    </style>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#draggable").draggable({ distance: 20 });
        });
    </script>

</head>
<body>

    <div class="center_content">

        <div class="right_content">
            <h2><%=GetLanguage("Allstructure")%><%--全体会员列表--%>
            </h2>
            <p />
            <p></p>
            <form id="form2" runat="server">
                <div class="filter">
                    <div class="row-fluid">
                        <p class="span4">
                            <label>
                                <%=GetLanguage("UserName")%><%--用户名称--%> :
                            </label>
                            <span class="field">
                                <asp:TextBox ID="txtUserCode" tip="输入会员编号" runat="server"></asp:TextBox>
                            </span>
                        </p>
                        <p class="span4">
                           
                            <asp:Button ID="btnSearch" runat="server" Text="查看" class="btn" OnClick="btnSearch_Click" />
                            <asp:Button ID="btnMy" runat="server" Text="我的系谱图" class="btn" OnClick="btnMy_Click" />
                            <asp:Button ID="Button1" runat="server" Text="上一级" class="btn" OnClick="Button1_Click" />&nbsp;&nbsp;
                            <asp:Button ID="Button2" runat="server" Text="下一级" class="btn" OnClick="Button2_Click" />&nbsp;&nbsp;
                        </p>


                    </div>
                </div>

                <table cellspacing="0" cellpadding="0" width="800" border="0">
                    <tr>
                        <td width="45"><b><%=GetLanguage("Explain")%><%--说明--%> : </b>&nbsp;</td>

                        <td width="20"><%=GetLanguage("Notactive")%><%--未激活--%></td>
                        <td width="10">
                            <img src='../../images/node_inactive.gif'></td>


                        <td width="20">VIP1 <%--<%=GetLanguage("stars")%>--%><%--1星级--%></td>
                        <td width="10">
                            <img src='../../images/icon1.png'></td>



                        <td width="20">VIP2 <%-- <%=GetLanguage("stars")%>--%><%--2星级--%></td>
                        <td width="10">
                            <img src='../../images/icon3.png'></td>


                        <td width="20">VIP3 <%--<%=GetLanguage("stars")%>--%><%--3星级--%></td>
                        <td width="10">
                            <img src='../../images/icon2.png'></td>


                        <td width="20">VIP4 <%--<%=GetLanguage("stars")%>--%><%--4星级--%></td>
                        <td width="10">
                            <img src='../../images/icon4.png'></td>


                        <td width="20">VIP5 <%--<%=GetLanguage("stars")%>--%><%--5星级--%></td>
                        <td width="10">
                            <img src='../../images/icon5.png'></td>


                        <td width="20">VIP6 <%--<%=GetLanguage("stars")%>--%><%--6星级--%></td>
                        <td width="10">
                            <img src='../../images/icon6.png'></td>

                        <td width="20"><%=GetLanguage("Emptyunits")%><%--空单位--%></td>
                        <td width="10">
                            <img src='../../images/node_open.gif'></td>
                    </tr>
                </table>
                <div class="dataTable" style="overflow: auto;">
                    <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
                </div>
            </form>
        </div>
        <!--end of right content-->

    </div>
    <!--end of center content-->

</body>
</html>
