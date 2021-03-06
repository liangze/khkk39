﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveOut.aspx.cs" Inherits="Web.user.member.LeaveOut" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发件箱</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("TheOutbox")%></h2>
            <div class="filter">
                <h2>
                    <a href="LeaveMsg.aspx" class="btn"><%=GetLanguage("TheInbox")%><%--收件箱--%></a>
                    <a href="LeaveOut.aspx" class="btn"><%=GetLanguage("TheOutbox")%><%--发件箱--%></a>
                    <a href="Leavewords.aspx" class="btn"><%=GetLanguage("message")%><%--留言--%></a>
                </h2>
            </div>
            <table class="styled">
                <thead>
                    <tr>
                        <th><%=GetLanguage("Recipient")%></th>
                        <!--收件人-->
                        <th><%=GetLanguage("SubjectContent")%></th>
                        <!--主題内容-->
                        <th><%=GetLanguage("TheOutboxDate")%></th>
                        <!--发件日期-->
                        <th><%=GetLanguage("State")%></th>
                        <!--状态-->
                        <th><%=GetLanguage("QuerySearch")%></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td align="center"><%#GetUserCode(Eval("ToUserID").ToString(), Eval("ToUserType").ToString())%></td>
                                <td align="center"><a href="LeaveWordsDetail.aspx?type=out&id=<%#Eval("ID") %>" target="mainfrom"><%#Eval("MsgTitle")%></a></td>
                                <td align="center"><%#Convert.ToDateTime(Eval("LeaveTime")).ToString("yyyy-MM-dd HH:mm:ss")%></td>
                                <td align="center"><%#Eval("IsReply").ToString() == "0" ? "未回复" : "已回复"%></td>
                                <td align="center"> &nbsp<asp:LinkButton ID="lbtnCancel" runat="server" class="btn"  CommandName="change"
                                    CommandArgument='<%#Eval("ID")%>'  ><%=GetLanguage("QuerySearch")%><!--查看--></asp:LinkButton></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="5" align="center"><%=GetLanguage("Manager")%></td>
                </tr>
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
    </form>
</body>
</html>
