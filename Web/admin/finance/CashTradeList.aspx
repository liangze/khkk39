<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashTradeList.aspx.cs" Inherits="Web.admin.finance.CashTradeList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
</head>
<body>
    <form id="form1" runat="server">
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">查询</legend>
                会员编号：<asp:TextBox ID="txtOrderCode" runat="server" class="input_select"></asp:TextBox>
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
                    <th align="center">委托类型
                    </th>
                    <th align="center">卖家编号
                    </th>
                    <th align="center">买家编号
                    </th>
                    <th align="center">商品价格
                    </th>
                    <th align="center">委托数量
                    </th>
                     <th align="center">剩余数量
                    </th>
                    <th align="center">下订时间
                    </th>
                    <th align="center">订单状态
                    </th>
                    <th align="center">操作
                    </th>

                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;display:none">
                                <%#Eval("CashID")%>                          
                            </td>
                            <td style="text-align: center;">
                                <%#Eval("IsBorS").ToString() == "1"?"买入":"卖出" %>                          
                            </td>
                            <td style="text-align: center;">
                                <%--卖家编号--%>
                              
                                <asp:Literal ID="ltStatus" runat="server"></asp:Literal>
                            </td>
                            <td style="text-align: center;">
                                <%--买家编号--%>
                                 <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                
                            </td>
                            <td style="text-align: center;"><%#Eval("Price") %></td>
                            <td style="text-align: center;">
                                <%#Eval("tolNumber")%>
                                
                            </td>
                            <td style="text-align: center;">
                                <%#Eval("Num")%>
                                 <%--<asp:Literal ID="Literal2" runat="server"></asp:Literal>--%>
                            </td>
                            <td style="text-align: center;"><%#Convert.ToDateTime(Eval("AddTime")).ToString("yyyy/MM/dd") %></td>
                            <td style="text-align: center;">
                                <%#Eval("Stata").ToString() == "1"?"已完成":Eval("Stata").ToString() == "0"?"挂单中":"订单已撤销"%>                              
                            </td>
                            <td style="text-align: center;">
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#string.Concat(Eval("CashID").ToString(),",",Eval("IsBorS").ToString())%>'
                                    CommandName="Detail" Visible='<%#Convert.ToInt32(Eval("Stata"))==0?true:false%>'><%=GetLanguage("Cancel")%><!--取消--> </asp:LinkButton>

                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="tr1" runat="server">
                    <td colspan="9" align="center">
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
