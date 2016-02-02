<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddVideo.aspx.cs" Inherits="YouTubePlaylist.Web.Authorized.AddVideo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate >

            <div class="form-group">
                <label for="TextBoxNewVideo" class="col-md-2 control-label">URL: </label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBoxNewVideo"
                        CssClass="form-control" />
                    <asp:CustomValidator ErrorMessage="Required field!" ID="CategoryNameValidator"
                             ControlToValidate="TextBoxNewVideo"
                             runat="server" OnServerValidate="CategoryNameValidator_ServerValidate"
                             ValidateEmptyText="true" ForeColor="red"/> 

                    <asp:LinkButton Text="Insert" runat="server" ID="LinkButton2"
                            OnClick="LinkButtonPlaylistInsert_Click" CssClass="btn btn-md btn-success" />
                    <asp:Button Text="Cancel" runat="server" ID="Button2"
                            OnClick="Button2_Click" CssClass="btn btn-md btn-danger" />
                </div>
            </div>
           
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
