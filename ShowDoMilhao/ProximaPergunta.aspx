<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProximaPergunta.aspx.cs" Inherits="ShowDoMilhao.ProximaPergunta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Corpo">
           <img src="Images/silvio_certa_resposta.jpeg" />
    </div>
    
    <div class="CertaResposta">
            CERTA RESPOSTA!!!
    </div>

 <h3>
    <div class="Caixa">    
            <div class="Valores">
            A próxima pergunta valerá: R$ <asp:Label runat="server" ID="valorProxPergunta"></asp:Label>,00
            <br />
            <br />
            Se parar agora, ganhará: R$ <asp:Label runat="server" ID="valorGanhar"></asp:Label>,00
            <br />
            <br />
            Se continuar e errar, ganhará: R$ <asp:Label runat="server" ID="valorPerder"></asp:Label>,00
            <br />
            <br />            
            </div>

            <div class="BotaoProximaPergunta">
                Deseja continuar?
                <br />
                <asp:Button ID="parar" runat="server" Text="Parar" onclick="parar_Click" />
                <asp:Button ID="continuar" runat="server" Text="Continuar" 
                    onclick="continuar_Click" />
            </div>        
    </div>
 </h3>
</asp:Content>
