<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCashbuy.aspx.cs" Inherits="Web.user.Cash.MyCashbuy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server" class="stdform">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="right_content">

            <h2><%=GetLanguage("OrderDetails")%><%--订单明细--%></h2>


            <h6>商品信息：</h6>
            <div class="row-fluid">
                <div class="span6">
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("TitleGoods")%><%--商品标题--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltTitle" runat="server"></asp:Literal>
                        </div>
                    </div>

                    <div class="control-group">
                        <label for="memid">
                            商品卖家：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltBankAccount" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("CommodityPrices")%><%--商品单价价--%>：
                        </label>
                        <div class="field">
                            <%--<asp:Literal ID="ltAmount" runat="server"></asp:Literal>--%>
                            <asp:TextBox ID="Amount" Names="Amount" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("Quantity")%><%--商品数量--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltNumber" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("GoodsAmount")%><%--商品价格--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltPrice" runat="server"></asp:Literal>美元
                        </div>
                    </div>

                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("PurchaseQuantity")%><%--购买数量--%>：
                        </label>
                        <div class="field">
                            <asp:TextBox ID="txtnumber" names="txtnumber" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    

                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("PaymentMoney")%><%--支付金额--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltPayment" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("QuantityArrival")%><%--到账数量--%>：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltArrival" runat="server"></asp:Literal>个注册点
                        </div>
                    </div>
                    <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span> <%=GetLanguage("Depositary") %>：
                                </label>
                                <div class="field">
                                    
                                    <input name="dropBank" id="dropBank" value="" runat="server" disabled="disabled" />
                                    <input name="dropProvince" id="dropProvince" value="" runat="server" disabled="disabled" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span> <%=GetLanguage("BankBranch")%>：
                                </label>
                                <div class="field">
                                    <input name="txtBankBranch" type="text" id="txtBankBranch" runat="server" class="input_reg" disabled="disabled"  />
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span> <%=GetLanguage("BankAccount")%>：
                                </label>
                                <div class="field">
                                   <input name="txtBankAccount" type="text" id="txtBankAccount" runat="server" class="input_reg" value="" maxlength="19" disabled="disabled"/>
                                </div>
                            </div>
                            <div class="control-group">
                                <label for="memid">
                                    <span style="color: #f00;">*</span><%=GetLanguage("AccountName")%>：
                                </label>
                                <div class="field">
                                    <input name="txtBankAccountUser" type="text" id="txtBankAccountUser" runat="server" class="input_reg" disabled="disabled" />
                                </div>
                            </div>
                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("UploadDocument")%><!--上传凭证-->：
                        </label>
                        
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                      
                       <%-- <div class="field">
                            
                        </div>--%>
                    </div>

                    <div class="control-group">
                        <label for="memid">
                            <%=GetLanguage("PaymentpPassword")%><%--支付密码--%>：
                        </label>
                        <div class="field">
                            <input runat="server" type="password" id="PaymentpPassword" name="PaymentpPassword" value="" />
                        </div>
                    </div>
                    <div class="control-group" style="display: none;">
                        <label for="memid">
                            购买件数：
                        </label>
                        <div class="field">
                            <asp:Literal ID="ltBuyNum" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
       
            <div class="action">
                <asp:Button ID="btnCancel" runat="server" Text="确认购买" class="btn" OnClick="btnCancel_Click" />&nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" Text="返 回" class="btn" OnClick="btnBack_Click" />
            </div>
        </div>
    </form>
</body>
</html>
