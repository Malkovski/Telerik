<%@ Page Title="Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="TODOSystem.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView runat="server" ID="ListViewCategories" ItemType="TODOSystem.Models.Category" DataKeyNames="Id"
        SelectMethod="ListViewCategories_GetData"
        UpdateMethod="ListViewCategories_UpdateItem"
        DeleteMethod="ListViewCategories_DeleteItem" 
        InsertMethod="ListViewCategories_InsertItem" InsertItemPosition="LastItem">

        <LayoutTemplate>
            <table class="table table-bordered table-hover table-striped">
                <thead >
                    <th>
                        <asp:LinkButton Text="Name" runat="server" ID="LinkButtonSortCategoryName" CommandName="Sort" CommandArgument="Name"/>
                    </th>
                    <th>
                        <asp:Label Text="" runat="server" ID="LabelMethod" />
                    </th>
                    <th>
                        <asp:Label Text="" runat="server" ID="Label1" />
                    </th>
                </thead>
                <tbody>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"/>
                </tbody>
            </table>

            <asp:DataPager runat="server" ID="DataPagerCategorys" PagedControlID="ListViewCategories" PageSize="10">
                <Fields>
                    <asp:NumericPagerField />
                </Fields>
            </asp:DataPager>

            
        </LayoutTemplate>

        <ItemTemplate>  
            <tr>
                <td class="col-md-10">
                    <asp:Label runat="server" ID="CategoryDetailLink" Text="<%#: Item.Name %>" />

                </td>
                <td class="col-md-1">
                    <asp:LinkButton Text="Edit" runat="server" ID="LinkButtonCategorysEdit" CommandName="Edit"/>
                </td>
                <td class="col-md-1">
                    <asp:LinkButton Text="Delete" runat="server" ID="LinkButtonCategorysDelete" CommandName="Delete"/>
                </td>
            </tr>
        </ItemTemplate>

        <EmptyDataTemplate>
            No results was found!
        </EmptyDataTemplate>

        <EditItemTemplate>
            <tr>
                <td class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBoxEditName" Text="<%#: BindItem.Name %>" />

                </td>
                 <td class="col-md-1">
                    <asp:LinkButton Text="Cancel" runat="server" ID="LinkButtonCategorysEditCancel" CommandName="Cancel"/>
                </td>
                <td class="col-md-1">
                    <asp:LinkButton Text="Save" runat="server" ID="LinkButtonCategorysSave" CommandName="Update"/>
                </td>
            </tr>
        </EditItemTemplate>

        <InsertItemTemplate>
            <tr id="insertFormCategory">
                <td class="col-md-10">
                    <asp:TextBox runat="server" ID="AddCategoryName" Text="<%#: BindItem.Name %>" />

                </td>
                <td class="col-md-1">
                    <asp:LinkButton Text="Cancel" runat="server" ID="LinkButtonCategorysInsertCancel" CommandName="Cancel"/>
                </td>
                <td class="col-md-1">
                    <asp:LinkButton Text="Create" runat="server" ID="LinkButtonCategorysSave" CommandName="Insert"/>
                </td>
            </tr>
        </InsertItemTemplate>

    </asp:ListView>
    <asp:Panel runat="server">
            <asp:LinkButton Text="Add category" runat="server" ID="LinkButtonInsert" CssClass="btn btn-md btn-primary pull-right" OnClick="LinkButtonInsert_Click"/>
    </asp:Panel>
    
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel runat="server" ID="CategoryPanel" CssClass="hidden">
                <div class="well">
                    <h3>Add new category</h3>
                    <div class="row">
                        <asp:TextBox runat="server" ID="TextBoxNewCategoryName"/>
                    </div>
                    <div class="row">
                    <div class="col-md-3">
                        <asp:LinkButton Text="Cancel" runat="server" ID="LinkButtonCategorysInsertCancel"/>
                    </div>
                    <div class="col-md-3">
                        <asp:LinkButton Text="Create" runat="server" ID="LinkButtonCategorysInsert" OnClick="LinkButtonCategorysSave_Click"/>
                    </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="LinkButtonCategorysInsert"  EventName="Click"/>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
