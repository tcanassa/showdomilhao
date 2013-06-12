using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShowDoMilhao
{
    public partial class ProximaPergunta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GameState g = GameState.Instance;
            valorProxPergunta.Text = g.valores[g.nivelAtual-1].Item2.ToString();
            valorGanhar.Text = g.valorAtual.ToString();
            valorPerder.Text = (g.valorAtual / 2).ToString();
        }

        protected void continuar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }

        protected void parar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Final.aspx");
        }
    }
}