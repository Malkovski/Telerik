<%@ Page Title="Todos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Todos.aspx.cs" Inherits="TODOSystem.Todos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView runat="server" ID="ListViewTodos" ItemType="TODOSystem.Models.Todo" DataKeyNames="Id"
         SelectMethod="ListViewTodos_GetData"
         UpdateMethod="ListViewTodos_UpdateItem"
         DeleteMethod="ListViewTodos_DeleteItem"
         InsertItemPosition="LastItem" InsertMethod="ListViewTodos_InsertItem">

        <LayoutTemplate>
            <table class="table table-bordered table-hover table-striped">
                <thead >
                    <th>
                        <asp:LinkButton Text="Title" runat="server" ID="LinkButtonSortTodoTitle" CommandName="Sort" CommandArgument="Title"/>
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

            <asp:DataPager runat="server" ID="DataPagerTodos" PagedControlID="ListViewTodos" PageSize="10">
                <Fields>
                    <asp:NumericPagerField />
                </Fields>
            </asp:DataPager>

            
        </LayoutTemplate>

        <ItemTemplate>  
            <tr>
                <td class="col-md-10">
                    <asp:Label runat="server" ID="TodoDetailLink" Text="<%#: Item.Title %>" />
                </td>
                <td class="col-md-1">
                    <asp:LinkButton Text="Edit" runat="server" ID="LinkButtonTodosEdit" CommandName="Edit"/>
                </td>
                <td class="col-md-1">
                    <asp:LinkButton Text="Delete" runat="server" ID="LinkButtonTodosDelete" CommandName="Delete"/>
                </td>
            </tr>
        </ItemTemplate>

        <EmptyDataTemplate>
            No results was found!
        </EmptyDataTemplate>

        <EditItemTemplate>
            <tr>
                <td class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBoxEditTitle" Text="<%#: BindItem.Title %>" />
                </td>
                 <td class="col-md-1">
                    <asp:LinkButton Text="Cancel" runat="server" ID="LinkButtonTodosEditCancel" CommandName="Cancel"/>
                </td>
                <td class="col-md-1">
                    <asp:LinkButton Text="Save" runat="server" ID="LinkButtonTodosSave" CommandName="Update"/>
                </td>
            </tr>
        </EditItemTemplate>

        <InsertItemTemplate>
            <tr id="insertFormTodo">
                <td class="col-md-10">
                    <asp:TextBox runat="server" ID="AddTodoTitle" Text="<%#: BindItem.Title %>" />

                </td>
                <td class="col-md-1">
                    <asp:LinkButton Text="Cancel" runat="server" ID="LinkButtonTodosInsertCancel" CommandName="Cancel"/>
                </td>
                <td class="col-md-1">
                    <asp:LinkButton Text="Create" runat="server" ID="LinkButtonTodosSave" CommandName="Insert"/>
                </td>
            </tr>
        </InsertItemTemplate>

    </asp:ListView>
    <asp:Panel runat="server">
            <asp:LinkButton Text="Add Todo" runat="server" ID="LinkButtonInsert" CssClass="btn btn-md btn-primary pull-right" OnClick="LinkButtonInsert_Click"/>
    </asp:Panel>
    
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel runat="server" ID="TodoPanel" CssClass="hidden">
                <asp:FormView runat="server" ID="FormViewInsertTodo" DefaultMode="Insert" ItemType="TODOSystem.Models.Todo" Width="100%"
                     InsertMethod="FormViewInsertTodo_InsertItem">

                    <InsertItemTemplate>
                        <form class="form-horizontal">
                            <fieldset>
                                <legend>Add new Todo</legend>
                                <div class="form-group">
                                    <label for="TextBoxNewTodoTitle" class="col-md-2 control-label">Title</label>
                                    <div class="col-md-10">
                                        <asp:TextBox runat="server" ID="TextBoxNewTodoTitle" Text="<%#: BindItem.Title %>" CssClass="form-control" Width="100%"/>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="TextBoxNewTodoBody" class="col-md-2 control-label">Body</label>
                                    <div class="col-md-10">
                                        <asp:TextBox runat="server" ID="TextBoxNewTodoBody" Text="<%#: BindItem.Body %>" TextMode="MultiLine" CssClass="form-control"/>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="DropDownListCategoriesCreate" class="col-md-2 control-label">Category</label>
                                    <div class="col-md-10">
                                        <asp:DropDownList runat="server" ID="DropDownListCategoriesCreate" ItemType="TODOSystem.Models.Category" CssClass="form-control"
                                        SelectMethod="DropDownListCategoriesCreate_GetData" DataValueField="Id" DataTextField="Name"
                                        SelectedValue="<%#: BindItem.CategoryId %>">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-10 col-md-offset-2">
                                        <div class="col-md-1">
                                            <asp:LinkButton Text="Cancel" runat="server" ID="LinkButtonTodosInsertCancel" CommandName="Cancel" CssClass="btn btn-md btn-info"/>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:LinkButton Text="Create" runat="server" ID="LinkButtonTodosInsert" CommandName="Insert" CssClass="btn btn-md btn-success"/>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </form>
                </div>
                    </InsertItemTemplate>
                </asp:FormView>
            </asp:Panel>
        </ContentTemplate>
       
    </asp:UpdatePanel>
</asp:Content>
