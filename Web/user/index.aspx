 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web.user.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=getParamVarchar("SystemName2")%></title>
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1" name="viewport" />
    <link href="../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/footable.core.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/jquery.ui.all.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/ui.fancytree.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/jquery.orgchart.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/jquery.steps.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/jquery.fancybox.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../static/css/jquery.bxslider.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../static/js/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="../static/js/footable.js"></script>
    <script type="text/javascript" src="../static/js/footable.paginate.js"></script>
    <script type="text/javascript" src="../static/js/footable.sort.js"></script>
    <script type="text/javascript" src="../static/js/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../static/js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../static/js/jquery.ui.datepicker.js"></script>
    <script type="text/javascript" src="../static/js/jquery.fancytree.js"></script>
    <script type="text/javascript" src="../static/js/jquery.orgchart.js"></script>
    <script type="text/javascript" src="../static/js/jquery.steps.min.js"></script>
    <script type="text/javascript" src="../static/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../static/js/jquery.fancybox.pack.js"></script>
    <script type="text/javascript" src="../static/js/jquery.bxslider.min.js"></script>
    <script type="text/javascript" src="../static/js/jquery.idTabs.min.js"></script>
    <script type="text/javascript" src="../static/js/functions.js"></script>
    <script type="text/javascript">
        var _root = '';
    </script>

    <style type="text/css">
        .fancybox-margin {
            margin-right: 17px;
        }
    </style>
    <style type="text/css">
        .fancybox-margin {
            margin-right: 17px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="main_container">
            <div class="header clearfix">
                <div class="logo">
                    <a href="index.aspx">
                        <img alt="" src="../images/dlogo1.png" width="68px" /></a>
                </div>
                <!--end of logo-->
                <div class="menu">
                    <ul>
                        <li><a class="toggle_menu">
                            <img alt="" src="static/img/ico_menu.png" />
                            Menu</a></li>
                        <li><a class="toggle_setting">
                            <img alt="" src="static/img/ico_setting.png" />
                            Setting</a></li>
                    </ul>
                </div>
                <!--end of menu-->
                <div class="right_header">
                    <ul>
                        <li><a href="index.aspx" > <%=GetLanguage("index")%> <%--首页--%></a></li>
                        <li><a href="http://www.qrkbestcoin.com/Login.aspx"> <%=GetLanguage("TradingFloor")%><%--交易大厅--%></a>
                            
                        </li>
                        <li class="parent"><a href="javascript:void(0);">
                            <img alt="" src="../static/img/ico_user.png" /><%=LoginUser.UserCode%></a>
                            <ul>
                                <li><a href="member/PersonalInfo.aspx" target="mainfrom"><%=GetLanguage("MemberInformation")%><!--会员资料--></a></li>
                                <li><a href="member/ModifyPassWord.aspx" target="mainfrom"><%=GetLanguage("ModifyPassword")%><!--修改密码--></a></li>
                                <%if (currentCulture == "en-us")
                                    {%>
                                <li><a href="../loginout.aspx" onclick="javascript:return confirm('Are you sure to exit?')" style="width: 120px;"><%=GetLanguage("Exit")%></a></li>
                                <%}
                                    else
                                    {%>
                                <li><a href="../loginout.aspx" onclick="javascript:return confirm('确定退出吗？')" style="width: 120px;"><%=GetLanguage("Exit")%></a></li>
                                <%} %>
                            </ul>
                        </li>
                    </ul>
                </div>
                <!--end of right header-->
            </div>
            <div class="center_content">
                <iframe name="mainfrom" id="mainfrom" marginwidth="0" marginheight="0" src="<%=strUrl%>"
                    onload="this.height=mainfrom.document.body.scrollHeight < 560 ? 800 : mainfrom.document.body.scrollHeight;"
                    frameborder="0" width="100%" scrolling="auto"></iframe>
                
   
                <div class="left_content">
                    <div class="sidebarmenu">
                        <ul>
                            <li class="parent"><a class="active"><%=GetLanguage("UserCenter")%></a><%--用户中心--%>
                                <ul style="display: block;">
                                    <li><a href="index.aspx"><%=GetLanguage("index")%></a></li>
                                    <%--首页--%>
                                    <%--<li><a href="#">会员注册</a></li>--%>
                                    <li><a href="../Registers.aspx" target="mainfrom"><%=GetLanguage("Register")%></a></li>
                                    <%--会员注册--%>
                                    <li><a href="member/PersonalInfo.aspx" target="mainfrom"><%=GetLanguage("MemberInformation")%></a></li>
                                    <!--会员资料-->
                                    <li><a href="member/Accountactivation.aspx" target="mainfrom"><%=GetLanguage("AccountActivation")%><%--账户激活--%></a></li>
                                    <li><a href="member/ModifyPassWord.aspx" target="mainfrom"><%=GetLanguage("ModifyPassword")%></a></li>
                                    <!--登录密码修改-->
                                    <li><a href="member/doChangePwdloginapy.aspx" target="mainfrom"> <%=GetLanguage("PayPasswordgai")%> <%--支付密码更改--%></a></li>
                                    <li><a href="member/finddoChangePwdloginapy.aspx" target="mainfrom"> <%=GetLanguage("RecoverPaypassword")%><%--找回支付密码--%></a></li>
                                    <li><a href="team/RecommendTree.aspx" target="mainfrom"><%=GetLanguage("MemberTructure")%><%--会员直属结构--%></a></li>
                                    <li><a href="member/MemberTree.aspx" target="mainfrom"><%=GetLanguage("Allstructure")%><%--会员全体结构--%></a></li>
                                    <li><a href="team/TableTree.aspx" target="mainfrom"><%=GetLanguage("MemberList")%><%--会员列表--%></a></li>
                                    <li><a href="team/ewallet2.aspx" target="mainfrom"><%=GetLanguage("MembershipUpgrade")%><%--会员升级--%></a></li>
                                    
                                </ul>
                            </li>
                            <li class="parent"><a><%=GetLanguage("TeasseManage")%></a><%--资产管理--%>
                                <ul style="display: none;">
                                    <li><a href="finance/Bonus.aspx" target="mainfrom"><%=GetLanguage("MemberBonus")%><%--奖金明细--%> </a></li>
                                    <li><a href="goldcoin01.aspx" target="mainfrom"><%=GetLanguage("CommissionPoints")%><%--佣金点数--%> </a></li>
                                    <li><a href="goldcoin02.aspx" target="mainfrom"><%=GetLanguage("Registeredcurrency")%><%--注册点数--%> </a></li>
                                    <li><a href="goldcoin03.aspx" target="mainfrom"><%=GetLanguage("TradingPoints")%><%--交易点数--%> </a></li>
                                    <li><a href="goldcoin04.aspx" target="mainfrom"><%=GetLanguage("MallPoints")%><%--商城点数--%></a></li>
                                    <li><a href="goldcoin05.aspx" target="mainfrom"><%=GetLanguage("ActivationPoints")%><%--激活点数--%></a></li>
                                    <li><a href="goldcoin06.aspx" target="mainfrom"><%=GetLanguage("xianjin")%><%--现金币--%></a></li>
                                    <li><a href="goldcoin07.aspx" target="mainfrom"><%=GetLanguage("QuarkCoin")%><%--夸克币--%></a></li>
                                    <li><a href="goldcoin08.aspx" target="mainfrom"><%=GetLanguage("stockRight")%><%--股权--%></a></li>
                                    <li><a href="holdingmoney.aspx" target="mainfrom"><%=GetLanguage("chibi")%><%--持币--%></a></li>
                                    <li><a href="savamoney.aspx" target="mainfrom"><%=GetLanguage("cunbi")%><%--存币--%></a></li>
                                    <li><a href="finance/TakeMoney.aspx" target="mainfrom"><%=GetLanguage("MembershipWithdrawal")%><%--提现--%></a></li>
                                    <li><a href="finance/TransferToEmoney.aspx" target="mainfrom"><%=GetLanguage("Transfer")%><%--转账--%></a></li>
                                    <li><a href="finance/AccountRecharge.aspx" target="mainfrom"><%=GetLanguage("Recharge")%><%--账户充值--%></a></li>
                                </ul>
                            </li>
                            <li class="parent"><a><%=GetLanguage("TransactionManage")%><%--交易管理--%></a>
                                <ul style="display: none;">
                                    <li><a href="Cash/goumaiL.aspx" target="mainfrom"><%=GetLanguage("PurchasList")%><%--购买列表--%></a></li>
                                    <li><a href="Cash/SaleList.aspx" target="mainfrom"><%=GetLanguage("SellList")%><%--卖出列表--%></a></li>
                                    <li><a href="Stock/eptransaction.aspx" target="mainfrom"><%=GetLanguage("GoldTrading")%><%--EP交易--%></a></li>
                                </ul>
                            </li>
                            <li class="parent"><a><%=GetLanguage("AnnounManagement")%><%--公告管理--%></a>
                                <ul style="display: none;">
                                    <li><a href="member/Leavewords.aspx" target="mainfrom"><%=GetLanguage("messageManagement")%><%--留言管理--%></a></li>
                                    <li><a href="member/LeaveMsg.aspx" target="mainfrom"><%=GetLanguage("TheInbox")%><%--收件箱--%></a></li>
                                    <li><a href="member/LeaveOut.aspx" target="mainfrom"><%=GetLanguage("TheOutbox")%><%--发件箱--%></a></li>
                                    <li><a href="member/NoticeList.aspx" target="mainfrom"><%=GetLanguage("CompanyInformation")%><%--公司资讯--%></a></li>
                                </ul>
                            </li>
                            <li class="parent"><a><%=GetLanguage("ShopGoods")%><%--购物商品--%></a> 
                                <ul style="display: none;">
                                    <li><a href="shop/Retail.aspx" target="mainfrom"><%=GetLanguage("Listgoods")%><%--商品列表--%></a></li>
                                    <li><a href="product/Address.aspx" target="mainfrom"><%=GetLanguage("AddressManage")%><%--收货地址管理--%></a></li>
                                    <li><a href="shop/order.aspx" target="mainfrom"><%=GetLanguage("MyOrder")%><%--我的订单--%></a></li>
                                </ul>
                            </li>

                            <%if (LoginUser.IsAgent == 1)
                                {%>

                            <%} %>
                        </ul>
                        <p class="footer">Copyright © 2016 CPM. All rights reserved.</p>
                    </div>
                    <!--end of sidebarmenu-->
                </div>

            </div>

            <!--end of center content-->
        </div>
    </form>
</body>
</html>
