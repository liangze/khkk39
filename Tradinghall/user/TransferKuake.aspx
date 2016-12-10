<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferKuake.aspx.cs" Inherits="Tradinghall.user.TransferKuake" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#txtMoney").val(" ");
            $("#txtMoney").click(function () {
                $(this).val("");
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("Transfer")%></h2>
            <div class="filter">
                <div class="row-fluid">
                    <div class="span4">
                        <label><%=GetLanguage("QuarkCoin")%><%--夸克币--%>：</label>
                        <span class="field">
                            <%=LoginUser.User011%>
                        </span>
                    </div>
                </div>
            </div>
            <div>&nbsp;</div>
            <h6><%=GetLanguage("MemberTransfer")%><%--会员转账--%></h6>
            <div>&nbsp;</div>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("TransferType")%><!--转账类型-->：</label>
                        <span class="field">
                            <asp:DropDownList ID="dropCurrency" runat="server"></asp:DropDownList>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("cunbi")%><%=GetLanguage("Time")%><%--存币时间--%>：</label>
                        <span class="field">
                            <asp:DropDownList ID="dropDay" runat="server"></asp:DropDownList>
                        </span>
                    </p>
                </div>
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("TheTransferAmount")%><!--转账金额-->：</label>
                        <span class="field">
                            <asp:TextBox ID="txtMoney" class="input_select" runat="server" type="text"
                                onkeydown="if(event.keyCode==13)event.keyCode=9" onkeypress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;" /><%=GetLanguage("Yuan")%><!--元-->
                        </span>
                    </p>
                    <p class="span3">
                        
                        <asp:Button ID="btnSubmit" Name="btnSubmit" runat="server" Text="" class="btn" OnClick="btnSubmit_Click" />
                    </p>
                </div>
            </div>
            <div>&nbsp;</div>
            <h6><%=GetLanguage("TransferQuery")%><%--转账查询--%></h6>
            <div>&nbsp;</div>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("DateTransfer")%><!--转账日期-->：</label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                {%>
                            <asp:TextBox ID="txtStart" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                                else
                                {%>
                            <asp:TextBox ID="txtStartEn" runat="server" class="input_select" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("To")%></label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                {%>
                            <asp:TextBox ID="txtEnd" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                                else
                                {%>
                            <asp:TextBox ID="txtEndEn" runat="server" class="input_select" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnSearch" runat="server" class="btn" OnClick="btnSearch_Click" Text="" />
                    </p>
                </div>
            </div>
            <table class="styled">
                <thead>
                    <tr>
                        <th><%=GetLanguage("cunbi")%><%=GetLanguage("Time")%><%--存币时间--%>
                        </th>
                        <th>
                            <%=GetLanguage("TheTransferAmount")%>
                            <!--转账金额-->
                        </th>
                        <th style="display:none"><%=GetLanguage("Dailyincome")%><%--每天收益--%>
                        </th>
                        <th>
                            <%=GetLanguage("DateTransfer")%>
                            <!--转账日期-->
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                <td align="center">
                                    <%#Eval("SettleDay")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Amount")%>
                                </td>
                                <td align="center" style="display:none">
                                    <%#Eval("c002")%>%
                                </td>
                                <td align="center">
                                    <%#Eval("AddTime")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="3" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                        </div>
                    </td>
                </tr>
            </table>
           
            <div class="pager">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页" OnPageChanged="AspNetPager1_PageChanged"
                    LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                    NumericButtonCount="3" PageSize="10" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
