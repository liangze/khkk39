<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productlist.aspx.cs" Inherits="Web.user.shop.productlist" %>

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
    <script type="text/javascript" src="../../js/footable.sort.js"></script>
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
        .filter p input[type="button"] {
            background-color: rgb(60,0,0);
            background-image: -moz-linear-gradient(top, rgba(110,0,0,1) 0%, rgba(60,0,0,1) 100%);
            background-image: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(110,0,0,1)), color-stop(100%,rgba(60,0,0,1)));
            background-image: -webkit-linear-gradient(top, rgba(110,0,0,1) 0%,rgba(60,0,0,1) 100%);
            background-image: -o-linear-gradient(top, rgba(110,0,0,1) 0%,rgba(60,0,0,1) 100%);
            background-image: -ms-linear-gradient(top, rgba(110,0,0,1) 0%,rgba(60,0,0,1) 100%);
            background-image: linear-gradient(to bottom, rgba(110,0,0,1) 0%,rgba(60,0,0,1) 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#6e0000', endColorstr='#3c0000',GradientType=0 );
            background-repeat: repeat-x;
            background-position: 0 0;
            width: inherit;
            border: 1px solid rgba(0,0,0,0.5);
            border-radius: 5px;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            box-shadow: inset 0px 1px 0px rgba(255,255,255,0.5);
            -moz-box-shadow: inset 0px 1px 0px rgba(255,255,255,0.5);
            -webkit-box-shadow: inset 0px 1px 0px rgba(255,255,255,0.5);
            color: #FFFFFF;
            text-shadow: 1px 1px 0px rgba(0,0,0,0.5);
            padding: 6px 15px;
            cursor: pointer;
        }

        .row-fluid [class*="span"] {
            margin-left: 0;
        }

        .car_span {
            width: 112px;
            height: 30px;
            border: 1px solid #dbdbdb;
            overflow: hidden;
            margin-left: 0;
            float: none;
        }

            .car_span a {
                text-decoration: none;
            }

        .car_reduce {
            width: 30px;
            height: 30px;
            border-right: 1px solid #dbdbdb;
            float: left;
            background-color: #e6e6e6;
            cursor: pointer;
            color: #989898;
            line-height: 20px;
            text-align: center;
            font-size: 68px;
        }

        .car_add {
            width: 30px;
            height: 30px;
            border-left: 1px solid #dbdbdb;
            float: left;
            background-color: #e6e6e6;
            cursor: pointer;
            color: #989898;
            line-height: 28px;
            text-align: center;
            font-size: 48px;
        }

        .car_ipt_txt {
            width: 50px;
            height: 30px;
            text-align: center;
            font-size: 22px;
            color: #989697;
            background: #fff;
            outline: 0;
            border: 0;
            float: left;
        }

        .red {
            color: red;
        }

        .addbtn {
            padding: 10px;
            background-color: gray;
            color: #fff;
            border-radius: 5px;
        }

            .addbtn:hover {
                text-decoration: none;
                color: red;
            }

        .jsbtn {
            padding: 10px;
            background-color: darkgray;
            color: #fff;
            border-radius: 5px;
        }

            .jsbtn:hover {
                text-decoration: none;
                color: red;
            }
    </style>
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
    <style type="text/css">
        #num
        {
           width:50px;
        }
        img
        {
          cursor:pointer;
        }
    </style>
    <script type="text/javascript">
        function minus()
        {
          var num=parseInt( document.getElementById("num").value);
           num--;
           if(num==0)
           {
             alert("数量不能为0!");
             num=1;
           }
           document.getElementById("num").value=num;
        }
        
        function add()
        {
           var num=parseInt( document.getElementById("num").value);
           num++;
           document.getElementById("num").value=num;
        }
    </script>
</head>
<body>
    <div class="main_container">
        <div class="center_content">
            <div class="right_content">
                <h2>商品列表
                </h2>
                <p />
                <p></p>
                <form name="mbrRpt" class="noprint" action="" method="post">
                    <div class="filter">
                        <div class="row-fluid">
                            <p class="span4">
                                <label>
                                    分类选择 :
                                </label>
                                <span class="field">
                                    <select name="Status">
                                        <option value="2">全部商品</option>
                                        <option value="3">潮流女装</option>
                                        <option value="2">精品男装</option>
                                        <option value="2">鞋子箱包</option>
                                        <option value="2">美食特产</option>
                                        <option value="2">母婴用品</option>
                                        <option value="2">美容护肤</option>
                                        <option value="2">时尚配饰</option>
                                        <option value="2">数码家电</option>
                                        <option value="2">家具日用</option>
                                    </select>
                                </span>
                            </p>
                            <p class="span4">
                                <input type="button" value="搜索">
                            </p>
                        </div>
                    </div>
                </form>
                <script>
                    loadCombobox(document.mbrRpt.Type, "10");
                </script>
                <hr>
                <br>
                <br />
                <div class="ctr table-responsive" style="overflow-x: auto;">
                    <table class="styled footable no-paging footable-loaded tablet breakpoint" data-page-size="10000">
                        <thead>

                            <tr>
                                <th class="footable-visible footable-first-column">产品名称</th>
                                <th class="footable-visible">产品类别</th>
                                <th class="footable-visible">产品价格</th>
                                <th class="footable-visible">实际价格</th>
                                <th class="footable-visible">订购数量</th>
                                <th class="footable-visible footable-last-column">价格小计</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr style="display: table-row;">
                                <td align="center" class="footable-visible footable-first-column">
                                    <a href="productlistdetail.html" style="display: block; text-decoration: none;">
                                        <div class="zwimgw">
                                            <div class="zwimg">
                                                <img src="../../images/13.gif" />
                                            </div>
                                            <p>共赢国际箱式矿泉能量超滤水机</p>
                                        </div>
                                    </a>
                                </td>
                                <td align="center" class="footable-visible">家具日用</td>
                                <td align="center" class="footable-visible red">￥2999.00</td>
                                <td align="center" class="footable-visible red">￥2999.00</td>
                                <td align="center" class="footable-visible">
                                    <div class="car_span" id="car_span">
                                        <img src="images/minu.jpg" onclick="minus()" />
                                        <input type="text" class="car_ipt_txt" id="car_ipt_txt" maxlength="8" value="1" />
                                        <img src="images/add.jpg" onclick="add()"
                                    </div>
                                </td>
                                <td align="center" class="footable-visible footable-last-column red">￥1000.00</td>
                            </tr>
                            <tr style="display: table-row;">
                                <td align="center" class="footable-visible footable-first-column">
                                    <a href="productlistdetail.html" style="display: block; text-decoration: none;">
                                        <div class="zwimgw">
                                            <div class="zwimg">
                                                <img src="../../images/13.gif" />
                                            </div>
                                            <p>共赢国际箱式矿泉能量超滤水机</p>
                                        </div>
                                    </a>
                                </td>
                                <td align="center" class="footable-visible">家具日用</td>
                                <td align="center" class="footable-visible red">￥2999.00</td>
                                <td align="center" class="footable-visible red">￥2999.00</td>
                                <td align="center" class="footable-visible">
                                    <div class="car_span" id="car_span">
                                        <a href="javascript:;" class="car_reduce" data="-">-</a>
                                        <input type="text" class="car_ipt_txt" id="car_ipt_txt" maxlength="8" value="1" />
                                        <a href="javascript:;" class="car_add" data="+">+</a>
                                    </div>
                                </td>
                                <td align="center" class="footable-visible footable-last-column red">￥1000.00</td>
                            </tr>
                            <tr style="display: table-row;">
                                <td align="right" class="footable-visible" colspan="5">总计金额:</td>
                                <td align="center" class="footable-visible footable-last-column red">￥1000.00</td>
                            </tr>

                        </tbody>
                        <tfoot>
                            <tr>
                                <td colspan="6" class="footable-visible">无记录</td>
                            </tr>
                            <tr style="display: block; margin-top: 20px;">
                                <td align="left" class="footable-visible" colspan="6">收货地址:广东省深圳市南山区南山大道20号
                                </td>
                            </tr>
                            <tr style="display: table-row;">
                                <td align="left" class="footable-visible" colspan="6">收货地址
	   	 <a href="../product/Address.aspx" class="addbtn">使用新地址</a>
                                </td>
                            </tr>
                            <tr style="display: table-row;">
                                <td align="right" class="footable-visible" colspan="6">
                                    <a href="#" class="jsbtn">暂不订购了</a>
                                    <a href="#" class="jsbtn" data-toggle="modal" data-target="#myModal" style="background-color: #2A77C1;">现在去结账</a>
                                </td>
                            </tr>
                        </tfoot>
                    </table>
                </div>
                <ul class="pager">
                    <li><a href="#">当前</a></li>
                    <li><a href="#">下一页</a></li>
                </ul>
            </div>

        </div>
        <!--end of right content-->

    </div>
    <!--end of center content-->
    <!-- 模态框（Modal） -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close"
                        data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myModalLabel">确定支付￥1000.00吗?
                    </h4>
                </div>
                <div class="modal-body">
                    <form action="" method="post" class="form-horizontal" role="form">
                        <div class="form-group">
                            <label for="inputPassword" class="col-md-2 col-sm-2 control-label" style="font-size: 17px;">支付密码</label>
                            <div class="col-md-10 col-sm-10">
                                <input type="password" name="password" id="inputPassword" class="form-control" placeholder="请输入支付密码" />
                            </div>
                        </div>
                    </form>
                    <p>商城点数金额: <small style="color: red;">￥21561.00</small></p>
                    <p class="pull-right"><a href="finddoChangePwdloginapy.html">忘记支付密码?</a></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger">
                        确定
                    </button>
                    <button type="button" class="btn btn-default"
                        data-dismiss="modal">
                        取消
                    </button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>
</body>
</html>
