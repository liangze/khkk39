<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sendinbox.aspx.cs" Inherits="Web.user.member.sendinbox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="shortcut icon" href="../../images/favicon.ico" type="images/x-icon" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/footable.core.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../..css/jquery.ui.all.css" rel="stylesheet" type="text/css" media="all" />
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
    <script type="text/javascript" src="../../js/echarts.js"></script>
    <script type="text/javascript" src="../../js/functions.js"></script>
    <script>
        function focusAndSelect(obj) {
            obj.focus();
            obj.select();
        }
    </script>
</head>
<body>
    <div class="main_container">
        <div class="center_content">
            <div class="right_content">
                <h2>发件箱
                </h2>

                <p>
                </p>
                <p></p>
                <table class="styled">
                    <thead>
                        <tr class="head">
                            <th style="display: table-cell; text-align: center;">发件人</th>
                            <th style="display: table-cell; text-align: center;">主要内容</th>
                            <th style="display: table-cell; text-align: center;">时间</th>
                            <th style="display: table-cell; text-align: center;">操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td align="center">CCF</td>
                            <td align="center">内容内容</td>
                            <td align="center">2016/06/01</td>
                            <td align="center"><a href="viewmailbox.html">查看</a>&nbsp;&nbsp;<a href="">删除</a></td>
                        </tr>
                        <tr>
                            <td align="center">CCF</td>
                            <td align="center">内容内容</td>
                            <td align="center">2016/06/01</td>
                            <td align="center"><a href="viewmailbox.html">查看</a>&nbsp;&nbsp;<a href="">删除</a></td>
                        </tr>
                    </tbody>
                </table>
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
