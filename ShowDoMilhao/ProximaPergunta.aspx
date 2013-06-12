<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProximaPergunta.aspx.cs" Inherits="ShowDoMilhao.ProximaPergunta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Resposta correta!
    </div>
    <div>
    A próxima pergunta valerá <asp:Label runat="server" ID="valorProxPergunta"></asp:Label>,00
    <br />
    Se parar agora, ganhará R$ <asp:Label runat="server" ID="valorGanhar"></asp:Label>,00
    <br />
    Se continuar e errar, ganhará R$ <asp:Label runat="server" ID="valorPerder"></asp:Label>,00
    <br />
    Deseja continuar?
    </div>
        <asp:Button ID="parar" runat="server" Text="parar" onclick="parar_Click" />
        <asp:Button ID="continuar" runat="server" Text="continuar" 
            onclick="continuar_Click" />
    </div>
    </form>
</body>
</html>
