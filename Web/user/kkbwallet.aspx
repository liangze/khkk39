<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kkbwallet.aspx.cs" Inherits="Web.user.kkbwallet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="shortcut icon" href="../images/favicon.ico" type="images/x-icon" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/footable.core.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/jquery.ui.all.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/ui.fancytree.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/jquery.orgchart.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/jquery.steps.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/jquery.fancybox.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../css/jquery.bxslider.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../js/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="../js/footable.js"></script>
    <script type="text/javascript" src="../js/footable.paginate.js"></script>

    <script type="text/javascript" src="../js/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../js/jquery.ui.datepicker.js"></script>
    <script type="text/javascript" src="../js/jquery.fancytree.js"></script>
    <script type="text/javascript" src="../js/jquery.orgchart.js"></script>
    <script type="text/javascript" src="../js/jquery.steps.min.js"></script>
    <script type="text/javascript" src="../js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../js/jquery.lightbox-0.5.pack.js"></script>
    <script type="text/javascript" src="../js/jquery.fancybox.pack.js"></script>
    <script type="text/javascript" src="../js/jquery.bxslider.min.js"></script>
    <script type="text/javascript" src="../js/jquery.idtabs.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/functions.js"></script>
    <script>
        function focusAndSelect(obj) {
            obj.focus();
            obj.select();
        }
    </script>
    <script type="text/javascript">
        function doSubmit(thisForm) {

            if (thisForm.DateFrom.value == "") {
                alert("Invalid Date!");
                return false;

            } else if (thisForm.DateTo.value == "") {
                alert("Invalid Date!");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <div class="main_container">
        <div class="center_content">
            <div class="right_content">
                <h2>夸克币钱包
                </h2>

                <p />
                <p></p>
                <form name="mbrRpt" action="ewallet2.html" method="post" onsubmit="return doSubmit(this);">
                    <div class="filter">

                        <div class="row-fluid">
                            <p class="span3">
                                <label>类型: </label>
                                <span class="field">
                                    <select name="Type">
                                        <option value="10">夸克币钱包</option>
                                    </select>
                                </span>
                            </p>
                            <p class="span3">
                                <label>日期</label>
                                <span class="field">
                                    <input type="text" id="datefrom" name="DateFrom" value="06-05-2015">
                                </span>
                            </p>
                            <p class="span3">
                                <label>至</label>
                                <span class="field">
                                    <input type="text" id="dateto" name="DateTo" value="28-06-2016">
                                </span>
                            </p>
                            <p class="span3">
                                <input type="hidden" name="search" value="">
                                <input type="submit" value="提交">
                            </p>

                        </div>
                        <!--end of row-fluid-->
                    </div>
                    <!--end of filter-->

                    <fieldset class="legend">
                        <div class="row-fluid">
                            <div class="span4"><b>类型:</b> 夸克币钱包</div>
                            <!--end of span4-->
                            <div class="span4"><b>结余:</b> 0.00</div>
                            <!--end of span4-->
                        </div>
                        <!--end of row fluid-->
                    </fieldset>

                </form>
                <script>
                    loadCombobox(document.mbrRpt.Type, "10");
                </script>

                <hr>


                <br>
                <div class="ctr table-responsive" style="overflow-x: auto;">

                    <table class="styled footable no-paging footable-loaded tablet breakpoint" data-page-size="10000">
                        <thead>

                            <tr>
                                <th class="footable-visible footable-first-column" style="text-align: center;">日期</th>
                                <th class="footable-visible" style="text-align: center;">时间</th>
                                <th class="footable-visible" style="text-align: center;">收入</th>
                                <th class="footable-visible" style="text-align: center;">支出</th>
                                <th class="footable-visible" style="text-align: center;">结余</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr style="display: table-row;">
                                <td align="center" class="footable-visible footable-first-column">内容内容</td>
                                <td align="center" class="footable-visible">内容内容</td>
                                <td align="center" class="footable-visible">内容内容</td>
                                <td align="center" class="footable-visible">内容内容</td>
                                <td align="center" class="footable-visible footable-last-column">内容内容</td>
                            </tr>
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colspan="6" class="footable-visible">无记录</td>
                            </tr>
                        </tfoot>
                    </table>
                </div>
                <ul class="pager">
                    <li><a href="#">当前</a></li>
                    <li><a href="#">下一页</a></li>
                </ul>
            </div>
            <!--end of right content-->

        </div>
        <!--end of center content-->

    </div>
</body>
</html>
