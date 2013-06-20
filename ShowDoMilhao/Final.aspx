<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Final.aspx.cs" Inherits="ShowDoMilhao.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <asp:Image runat="server" ID="Ganhou" ImageUrl="Images/pot_of_gold1.png" CssClass="Corpo" />
        <asp:Image runat="server" ID="Perdeu" ImageUrl="Images/burning-cash.jpg" CssClass="Corpo"/>
    <div class="Final">
        <div id="FimDeJogo">
            Fim de jogo.<br />
            <asp:Label runat="server" ID="errouLabel">Você errou!</asp:Label>
            <br />
            Você ganhou: R$ <asp:Label ID="valorGanho" runat="server" Text="Label"></asp:Label>,00
        </div>  
        <asp:Panel ID="respostaCorreta" runat="server">
            Pergunta: <asp:Label ID="labelPergunta" runat="server" Text="Label" CssClass="PerguntaResposta"></asp:Label>
            <br />
            Resposta correta: <asp:Label ID="labelRespostaCerta" runat="server" Text="Label" CssClass="PerguntaResposta"></asp:Label>
        </asp:Panel>        
    </div>
    <div class="CaixaRank">
        <div class="InsiraNome">
            <asp:Panel runat="server" ID="campoNome">
                <asp:Label ID="insertLabel" runat="server">Insira seu nome:</asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="Ok" onclick="gravarNoBanco" />
            </asp:Panel>
        </div>
        <asp:Panel ID="tabelaRank" runat="server">
            <div class="Tabela">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="SqlDataSource1" CssClass="TabelaRank">
                    <Columns>
                        <asp:BoundField DataField="nome" HeaderText="NOME" SortExpression="nome" />
                        <asp:BoundField DataField="data" HeaderText="DATA" SortExpression="data" />
                        <asp:BoundField DataField="valor" HeaderText="VALOR" SortExpression="valor" DataFormatString="{0:c}" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="SELECT [nome], [data], [valor] FROM [Ranking] ORDER BY [valor] DESC, [pulos] DESC">
                </asp:SqlDataSource>
            </div> 
        </asp:Panel>       
        <asp:Button ID="Button1" runat="server" onclick="reiniciar" Text="Começar novamente" CssClass="BotaoRecomeçar"/>
    </div>
</asp:Content>
