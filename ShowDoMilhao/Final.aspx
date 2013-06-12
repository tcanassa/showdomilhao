<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Final.aspx.cs" Inherits="ShowDoMilhao.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="errouLabel">Você errou!</asp:Label>
    <br />
    Fim de jogo. Você ganhou R$ <asp:Label ID="valorGanho" runat="server" Text="Label"></asp:Label>,00
    <br />
    <asp:Panel ID="respostaCorreta" runat="server">
        Pergunta: <asp:Label ID="labelPergunta" runat="server" Text="Label"></asp:Label>
        <br />
        Resposta correta: <asp:Label ID="labelRespostaCerta" runat="server" Text="Label"></asp:Label>
    </asp:Panel>
    <br />
    <asp:Panel runat="server" ID="campoNome">
        <asp:Label ID="insertLabel" runat="server">Insira seu nome:</asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="Ok" onclick="gravarNoBanco" />
    </asp:Panel>
    <br />
    <asp:Panel ID="tabelaRank" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome" />
                <asp:BoundField DataField="data" HeaderText="data" SortExpression="data" />
                <asp:BoundField DataField="valor" HeaderText="valor" 
                    SortExpression="valor" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            
            SelectCommand="SELECT [nome], [data], [valor] FROM [Ranking] ORDER BY [valor] DESC, [pulos] DESC">
        </asp:SqlDataSource>
    </asp:Panel>
    <br />
    <asp:Button ID="Button1" runat="server" onclick="reiniciar" Text="Começar novamente" />
    </asp:Content>
