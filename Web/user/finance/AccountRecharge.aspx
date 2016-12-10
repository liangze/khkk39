<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountRecharge.aspx.cs" Inherits="Web.user.finance.AccountRecharge" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />

    <link href="../../css/jquery.fancybox.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    

    <script type="text/javascript" src="../../js/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.widget.js"></script>  
    <script type="text/javascript" src="../../js/jquery.fancytree.js"></script> 
    <script type="text/javascript" src="../../js/jquery.fancybox.pack.js"></script>
    <script type="text/javascript" src="../../js/functions.js"></script>
  
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
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div class="right_content">
            <h2><%=GetLanguage("Recharge")%></h2>
       

            <div class="filter">
                <div class="row-fluid" align="center" style="height: 281px;">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel5">
                        <ContentTemplate>
                            <asp:Image runat="server" ID="vimg" Width="300" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div>&nbsp;</div>
            <h6><%=GetLanguage("Applicationfor")%><%--申请充值--%></h6>
            <div>&nbsp;</div>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("Rechargecurrcy")%><!--充值币种-->：</label>
                        <span class="field">
                            <asp:DropDownList ID="dropCurrency" runat="server"></asp:DropDownList>
                        </span>
                    </p>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                        <ContentTemplate>
                            <p class="span3">
                                <label><%=GetLanguage("Rechargeaddress")%><!--支付类型-->：</label>
                                <span class="field">
                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropCurrency1_SelectedIndexChanged"></asp:DropDownList>
                                </span>
                            </p>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                        <ContentTemplate>
                            <p class="span3">
                                <label><%=GetLanguage("MembershipNumber")%><!--会员编号-->：</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtUserCode" class="input_select" Text="" AutoPostBack="true"
                                        OnTextChanged="txtUserCode_TextChanged"></asp:TextBox>
                                </span>
                            </p>
                            <p class="span3">
                                <label><%=GetLanguage("MemberName")%><!--会员姓名-->：</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtTrueName" class="input_select" Text="" Enabled="false"></asp:TextBox>

                                </span>
                            </p>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("Amountcharge")%><!--充值金额-->：</label>
                        <span class="field">
                            <asp:TextBox ID="txtMoney" class="input_select" runat="server" type="text"
                                onkeydown="if(event.keyCode==13)event.keyCode=9" onkeypress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;" /><%=GetLanguage("USD")%><!--元-->
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("UploadDocument")%><!--上传凭证-->：</label>
                        <span class="field">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </span>
                    </p>
                    <p class="span3">
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" class="btn" OnClick="btnSubmit_Click" />
                    </p>
                </div>
            </div>
            <div>&nbsp;</div>
            <h6><%=GetLanguage("RechargeQuery")%><%--充值查询--%></h6>
            <div>&nbsp;</div>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("CurrencyType")%><!--币种-->：</label>
                        <span class="field">
                            <asp:DropDownList ID="dropType" runat="server"></asp:DropDownList>
                        </span>
                    </p>
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
                        <asp:Button ID="btnSearch" runat="server" class="btn" OnClick="btnSearch_Click" />
                    </p>
                </div>
            </div>
            <table class="styled">
                <thead>
                    <tr>
                        <th><%=GetLanguage("MembershipNumber")%><%--会员编号--%></th>
                        <th><%=GetLanguage("Name")%><%--会员姓名--%></th>
                        <th><%=GetLanguage("remittance")%><%--汇款金额--%></th>
                        <th><%=GetLanguage("IntoAccount")%><%--汇入账户--%></th>
                        <th><%=GetLanguage("Rechargecurrcy")%><%--充值类型--%></th>
                        <th><%=GetLanguage("Shenqing")%><%--申请日期--%></th>
                        <th><%=GetLanguage("Auditstatus")%><%--审核状态--%></th>
                        <th><%=GetLanguage("Operation")%><%--操作--%></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td align="center"><%#Eval("UserCode")%></td>
                                <td align="center"><%#Eval("Truename")%></td>
                                <td align="center"><%#Eval("RemitMoney")%></td>
                                <td align="center">
                                    <%if (GetLanguage("LoginLable") == "zh-cn")
                                        {%>
                                    <%# (vkBLL.GetID((Eval("BankName").ToString()))).ToString()=="1"?"充值通道1":(vkBLL.GetID((Eval("BankName").ToString()))).ToString()=="2"?"充值通道2":
                                          (vkBLL.GetID((Eval("BankName").ToString()))).ToString()=="3"?"比特币地址":"莱特币地址"%>
                                    <%}
                                        else
                                        {%>
                                    <%# (vkBLL.GetID((Eval("BankName").ToString()))).ToString()=="1"?"Recharge channel 1":(vkBLL.GetID((Eval("BankName").ToString()))).ToString()=="2"?"Recharge channel 2":
                                          (vkBLL.GetID((Eval("BankName").ToString()))).ToString()=="3"?"Bitcoin address":"Wright currency address"%>
                                    <%} %>
                                </td>
                                <td align="center">

                                    <%if (GetLanguage("LoginLable") == "zh-cn")
                                        {%>
                                    <%#Eval("Remit001").ToString() == "1" ? "激活点数" : "注册点数"%>
                                    <%}
                                        else
                                        {%>
                                    <%#Eval("Remit001").ToString() == "1" ? "Activation points" : "Registration points"%>
                                    <%} %>
                                </td>
                                <td align="center"><%#Eval("AddDate")%></td>
                                <td align="center">
                                    <%if (GetLanguage("LoginLable") == "zh-cn")
                                        {%>
                                    <%#Eval("State").ToString() == "0" ? "未审" : "已审"%>
                                    <%}
                                        else
                                        {%>
                                    <%#Eval("State").ToString() == "0" ? "Without trial" : "The trial has been"%>
                                    <%} %>
                                </td>
                                <td align="center">
                                   <%-- <a class="fancybox fancybox.iframe" href="AccountRecharImg.aspx?ID=<%#Eval("ID") %>" style="color: Red;"><%=GetLanguage("ViewDocument")%>--%>
                                        <asp:LinkButton ID="lbtnDetail" runat="server" CommandArgument='<%# Eval("ID") %>'
                                            CommandName="Detail" Visible='<%#Convert.ToInt32(Eval("State"))==0?true:false%>'><a class="fancybox fancybox.iframe"href="AccountRecharImg.aspx?ID=<%#Eval("ID") %>" style="color: Red;"><%=GetLanguage("ViewDocument")%><!--查看凭证--></a> </asp:LinkButton>&nbsp&nbsp&nbsp;
                                    <%if (GetLanguage("LoginLable") == "zh-cn")
                                        {%>
                                        <asp:LinkButton ID="lbtnDel" runat="server" CommandArgument='<%# Eval("ID") %>' class="easyui-linkbutton"
                                            iconcls="icon-no" CommandName="Remove" OnClientClick="javascript:return confirm('你确定要删除吗？')" Visible='<%#Convert.ToInt32(Eval("State"))==0?true:false%>'>删除</asp:LinkButton>
                                        <%}
                                            else
                                            {%>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("ID") %>' class="easyui-linkbutton"
                                            iconcls="icon-no" CommandName="Remove" OnClientClick="javascript:return confirm('Are you sure you want to delete it？')" Visible='<%#Convert.ToInt32(Eval("State"))==0?true:false%>'>delete</asp:LinkButton>
                                        <%} %>
                                    
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr id="tr1" runat="server">
                    <td colspan="8" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span>
                        </div>
                    </td>
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
