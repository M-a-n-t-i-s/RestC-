<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p class="lead">
            <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p class="lead">
            <asp:Label ID="Label3" runat="server" Text="Amount"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </p>
        <p class="lead">
            <asp:Label ID="Label5" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Показать" OnClick="Button1_Click1"  />
            <asp:Button ID="Button2" runat="server" Text="Добавить" OnClick="Button2_Click1" />
            <asp:Button ID="Button3" runat="server" Text="Удалить" OnClick="Button3_Click1" />
            <asp:Button ID="Button4" runat="server" Text="Изменить (KEY Id)" OnClick="Button4_Click1" />
        </p>
    </div>

    <div >
        <div >
            <h2>
                <asp:ListBox ID="ListBox1" runat="server" Width="100%"></asp:ListBox>
                <asp:Label ID="Label6" runat="server" Text="Вы хотите точно удалить?"></asp:Label>
&nbsp;<asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Да" />
&nbsp;<asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Нет" />
            </h2>
            <p>
                &nbsp;</p>
        </div>
    </div>
</asp:Content>
