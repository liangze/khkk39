<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transactionrecords.aspx.cs" Inherits="Tradinghall.user.transactionrecords" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("Tradingrecord")%></h2>
            <table class="styled">
                <thead>
                    <tr class="head">
                        <th style="text-align: center;"><%=GetLanguage("delegateType")%><!--委托类型--></th>
                        <th style="text-align: center;"><%=GetLanguage("Precatoryprice")%><!--委托价格--></th>
                        <th style="text-align: center;"><%=GetLanguage("NumberCommission")%><!--委托数量--></th>
                        <th style="text-align: center;"><%=GetLanguage("SurplusQuantity")%><!--剩余数量--></th>
                        <th style="text-align: center;"><%=GetLanguage("Time")%><!--时间--></th>
                        <th style="text-align: center;"><%=GetLanguage("State")%><!--状态--></th>
                        <th style="text-align: center;"><%=GetLanguage("Operation")%><!--操作--></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="Repeater1" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center;">
                                    <%if (Language == "en-us")
                                        { %>
                                    <%#Eval("IsBorS").ToString() == "1"?"Purchase":"Sell out" %>
                                    <%}
                                        else
                                        { %>
                                    <%#Eval("IsBorS").ToString() == "1"?"买入":"卖出" %>
                                    <%} %>
                                </td>
                                <td style="text-align: center;"><%#Eval("Price") %></td>
                                
                                <td style="text-align: center;">                        
                                    <%#Eval("tolNumber")%>
                                </td>
                                <td style="text-align: center;">                                                                  
                                    <%#Eval("Num")%>
                                </td>
                                <td style="text-align: center;"><%#Convert.ToDateTime(Eval("AddTime")).ToString("yyyy/MM/dd") %></td>
                                
                                <td style="text-align: center;">
                                    <%if (Language == "en-us")
                                        { %>
                                    <%#Eval("Stata").ToString() == "1"?"Completed":Eval("Stata").ToString() == "0"?"Waiting":"Rescinded" %>
                                    <%}
                                        else
                                        { %>
                                    <%#Eval("Stata").ToString() == "1"?"已完成":Eval("Stata").ToString() == "0"?"挂单中":"订单已撤销"%>
                                    <%} %>
                                </td>
                                <td style="text-align: center;">
                                     <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#string.Concat(Eval("CashID").ToString(),",",Eval("IsBorS").ToString())%>'
                                        CommandName="Detail" Visible='<%#Convert.ToInt32(Eval("Stata"))==0?true:false%>'><%=GetLanguage("Cancel")%><!--取消--> </asp:LinkButton>
                                       
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="6" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                    <%=GetLanguage("Manager") %>
                                    <!-- 抱歉！目前数据库暂无数据显示。-->
                                </span>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="pager">
                
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="" OnPageChanged="AspNetPager1_PageChanged"
                    LastPageText="" NextPageText="" PrevPageText="" AlwaysShow="True" InputBoxClass="pageinput"
                    NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                </webdiyer:AspNetPager>
               
            </div>
        </div>
        <!--end of right content-->
    </form>
</body>
</html>
