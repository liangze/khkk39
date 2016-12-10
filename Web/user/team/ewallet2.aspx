<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ewallet2.aspx.cs" Inherits="Web.user.team.ewallet2" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="shortcut icon" href="../../images/favicon.ico" type="images/x-icon" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/footable.core.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/jquery.ui.all.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/ui.fancytree.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/jquery.orgchart.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/jquery.steps.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/jquery.fancybox.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/jquery.bxslider.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../../js/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="../../js/footable.js"></script>
    <script type="text/javascript" src="../../js/footable.paginate.js"></script>

    <script type="text/javascript" src="../../js/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.datepicker.js"></script>
    <script type="text/javascript" src="../../js/jquery.fancytree.js"></script>
    <script type="text/javascript" src="../../js/jquery.orgchart.js"></script>
    <script type="text/javascript" src="../../js/jquery.steps.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.lightbox-0.5.pack.js"></script>
    <script type="text/javascript" src="../../js/jquery.fancybox.pack.js"></script>
    <script type="text/javascript" src="../../js/jquery.bxslider.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.idtabs.min.js"></script>
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../js/functions.js"></script>
    <style type="text/css">
        .row-fluid [class*="span"] {
            margin-left: 0;
        }

        .filter p input[type="number"] {
            width: 65%;
            padding: 6px;
            border: none;
            background: transparent;
            padding-top: 8px;
            margin: 0px;
            background-color: #FFFFFF;
            box-shadow: inset 0px 1px 3px rgba(0,0,0,0.2);
            border: 1px solid #CCCCCC;
        }
    </style>
    <script>
        function focusAndSelect(obj) {
            obj.focus();
            obj.select();
        }
    </script>

</head>
<body>

    <div class="center_content">
        <div class="right_content" style="height: 800px;">
            <h2><%=GetLanguage("MembershipUpgrade")%><%--会员升级--%>
            </h2>

            <p />
            <p></p>
            <form runat="server">
                <fieldset class="legend">
                    <div class="row-fluid">
                        <div class="span4"><b><%=GetLanguage("MembershipUpgrade") %><%--用户名称--%>:</b>
                            <input name="txtUserCode" type="text" id="txtUserCode" runat="server" class="input_reg" disabled="disabled" /></div>
                        <!--end of span4-->
                        <div class="span4"><b><%=GetLanguage("UserName") %><%--会员姓名--%>:</b>
                            <input name="txtTrueName" type="text" id="txtTrueName" runat="server" class="input_reg" disabled="disabled" /></div>
                        <!--end of span4-->
                        <div class="span4"><b><%=GetLanguage("MembershipLevels") %><%--会员级别--%>:</b>
                            <input name="LevelName" type="text" id="LevelName" runat="server" class="input_reg" disabled="disabled" /></div>
                        <!--end of span4-->
                        <div class="span4"><b><%=GetLanguage("RegistrationAmount") %><%--注册金额--%>:</b>
                            <input name="txtRegMoney" type="text" id="txtRegMoney" runat="server" class="input_reg" disabled="disabled" /></div>
                        <!--end of span4-->


                        <div class="span4"><b><%=GetLanguage("Registeredcurrency") %><%--注册点数--%>:</b>
                            <input name="txtRegisterPoint" type="text" id="txtRegisterPoint" runat="server" class="input_reg" disabled="disabled" /></div>
                        <!--end of span4-->
                        <div class="span4"><b><%=GetLanguage("ActivationPoints") %><%--激活点数--%>:</b>
                            <input name="txtActivationPoints" type="text" id="txtActivationPoints" runat="server" class="input_reg" disabled="disabled" /></div>
                        <!--end of span4-->
                    </div>
                    <!--end of row fluid-->
                </fieldset>
                <div class="filter">
                    <div class="row-fluid">
                        <p class="span3">
                            <label><%=GetLanguage("UpgradeLevels")%><%--升级级别--%>:</label>
                            <span class="field">
                                <asp:DropDownList Names="LevelSelect" ID="LevelSelect" runat="server" AutoPostBack="true" OnSelectedIndexChanged="LevelSelect_SelectedIndexChanged1"></asp:DropDownList>
                            </span>
                        </p>
                        <p class="span3">
                            <label><%=GetLanguage("Paregstrpoint")%><%=GetLanguage("Registeredcurrency") %><%--缴纳注册点--%>:</label>
                            <span class="field">
                                <input type="text" id="txtPaymentRegPoint" name="txtPaymentRegPoint" runat="server" value="" disabled="disabled" />
                            </span>
                        </p>
                        <p class="span3">
                            <label><%=GetLanguage("Paregstrpoint")%><%=GetLanguage("ActivationPoints")%><%--缴纳激活点--%>:</label>
                            <span class="field">
                                <input type="text" id="txtPaymentActivationPoint" name="txtPaymentActivationPoint" runat="server" value="" disabled="disabled" />

                            </span>
                        </p>
                        <p class="span3">
                            <%--<input type="hidden" name="search" value=""/>
                            <input type="submit" value="提交"/>--%>
                            <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
                        </p>

                    </div>
                    <!--end of row-fluid-->
                </div>
                <!--end of filter-->
                <hr />
                <br />

                <div class="ctr table-responsive" style="overflow-x: auto;">

                    <table class="styled footable no-paging footable-loaded tablet breakpoint" data-page-size="10000">
                        <thead>

                            <tr>
                                <th class="footable-visible footable-first-column" style="text-align: center;"><%=GetLanguage("UpgradeBeforeLevels") %><%--升级前级别--%></th>
                                <th class="footable-visible" style="text-align: center;"><%=GetLanguage("TheUpgradeLevels") %><%--升级后级别--%></th>
                                <th class="footable-visible" style="text-align: center;"><%=GetLanguage("Paregstrpoint")%><%=GetLanguage("Registeredcurrency")%><%--缴纳注册点--%></th>
                                <th class="footable-visible" style="text-align: center;"><%=GetLanguage("Paregstrpoint")%><%=GetLanguage("ActivationPoints") %><%--缴纳激活点--%></th>
                                <th class="footable-visible" style="text-align: center;"><%=GetLanguage("Shenqing") %><%--申请日期--%></th>
                                <%--<th class="footable-visible" style="text-align: center;">状态</th>--%>
                                <th class="footable-visible" style="text-align: center;"><%=GetLanguage("Notes") %><%--备注--%></th>
                            </tr>
                        </thead>

                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <%--<td align="center">
                                <%#Eval("UserCode")%>
                            </td>--%>
                                    <td align="center">
                                        <%# levelBLL.GetLevelName(Convert.ToInt32(Eval("LastLevel")))%>
                                    </td>
                                    <td align="center">
                                        <%# levelBLL.GetLevelName(Convert.ToInt32(Eval("EndLevel")))%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("ProMoney")%> <%--缴纳注册点--%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("Pro003")%> <%--缴纳激活点--%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("AddDate")%>
                                    </td>
                                    <%--<td align="center">
                                 <%#Convert.ToInt32(Eval("Flag")) == 1 ? "已审核" : "未审核"%>
                            </td>--%>
                                    <td align="center">
                                        <%#Convert.ToInt32(Eval("Remark")) == 1 ? "自助升级" : "后台升级"%>
                                        <%--<%#Eval("Remark")%>--%>
                                    </td>
                                    <%--<td align="center">
                              <asp:LinkButton ID="LinkButton1" runat="server" CommandName="flag" class="easyui-linkbutton"
                                    iconcls="icon-ok" CommandArgument='<%#Eval("ID") %>' Visible='<%#Eval("Flag").ToString()=="0"?true:false %>'>审核</asp:LinkButton>
                                <asp:Label ID="Label1" runat="server" Text="已审核" Visible='<%#Eval("Flag").ToString()=="1"?true:false %>'></asp:Label>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="delete" class="easyui-linkbutton"
                                    iconcls="icon-no" CommandArgument='<%#Eval("ID") %>' Visible='<%#Eval("Flag").ToString()=="0"?true:false %>'>删除</asp:LinkButton>
                            </td>--%>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server">
                            <td colspan="7" align="center">
                                <div class="NoData">
                                    <span class="cBlack">
                                        <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                        <%=GetLanguage("Manager") %> <%--抱歉！目前数据库暂无数据显示。--%></span>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <%--<ul class="pager">
                <li><a href="#">当前</a></li>
                <li><a href="#">下一页</a></li>
            </ul>--%>
                <div class="pager">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText=""
                        LastPageText="" NextPageText="" PrevPageText="" AlwaysShow="True" InputBoxClass="pageinput"
                        NumericButtonCount="3" PageSize="10" ShowInputBox="Never" ShowNavigationToolTip="True"
                        SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                        SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager1_PageChanged">
                    </webdiyer:AspNetPager>
                </div>
            </form>
        </div>
        <!--end of right content-->

    </div>
    <!--end of center content-->

</body>
</html>
