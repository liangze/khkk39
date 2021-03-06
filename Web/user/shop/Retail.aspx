﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Retail.aspx.cs" Inherits="Web.user.shop.Retail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>零售积分</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" language="javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="right_content">
            <h2><%=GetLanguage("ProductList")%><%--我的订单--%></h2>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <label><%=GetLanguage("MembershipNumber")%>：</label>
                        <span class="field">
                            <input name="txtUserCode" type="text" id="txtUserCode" runat="server" class="input_reg" disabled="disabled" />
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("Name")%>：</label>
                        <span class="field">
                            <input name="txtTrueName" type="text" id="txtTrueName" runat="server" class="input_reg" disabled="disabled" />
                        </span>
                    </p>
                    <p class="span3">
                        <label><%=GetLanguage("CurrenBalance")%><%--商城点数--%>：</label>
                        <span class="field">
                            <input name="txtBonusAccount" type="text" id="txtBonusAccount" runat="server" class="input_reg" disabled="disabled" />
                        </span>
                    </p>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="styled">
                        <thead>
                            <tr>
                                <th>选择</th>
                                <th style="display: none;"><%=GetLanguage("ItemNumber")%><%--商品编号--%>
                                </th>
                                <th><%=GetLanguage("CommodityName")%><%--商品名称--%>
                                </th>
                                <th><%=GetLanguage("ProductCategory")%><%--产品类别--%>
                                </th>
                                <th><%=GetLanguage("InventoryQuantity")%><%--库存数量--%>
                                </th>
                                <th><%=GetLanguage("CommodityPrice")%><%--商品价格--%>
                                </th>
                                <th><%=GetLanguage("PurchaseQuantity")%><%--购买数量--%>
                                </th>
                                <th><%=GetLanguage("TheTotalAmount")%><%--总金额--%>
                                </th>
                            </tr>
                        </thead>
                        <script type="text/javascript">
                            function baodanID_onclick(b,id) 
                            {
                                $("#num_"+id).attr("disabled",!b).attr("readonly",!b).val(b?"1":"");
                                if(b)
                                {
                                    $("#num_"+id).focus() ;
                                }

                                var RealityPrice = parseFloat($("#RealityPrice_"+id).html()); 
                                             
                                if(b)
                                {
                                    $("#sum_"+id).html(RealityPrice) ;
                                }
                                else
                                {
                                    $("#sum_"+id).html(0) ;
                                }
                                showMoeny();
                            }

                            function showMoeny() 
                            {
                                var baodanIDs= document.getElementsByName("baodanID");
                                var SumMoney =0 ;
                                for(var i =0 ;i<baodanIDs.length;i++)
                                {
                                    if(baodanIDs[i].checked==false){
                                        continue;
                                    }
                                    var id = baodanIDs[i].value;
                                    var reg = /^[./0-9]+/;
                                    var s_num = $("#num_"+id).val();
                                    if(reg.test(s_num)==false)
                                    {
                                        $("#sum_"+id).html(0);
                                        continue;
                                    }

                                    var num= parseFloat(s_num); 
                                    var price = parseFloat($("#RealityPrice_"+id).html()); 
                                    SumMoney+=price* num;
                                                 
                                    $("#sum_"+id).html(price* num);
                                }
                                $("#spanSumMoney").html(SumMoney);
                            }
                        </script>
                        <tbody>
                            <asp:Repeater ID="rptProduct" runat="server">
                                <ItemTemplate>
                                    <tr class="<%# (this.rptProduct.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                        <td align="center">
                                            <input onclick="baodanID_onclick(this.checked,<%#Eval("ID")%>)" type="CheckBox" id="id_<%#Eval("ID")%>" name="baodanID" <%#(int.Parse(Eval("Pic5").ToString())>0?"":"disabled") %> value="<%#Eval("ID")%>" />

                                        </td>
                                        <td align="center" style="display: none;">
                                            <a href="Retail3.aspx?oid=<%#Eval("GoodsCode")%>"><%#Eval("GoodsCode")%></a>

                                        </td>
                                        <td align="center">
                                            <span title=' <%#Eval("GoodsName")%>'><%#Eval("GoodsName").ToString().Length>6?Eval("GoodsName").ToString().Substring(0,6)+"..":Eval("GoodsName") %></span>
                                            <p class="tg_pic">
                                                <a title='<%# Eval("GoodsName")%>' target="mainfrom" href='Retail3.aspx?pid=<%# Eval("TypeID")%>&gid=<%# Eval("ID")%>'>
                                                    <img width="90" height="45" alt='<%# Eval("GoodsName")%>' src='../../Upload/<%# Eval("Pic1")%>'></a>
                                                <span class="tg_info"></span>
                                                <span class="tg_info_1">
                                                    <%--<倒计时>--%>
                                                    <span style="display: none;">
                                                        <%#Eval("Goods007")%></span>
                                                    <span style="display: none;" class="Goods008RTime">
                                                        <%#Eval("Goods008")%></span>
                                                    <span class="Left" id="JS_over_time_26308" title='<%#Eval("Goods008")%>'></span>
                                                    <%--<倒计时end>--%>
                                                    <%-- <span class="Right">已团购：<b id="JS_already_number_26308"><%#Eval("SealCount")%></b>张</span>--%>
                                                </span>
                                            </p>
                                        </td>
                                        <td align="center">

                                            <%# produceTypeBLL.GetTypeName(int.Parse(Eval("GoodsType").ToString())) %>
                                            <td align="center">
                                                <%#Eval("Pic5")%>
                                            </td>
                                            <td align="center">
                                                <span id="RealityPrice_<%#Eval("ID")%>"><%#Eval("Price")%></span>
                                            </td>
                                            <td align="center">

                                                <input type="text" oninput="showMoeny()" onpropertychange="showMoeny()" id="num_<%#Eval("ID")%>" name="num_<%#Eval("ID")%>" style="width: 60px;" readonly disabled />

                                            </td>
                                            <td align="center">
                                                <span id="sum_<%#Eval("ID")%>">0</span>&nbsp;
                                            </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                        <tr>
                            <td colspan="7" style="font-size: 18px; font-weight: bold; text-align: right; color: #676767">商品总价：<span id="spanSumMoney" style="font-size: 24px; color: red;">0</span>&nbsp;</td>
                        </tr>
                        <tr align="center" runat="server" id="tr1">
                            <td colspan="7" style="border: 0">
                                <div>
                                    抱歉，目前数据库中暂无记录显示！
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div class="pager">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText=""
                            LastPageText="" NextPageText="" PrevPageText="" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                        </webdiyer:AspNetPager>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="filter">
                <div class="row-fluid">
                    <p class="span3">
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" OnClientClick="javascript:return confirm('确定要购买吗？')" />
                    </p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
