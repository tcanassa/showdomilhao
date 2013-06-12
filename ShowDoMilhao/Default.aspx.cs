using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ShowDoMilhao
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GameState g = GameState.Instance;
            buttonPular.Text = "Pular: " + g.contaPulo;
            buttonPular.Enabled = g.contaPulo != 0 ? true : false;
            if (!g.inicializado)
            {
                g.iniciar();
                g.mudarQuestao();
            }
            atualizarPergunta();
            atualizaQuadro();
        }

        private void atualizarPergunta()
        {
            GameState g = GameState.Instance;
            labelQuest.Text = g.questaoAtual.pergunta;
            labelNumQuest.Text = g.nivelAtual.ToString();
            RadioButtonList1.Items.FindByValue("1").Text = g.questaoAtual.resposta1;
            RadioButtonList1.Items.FindByValue("2").Text = g.questaoAtual.resposta2;
            RadioButtonList1.Items.FindByValue("3").Text = g.questaoAtual.resposta3;
            RadioButtonList1.Items.FindByValue("4").Text = g.questaoAtual.resposta4;
        }

        protected void onResponder(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex < 0)
                return;

            GameState g = GameState.Instance;

            if ((RadioButtonList1.SelectedIndex + 1) == g.questaoAtual.resposta)
            {
                g.errouPergunta = false;
                //acertou, muda premio, muda a questão, sobe um nivel
                g.valorAtual = g.Premio;

                if (g.nivelAtual < 16) //nivel maximo = 16
                {
                    g.nivelAtual = g.nivelAtual + 1;
                    g.mudarQuestao();
                    labelNumQuest.Text = g.nivelAtual.ToString();
                    atualizarPergunta();
                    atualizaQuadro();
                    Response.Redirect("/ProximaPergunta.aspx");
                }
                else //jogo terminou
                {
                    Response.Redirect("/Final.aspx");
                }
            }
            else
            {
                g.errouPergunta = true;
                //Se ultimo nivel, perde tudo. Se não, ganha metade, Termina programa
                if (g.nivelAtual == 16)
                {
                    g.valorAtual = 0;
                }
                else
                {
                    g.valorAtual = g.valorAtual / 2;
                }
                Response.Redirect("/Final.aspx");
            }
        }

        protected void onPular(object sender, EventArgs e)
        {
            GameState g = GameState.Instance;
            int pulo = g.contaPulo;
            if (pulo > 0)
            {
                pulo--;
                g.contaPulo = pulo;
                mudarPergunta();
                if (pulo == 0)
                    buttonPular.Enabled = false;
            }
            buttonPular.Text = "Pular: " + pulo;
        }

        protected void mudarPergunta()
        {
            GameState g = GameState.Instance;
            g.mudarQuestao();
            labelQuest.Text = g.questaoAtual.pergunta;
            RadioButtonList1.Items.FindByValue("1").Text = g.questaoAtual.resposta1;
            RadioButtonList1.Items.FindByValue("2").Text = g.questaoAtual.resposta2;
            RadioButtonList1.Items.FindByValue("3").Text = g.questaoAtual.resposta3;
            RadioButtonList1.Items.FindByValue("4").Text = g.questaoAtual.resposta4;
        }

        protected void atualizaQuadro()
        {
            labelAcertar.Text = GameState.Instance.valores[GameState.Instance.nivelAtual - 1].Item2.ToString();
            labelErrar.Text = (GameState.Instance.valorAtual / 2).ToString();
            labelAtual.Text = GameState.Instance.valorAtual.ToString();
        }
    }
}
