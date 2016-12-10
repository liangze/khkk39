<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bonus.aspx.cs" Inherits="Web.admin.finance.Bonus" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>�����ѯ</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body class="subBody">
    <form class="box_con" runat="server">
        <div class="box box_width">
            <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th>
                            ֱ�ƽ��ۼ�
                        </th>
                        <th>
                            ��֯���ۼ�
                        </th>
                        <th>
                            �쵼���ۼ�
                        </th>
                        <th>
                            �ֱҽ��ۼ�
                        </th>
                        <th>
                            ��ҽ��ۼ�
                        </th>
                        <th>
                            ��Ȩ���ۼ�
                        </th>
                        <th>
                            �����ۼ�
                        </th>
                    </tr>
                    <tr>
                        <td align="center">
                            <%=GetBonus(0, 1)%>
                        </td>
                        <td align="center">
                            <%=GetBonus(0, 2)%>
                        </td>
                        <td align="center">
                            <%=GetBonus(0, 3)%>
                        </td>
                        <td align="center">
                            <%=GetBonus(0, 4)%>
                        </td>
                        <td align="center">
                            <%=GetBonus(0, 5)%>
                        </td>
                        <td align="center">
                            <%=GetBonus(0, 6)%>
                        </td>
                        <td align="center">
                            <%=GetBonusAllTotal(0, "Amount")%>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">��ѯ</legend>�������ڣ�<asp:TextBox ID="txtStar" tip="�����������"
                        runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                    ��<asp:TextBox ID="txtEnd" tip="�����������" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                        OnClick="btnSearch_Click"> �� �� </asp:LinkButton>
                    &nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="LinkButton3_Click"> �� �� </asp:LinkButton>
                </fieldset>
            </div>
            <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th>
                            ֱ�ƽ�
                        </th>
                        <th>
                            ��֯��
                        </th>
                        <th>
                            �쵼��
                        </th>
                        <th>
                            �ֱҽ�
                        </th>
                        <th>
                            ��ҽ�
                        </th>
                        <th>
                            ��Ȩ��
                        </th>
                        <th>
                            ʵ��
                        </th>
                        <th>
                            ��������
                        </th>
                        <th>
                            �鿴��ϸ
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("Recommend")%><!--1.�Ƽ���-->
                                </td>
                                <td align="center">
                                    <%#Eval("zz")%><!--2.��֯��-->
                                </td>
                                <td align="center">
                                    <%#Eval("lead")%><!--3.�쵼��-->
                                </td>
                                <td align="center">
                                    <%#Eval("chibi")%><!--4.�ֱҽ�-->
                                </td>
                                <td align="center">
                                    <%#Eval("cunbi")%><!--5.��ҽ�-->
                                </td>
                                <td align="center">
                                    <%#Eval("jiaquan")%><!--6.��Ȩ��-->
                                </td>
                                <td align="center">
                                    <%#Eval("sf")%><!--ʵ��-->
                                </td>
                                <td align="center">
                                    <%#Eval("SttleTime")%><!--��������-->
                                </td>
                                <td align="center">
                                    <asp:LinkButton ID="lbtnDetail" runat="server" PostBackUrl='<%#Eval("SttleTime","BonusDetail.aspx?SttleTime={0}") %>'><%=GetLanguage("ViewDetails")%><!--�鿴��ϸ--></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="8" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                    ��Ǹ��Ŀǰ���ݿ�����������ʾ��</span>
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="nextpage cBlack">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="��ҳ"
                        LastPageText="βҳ" NextPageText="��һҳ" PrevPageText="��һҳ" AlwaysShow="True" InputBoxClass="pageinput"
                        NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                        SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                        SubmitButtonText="" textafterpageindexbox=" ҳ" textbeforepageindexbox="ת�� " OnPageChanged="AspNetPager1_PageChanged">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
