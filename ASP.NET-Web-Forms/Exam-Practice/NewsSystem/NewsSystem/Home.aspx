<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NewsSystem.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>News</h1>
   <h2>Most popular articles</h2>
    <asp:ListView runat="server" ID="LictViewMostPopularArticles" ItemType="NewsSystem.Models.Article"
         SelectMethod="LictViewMostPopularArticles_GetData" DataKeyNames="Id">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"/>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="row">
                <h3>
                    <asp:HyperLink NavigateUrl='<%#: string.Format("~/Details/ArticleDetail.aspx?id={0}", Item.Id) %>' runat="server" ID="HyperLinkArticleName"
                         Text='<%#: Item.Title %>'/>
                     <small><%#: Item.Category.Name %></small>
                </h3>
                <p>
                    <%#: Item.Content %>
                </p>
                <p>Likes: <%#: Item.Likes %></p>
                <div>
                    <i>by <%#: Item.Author.UserName %></i>
                    <i>created on: <%#: Item.DateCreated %></i>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <h2>All categories</h2>

    <asp:ListView runat="server" ID="ListViewAllCategoriesHomePage" ItemType="NewsSystem.Models.Category"
         SelectMethod="ListViewAllCategoriesHomePage_GetData" GroupItemCount="2">

        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"/>
            </div>
        </GroupTemplate>

        <EmptyDataTemplate>
            No arrticles.
        </EmptyDataTemplate>

        <ItemTemplate>
            <div class="col-md-6">
                 <h3><%#: Item.Name %></h3>
                <asp:Repeater runat="server" ID="RepeaterArticlesHomePage" ItemType="NewsSystem.Models.Article" SelectMethod="RepeaterArticlesHomePage_GetData">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink NavigateUrl='<%#: string.Format("~/Details/ArticleDetail.aspx?id={0}", Item.Id) %>' runat="server" 
                                Text='<%# string.Format("{0} by <i>{1}</i>", Item.Title, Item.Author.UserName) %>'/>
                        </li>
                    </ItemTemplate>
                  
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div> 
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
