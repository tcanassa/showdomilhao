using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ShowDoMilhao
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GameState g = GameState.Instance;
            valorGanho.Text = g.valorAtual.ToString() ;
            labelPergunta.Text = g.questaoAtual.pergunta;
            labelRespostaCerta.Text = g.questaoAtual.respostaCorreta;
            if (g.errouPergunta)
            {
                respostaCorreta.Visible = true;
                errouLabel.Visible = true;
            }
            else
            {
                respostaCorreta.Visible = false;
                errouLabel.Visible = false;
            }
        }

        protected void reiniciar(object sender, EventArgs e)
        {
            GameState g = GameState.Instance;
            g.inicializado = false;
            g.iniciar();
            g.mudarQuestao();
            Response.Redirect("/Default.aspx");
        }

        protected void gravarNoBanco(object sender, EventArgs e)
        {
            GameState g = GameState.Instance;

            if (string.IsNullOrEmpty(TextBox1.Text))
                return;

            campoNome.Visible = false;

            string nome = TextBox1.Text;

            DateTime now = DateTime.Now;

            DateTime d = new DateTime(now.Year,now.Month,now.Day,now.Hour,now.Minute,now.Second);

            string data = d.ToString("MM/dd/yyyy HH:mm:ss");

            int valor = g.valorAtual;

            int pulos = g.contaPulo;

            using (SqlConnection sqlc = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"))
            {
                sqlc.Open();
                string query = string.Format("INSERT INTO Ranking VALUES ('{0}','{1}','{2}','{3}')", nome, data, pulos, valor);
                SqlCommand sqlcommand = new SqlCommand(query, sqlc);
                sqlcommand.CommandText = query;
                sqlcommand.ExecuteNonQuery();
            }
            //Atualiza tabela de ranking
            GridView1.DataBind();
        }
    }
}