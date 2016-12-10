<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bonus.aspx.cs" Inherits="Web.user.finance.Bonus" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>奖金查询</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="Form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("MemberBonus")%></h2>
            <div class="filter">

                <div class="row-fluid">
                    <p class="span3">
                        <label>
                            <%=GetLanguage("UserName")%><%--用户名--%> :
                        </label>
                        <span>
                            <input type="text" id="txtUserCode" name="txtUserCode" runat="server" value="" disabled="disabled">
                        </span>
                    </p>
                </div>
            </div>
            <div>&nbsp;</div>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("SettlementDate")%><!--结算日期-->：</label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtStart" tip="输入结算日期" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtEnd" tip="input close an account date" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("To")%></label>
                        <span class="field">
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtStartEn" tip="输入结算日期" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtEndEn" tip="input close an account date" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                            <%} %>
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnSearch" runat="server" Text="查找" class="btn" OnClick="btnSearch_Click" />
                    </p>
                </div>
            </div>
            <table class="styled" style="font-size: inherit;">
                <thead>
                    <tr>
                        <th>
                            <%=GetLanguage("Recommended")%><!--2.直推奖-->
                        </th>
                        <th>
                            <%=GetLanguage("zuzhijia")%><!--2.组织奖-->
                        </th>
                        
                        <th>
                            <%=GetLanguage("lingdao")%><!--3领导奖-->
                        </th>
                        <th>
                            <%=GetLanguage("chibssi")%><!--4.持币佣金-->
                        </th>
                        <th>
                            <%=GetLanguage("cuccnbi")%><!--5.存币佣金-->
                        </th>
                        <th>
                            <%=GetLanguage("jiaquan")%><!--加权奖-->
                        </th>
                        <th>
                           <%=GetLanguage("RealHair")%> <!--实发-->
                        </th>
                        <th>

                            <%=GetLanguage("SettlementDate")%>
                            <!--结算日期-->
                        </th>
                        <th>
                            <%=GetLanguage("ViewDetails")%>
                            <!--查看明细-->
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
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
                                    <%#Eval("sf")%><%--实发--%>
                                </td>
                                <td align="center">
                                    <%#Eval("SttleTime")%><%--结算日期--%>
                                </td>
                                <td align="center">
                                    <asp:LinkButton ID="lbtnDetail" runat="server" PostBackUrl='<%#Eval("SttleTime","BonusDetail.aspx?SttleTime={0}") %>'><%=GetLanguage("ViewDetails")%><!--查看明细--></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="9" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="pager">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页" OnPageChanged="AspNetPager1_PageChanged"
                    LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                    NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
