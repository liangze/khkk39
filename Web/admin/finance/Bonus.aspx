<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bonus.aspx.cs" Inherits="Web.admin.finance.Bonus" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>奖金查询</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body class="subBody">
    <form class="box_con" runat="server">
        <div class="box box_width">
            <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th>
                            直推奖累计
                        </th>
                        <th>
                            组织奖累计
                        </th>
                        <th>
                            领导奖累计
                        </th>
                        <th>
                            持币奖累计
                        </th>
                        <th>
                            存币奖累计
                        </th>
                        <th>
                            加权奖累计
                        </th>
                        <th>
                            奖金累计
                        </th>
                    </tr>
                    <tr>
                        <td align="center">
                            <%=GetBonus(0, 1)%>
                        </td>
                        <td align="center">
                            <%=GetBonus(0, 2)%>
                        </td>
                        <td align="center">
                            <%=GetBonus(0, 3)%>
                        </td>
                        <td align="center">
                            <%=GetBonus(0, 4)%>
                        </td>
                        <td align="center">
                            <%=GetBonus(0, 5)%>
                        </td>
                        <td align="center">
                            <%=GetBonus(0, 6)%>
                        </td>
                        <td align="center">
                            <%=GetBonusAllTotal(0, "Amount")%>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">查询</legend>结算日期：<asp:TextBox ID="txtStar" tip="输入结算日期"
                        runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                    至<asp:TextBox ID="txtEnd" tip="输入结算日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                        OnClick="btnSearch_Click"> 搜 索 </asp:LinkButton>
                    &nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="LinkButton3_Click"> 导 出 </asp:LinkButton>
                </fieldset>
            </div>
            <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th>
                            直推奖
                        </th>
                        <th>
                            组织奖
                        </th>
                        <th>
                            领导奖
                        </th>
                        <th>
                            持币奖
                        </th>
                        <th>
                            存币奖
                        </th>
                        <th>
                            加权奖
                        </th>
                        <th>
                            实发
                        </th>
                        <th>
                            结算日期
                        </th>
                        <th>
                            查看明细
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("Recommend")%><!--1.推荐奖-->
                                </td>
                                <td align="center">
                                    <%#Eval("zz")%><!--2.组织奖-->
                                </td>
                                <td align="center">
                                    <%#Eval("lead")%><!--3.领导奖-->
                                </td>
                                <td align="center">
                                    <%#Eval("chibi")%><!--4.持币奖-->
                                </td>
                                <td align="center">
                                    <%#Eval("cunbi")%><!--5.存币奖-->
                                </td>
                                <td align="center">
                                    <%#Eval("jiaquan")%><!--6.加权奖-->
                                </td>
                                <td align="center">
                                    <%#Eval("sf")%><!--实发-->
                                </td>
                                <td align="center">
                                    <%#Eval("SttleTime")%><!--结算日期-->
                                </td>
                                <td align="center">
                                    <asp:LinkButton ID="lbtnDetail" runat="server" PostBackUrl='<%#Eval("SttleTime","BonusDetail.aspx?SttleTime={0}") %>'><%=GetLanguage("ViewDetails")%><!--查看明细--></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="8" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
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
                        SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager1_PageChanged">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
