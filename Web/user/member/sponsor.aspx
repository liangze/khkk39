<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sponsor.aspx.cs" Inherits="Web.user.member.sponsor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="shortcut icon" href="../../images/favicon.ico" type="images/x-icon" />
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
    <script type="text/javascript" src="../../js/functions.js"></script>
    <script>
        function focusAndSelect(obj) {
            obj.focus();
            obj.select();
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 246px;
        }
    </style>
</head>
<body>
    <form name="networktree" class="noprint" method="post" action="sponsor.html" runat="server">
        <div class="center_content">

            <%--    <div class="left_content">
        <div class="sidebarmenu">
           </div>
    </div>--%>

            <div class="right_content" style="height: 800px;">
                <%--style="height:800px;"--%>
                <h2>直属会员列表
                </h2>

                <p />
                <p></p>




                <asp:Menu ID="Menu1" runat="server">
                </asp:Menu>
                <input type="hidden" name="ViewLevel" value="5" />
                <input type="hidden" name="ViewType" value="1" />
                <div class="filter">


                    <div class="row-fluid">
                        <p class="span4">
                            <label>
                                用户名称 :
                            </label>
                            <span class="field">
                                <input type="text" name="MemberId" value="" />
                            </span>
                        </p>
                    </div>

                    <div class="row-fluid">
                        <p class="span4">
                            <label>
                                日期 :
                            </label>
                            <span class="field">
                                <input type="text" name="BonusDate" value="" id="datefrom" />
                            </span>
                        </p>
                    </div>


                    <div class="row-fluid">
                        <p class="span4">
                            <input type="submit" value="查看" />
                        </p>
                    </div>




                </div>


                <script>
                    loadCombobox(document.networktree.ViewType, "1");
                    loadCombobox(document.networktree.ViewLevel, "5");
                </script>

                <div class="criteriaTable" style="overflow-x: auto;">

                    <table align="center" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="62">&nbsp;</td>
                            <td width="676">
                                <table width="676" border="0" cellspacing="0" cellpadding="0">
                                    <tr align="center">
                                        <td width="200">&nbsp;</td>
                                        <td width="276"></td>
                                        <td width="200">&nbsp;</td>
                                    </tr>
                                    <tr align="center">
                                        <td width="200">&nbsp;</td>
                                        <td width="276">
                                            <img src="../../images/tree/icon_small_red.gif"><br>
                                            <b><%=LoginUser.UserCode%></b>
                                            <br />
                                            (<%=LoginUser.UserCode%>)
		                            <br />
                                            Rank:<%=LoginUser.LevelID%>star
		                             <br />
                                            Total : 660.00
		                           <p />
                                            (0)
                                        </td>
                                        <td width="200">&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td width="62">&nbsp;</td>
                        </tr>
                        <tr align="center">
                            <td></td>

                            <table width="676" border="0" cellspacing="0" cellpadding="0">
                                <td width="225">&nbsp;</td>
                                <td width="226" align="center">
                                    <img src="images/t_tree_bottom.gif" /></td>
                                <td width="225">&nbsp;</td>
                            </table>
                            <td></td>
                        </tr>

                        <tr>

                            <td>
                                <table width="676" border="0" cellspacing="0" cellpadding="0">
                                    <tr align="center" valign="top">
                                        <td width="70">
                                            <img src="images/t_tree_bottom_l.gif">
                                        </td>
                                        <td width="90">
                                            <img src="images/t_tree_line.gif">
                                        </td>
                                        <td width="2">&nbsp;</td>
                                        <td width="90">
                                            <img src="images/t_tree_line.gif">
                                        </td>

                                        <td width="2">&nbsp;</td>
                                        <td width="90">
                                            <img src="images/t_tree_line.gif">
                                        </td>

                                        <td width="2">&nbsp;</td>
                                        <td width="90">
                                            <img src="images/t_tree_line.gif">
                                        </td>

                                        <td width="2">&nbsp;</td>
                                        <td width="90">
                                            <img src="images/t_tree_line.gif">
                                        </td>

                                        <td width="70">
                                            <img src="images/t_tree_bottom_r.gif">
                                        </td>

                                    </tr>
                                </table>
                            </td>

                        </tr>

                        <tr>

                            <td>
                                <table width="676" border="0" cellspacing="0" cellpadding="0">
                                    <tr align="center" valign="top" height="100">
                                        <td width="70">
                                            <img src="../../images/tree/icon_small_red.gif"><br>
                                            未加入
                                        <br>
                                            <a href='register.html'>新注册</a>

                                        </td>
                                        <td width="90">
                                            <img src="../../images/tree/icon_small_red.gif"><br>
                                            未加入
                                        <br>
                                            <a href='register.html'>新注册</a>

                                        </td>
                                        <td width="2">&nbsp;</td>
                                        <td width="90">
                                            <img src="../../images/tree/icon_small_red.gif"><br>
                                            未加入
                                        <br>
                                            <a href='register.html'>新注册</a>

                                        </td>
                                        <td width="2">&nbsp;</td>
                                        <td width="90">
                                            <img src="../../images/tree/icon_small_red.gif"><br>
                                            未加入
                                        <br>
                                            <a href='register.html'>新注册</a>

                                        </td>
                                        <td width="2">&nbsp;</td>
                                        <td width="90">
                                            <img src="../../images/tree/icon_small_red.gif"><br>
                                            未加入
                                        <br>
                                            <a href='register.html'>新注册</a>

                                        </td>
                                        <td width="2">&nbsp;</td>
                                        <td width="90">
                                            <img src="../../images/tree/icon_small_red.gif"><br>
                                            未加入
                                        <br>
                                            <a href='register.html'>新注册</a>
                                        </td>
                                        <td width="70">
                                            <img src="../../images/tree/icon_small_red.gif"><br>
                                            未加入
                                        <br>
                                            <a href='register.html'>新注册</a>
                                        </td>
                                    </tr>
                                </table>
                            </td>

                        </tr>
                    </table>
                </div>
                <div>
                     <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>

                </div>

            </div>

        </div>

    </form>
</body>
</html>
