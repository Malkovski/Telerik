<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleDetail.aspx.cs" Inherits="NewsSystem.Details.ArticleDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="FormViewArticleDetail" ItemType="NewsSystem.Models.Article" DataKeyNames="Id" SelectMethod="FormViewArticleDetail_GetItem">
        <ItemTemplate>
            <table style="border-collapse:collapse;" cellspacing="0">
                <tbody>
                    <tr>
                        <td colspan="2">
                            
                            <div>			
                                <div class="like-control col-md-1">
                                    <div>Likes</div>
                                    <div>
                                        <asp:LinkButton runat="server" ID="ButtonUpVote" CssClass="btn btn-default glyphicon glyphicon-chevron-up"
                                             OnClick="ButtonUpVote_Click" />
                                        <asp:Label Text="<%#: Item.Likes %>" runat="server" ID="LikesResult" CssClass="like-value"/>
                                        <asp:LinkButton runat="server" ID="ButtonDownVote" CssClass="btn btn-default glyphicon glyphicon-chevron-down"
                                             OnClick="ButtonDownVote_Click" />
                                    </div>
                                </div>    
                            </div>
                            <h2><%#: Item.Title %> <small>Category: <%#: Item.Category.Name %></small></h2>
                            <p><%#: Item.Content %><p>
                                <span>Author: <%#: Item.Author.UserName %></span>
                                <span class="pull-right"><%#: Item.DateCreated %></span>
                            </p>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
