<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecommendTree1.aspx.cs" Inherits="Web.user.team.RecommendTree1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>直系图</title>
    <link href="../../static/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../static/css/ui.fancytree.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="right_content">
            <h2><%=GetLanguage("ThisFigure")%></h2>
            <div style='width: 765px;'>
                <div id="tree">
                    <asp:TreeView ID="TreeView1" runat="server" LeafNodeStyle-CssClass="LeafNodesStyle" OnTreeNodeExpanded="TreeView1_TreeNodeExpanded"
                        CssClass="TreeView" NodeStyle-CssClass="NodeStyle" ParentNodeStyle-CssClass="ParentNodeStyle"
                        RootNodeStyle-CssClass="RootNodeStyle" SelectedNodeStyle-CssClass="SelectedNodeStyle"
                        LeafNodeStyle-Width="100%" NodeStyle-Width="100%" ParentNodeStyle-Width="100%"
                        RootNodeStyle-Width="100%" SelectedNodeStyle-Width="100%" ImageSet="Arrows" MaxDataBindDepth="1"
                        ExpandDepth="1">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <SelectedNodeStyle CssClass="SelectedNodeStyle" Width="100%" Font-Underline="True"
                            ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px"></SelectedNodeStyle>
                        <RootNodeStyle CssClass="RootNodeStyle" Width="100%"></RootNodeStyle>
                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <LeafNodeStyle CssClass="LeafNodesStyle" Width="100%"></LeafNodeStyle>
                    </asp:TreeView>
                </div>
            </div>
            <br />
            <div class="dataTable" style="overflow: auto;">
                <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
            </div>
        </div>

    </form>
</body>
</html>
