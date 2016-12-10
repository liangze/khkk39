<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationBuy.aspx.cs" Inherits="Web.admin.finance.RegistrationBuy" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>

    <script type="text/javascript" src="../../js/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../../js/jquery.fancytree.js"></script>
    <script type="text/javascript" src="../../js/jquery.fancybox.pack.js"></script>
    <script type="text/javascript" src="../../js/functions.js"></script>
  
    <link href="../../css/jquery.fancybox.css" rel="stylesheet" type="text/css" media="all" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">查询</legend>
                买家编号：<asp:TextBox ID="txtOrderCode" runat="server" class="input_select"></asp:TextBox>
                下订日期：<asp:TextBox ID="txtStart" tip="输入下订日期" runat="server" onfocus="WdatePicker()"
                    class="input_select"></asp:TextBox>
                至<asp:TextBox ID="txtEnd" tip="输入下订日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                <asp:LinkButton ID="lbtnSearch" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="lbtnSearch_Click"> 搜 索 </asp:LinkButton>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">买家编号
                    </th>
                    <th align="center">卖家编号
                    </th>
                    <th align="center">商品单价
                    </th>
                    <th align="center">商品价格
                    </th>
                    <th align="center">商品数量
                    </th>
                    <th align="center">下订时间
                    </th>
                    <th align="center">订单状态
                    </th>
                    <th align="center">交易凭证
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#userBLL.GetUserCode(long.Parse(Eval("UserID").ToString()))%>
                            </td>
                            <td align="center">
                                <%#userBLL.GetUserCode(long.Parse(Eval("SellUserID").ToString()))%>
                            </td>
                            <td align="center">
                                <%#Eval("Price")%>
                            </td>
                            <td align="center">
                                <%#Eval("Amount")%>
                            </td>
                            <td align="center">
                                <%#Eval("BuyNum")%>
                            </td>
                            <td align="center">
                                <%#Eval("BuyDate")%>
                            </td>
                            <td align="center">
                                <%# Convert.ToInt32(Eval("IsBuy")) == 1 ? "已完成" :Convert.ToInt32(Eval("IsBuy")) == 0 ? "等待发货":"订单取消"%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lbtnDetail" runat="server" CommandArgument='<%# Eval("CashbuyID") %>'><a class="fancybox fancybox.iframe"href="../../user/Cash/Imge.aspx?ID=<%#Eval("CashbuyID") %>" style="color: Red;"><%=GetLanguage("ViewDocument")%><!--查看凭证--></a> </asp:LinkButton>&nbsp&nbsp&nbsp;
                                  
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="tr1" runat="server">
                    <td colspan="8" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img alt="" src="../../images/ico_NoDate.gif" width="16" height="16" />
                                抱歉！目前数据库暂无数据显示。</span>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="nextpage cBlack">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                    LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                    NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                    HorizontalAlign="Right" OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
