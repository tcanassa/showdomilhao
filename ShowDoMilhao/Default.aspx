<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ShowDoMilhao._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/jquery-2.0.2.js" type="text/javascript"></script>
    <link href="Styles/customradio.css" rel="stylesheet" type="text/css" />
 </asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

	<div id="bg" class="Corpo">
    
        <img src="Images/Silvio_qual_a_pergunta.jpg" />

	</div>

    <div class="Logo"><img src="Images/logo1.png" /></div>
            
    <div class="Caixa">

    <h3>
        <div class="Questao">
            <asp:Label ID="labelNumQuest" runat="server" Text="1"/>. <asp:Label ID="labelQuest" runat="server" Text="Questao 1?" />
            </div>
            <div class="RadioButtonList1">
             <asp:RadioButtonList ID="RadioButtonList1" runat="server" >
                <asp:ListItem Value="1">resposta 1</asp:ListItem>
                <asp:ListItem Value="2">resposta 2</asp:ListItem>
                <asp:ListItem Value="3">resposta 3</asp:ListItem>
                <asp:ListItem Value="4">resposta 4</asp:ListItem>
            </asp:RadioButtonList>
            </div>
    
            <div class="Botao">
                   
                    <asp:Button ID="buttonPular" runat="server" Text="Pular: 3" 
                        onclick="onPular" CssClass="css3button" />
                  
                    
                    <asp:Button ID="buttonResponder" runat="server" Text="Responder" 
                        onclick="onResponder" CssClass="css3button"/>
                   
                </div>
    
            <div class="Panel1">
            <asp:Panel ID="Panel1" runat="server">
                    Acertar: <asp:Label ID="labelAcertar" runat="server"/> 
                    <br />
                    Errar: <asp:Label ID="labelErrar" runat="server"/> 
                    <br />
                    Valor atual: <asp:Label ID="labelAtual" runat="server"/> 
                    <br />
                    <asp:Label ID="labelTeste" runat="server"/> 
                    <br />
                </asp:Panel>
           </div>
       </h3>
    </div>
    
</asp:Content>
