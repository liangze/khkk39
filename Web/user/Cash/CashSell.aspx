<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cashsell.aspx.cs" Inherits="Web.user.Cash.Cashsell" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../JS/ValidateData.js" type="text/javascript"></script>
</head>

<body>
    <form id="form1" runat="server" class="stdform" defaultfocus="txtnumber">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="right_content">
            <h2><%=GetLanguage("GoldTrading")%><%--EP交易--%></h2>

            <h6><%= GetLanguage("Sellregistropois")%><%--出售注册点数--%></h6>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("Registeredcurrency")%><%--注册点数--%>：
                        </label>
                        <div class="field">
                            <asp:Label ID="Label1" runat="server" Text="Label"><%=LoginUser.BonusAccount%></asp:Label>

                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%= GetLanguage("Sellregistropois")%><%--出售注册点数--%>
                                </label>
                                <div class="field">
                                    <asp:TextBox ID="txtnumber" names="txtnumber" runat="server" class="form-control"  OnTextChanged="txtnumber_TextChanged" AutoPostBack="true"></asp:TextBox>
                                 
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("CommodityPrices")%><%--商品单价--%>：
                                </label>
                                <div class="field">
                                    <asp:TextBox ID="txtPrice" runat="server" class="form-control" disabled="disabled"></asp:TextBox><%--=GetLanguage("dollars")%><%--美元--%>  <%--=GetLanguage("Registeredcurrency")%><%--注册点--%><!--金币-->
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <%=GetLanguage("GoodsAmount")%><%--商品金额--%>：
                                </label>
                                <div class="field">
                                    <input id="txttal" runat="server" class="form-control" value="" disabled="disabled" />
                                    <%--<span style="font-size: 12px;" id="spanAmount">--%></span><%--=GetLanguage("dollars")%><%--美元--%>
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("Factorage")%><%--手续费--%>：
                                </label>
                                <div class="field">
                                    <input name="txtFactorage" value="" type="text" id="txtFactorage" runat="server" disabled="disabled" class="input_reg" />
                                </div>
                            </div>
                            <div class="control-group" style="display: none;">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("TitleGoods")%><%--商品标题--%>：
                                </label>
                                <div class="field">
                                    <span style="font-size: 12px;" id="spanTitle"></span>
                                </div>
                            </div>
                            <div class="control-group" style="display: none;">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%--发布件数--%>：
                                </label>
                                <div class="field">
                                    <input name="txtUnitNum" type="text" id="txtUnitNum" runat="server" value="1" disabled="disabled" class="input_reg" />件
                                </div>
                            </div>
                            

                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span> <%=GetLanguage("Depositary") %>：
                                </label>
                                <div class="field">
                                    <asp:DropDownList ID="dropBank" runat="server">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="dropProvince" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span> <%=GetLanguage("BankBranch")%>：
                                </label>
                                <div class="field">
                                    <input name="txtBankBranch" value="" type="text" id="txtBankBranch" runat="server" class="input_reg" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span> <%=GetLanguage("BankAccount")%>：
                                </label>
                                <div class="field">
                                   <input name="txtBankAccount" type="text" id="txtBankAccount" runat="server" class="input_reg" value="" maxlength="19" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("AccountName")%>：
                                </label>
                                <div class="field">
                                    <input name="txtBankAccountUser" value="" type="text" id="txtBankAccountUser" runat="server" class="input_reg" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("PaymentpPassword")%><%--支付密码--%>：
                                </label>
                                <div class="field">
                                    <input name="txtPayPassword" type="password" id="txtPayPassword" runat="server" class="input_reg" />
                                </div>
                            </div>

                            
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
            <div class="action">
                <asp:Button ID="btnSubmit" runat="server" Text="" class="btn btn-submit" OnClientClick="CheckData()" OnClick="btnSubmit_Click" />



            </div>

        </div>
    </form>
</body>
</html>
