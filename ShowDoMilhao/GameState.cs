using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ShowDoMilhao
{
    public struct Questao
    {
        public int id;
        public string pergunta;
        public string resposta1;
        public string resposta2;
        public string resposta3;
        public string resposta4;
        public int resposta;
        public string nivel;

        public string respostaCorreta
        {
            get
            {
                if (resposta == 1)
                {
                    return resposta1;
                }
                else if (resposta == 2)
                {
                    return resposta2;
                }
                else if (resposta == 3)
                {
                    return resposta3;
                }
                else
                {
                    return resposta4;
                }
            }
        }
    }

    
    public class GameState
    {
        private static GameState instance;

        private GameState() 
        {
            valores = new List<Tuple<int,int>>();
      
            valores.Add(Tuple.Create(1, 1000));
            valores.Add(Tuple.Create(2, 2000));
            valores.Add(Tuple.Create(3, 3000));
            valores.Add(Tuple.Create(4, 4000));
            valores.Add(Tuple.Create(5, 5000));
            valores.Add(Tuple.Create(6, 10000));
            valores.Add(Tuple.Create(7, 20000));
            valores.Add(Tuple.Create(8, 30000));
            valores.Add(Tuple.Create(9, 40000));
            valores.Add(Tuple.Create(10, 50000));
            valores.Add(Tuple.Create(11, 100000));
            valores.Add(Tuple.Create(12, 200000));
            valores.Add(Tuple.Create(13, 300000));
            valores.Add(Tuple.Create(14, 400000));
            valores.Add(Tuple.Create(15, 500000));
            valores.Add(Tuple.Create(16, 1000000));

            valorAtual = 0;
            nivelAtual = 1;
            contaPulo = 3;

            questoesNivelA = new List<Questao>();
            questoesNivelB = new List<Questao>();
            questoesNivelC = new List<Questao>();
            questoesNivelD = new List<Questao>();

            popularPerguntas();

            inicializado = false;
            errouPergunta = false;
        }

        public static GameState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameState();
                }
                return instance;
            }
        }

        /// <summary>
        /// Representa a quantidade de dinheiro acumulada pelo jogador até o momento
        /// </summary>
        public int valorAtual;

        /// <summary>
        /// Representa a quantidade de questões respondidas pelo jogador até o momento.
        /// </summary>
        public int questoesRespondidas;

        /// <summary>
        /// Representa o nivel atual do jogador (1 a 16)
        /// </summary>
        public int nivelAtual;

        /// <summary>
        /// Indica se o jogo foi inicializado. Usado pelo construtor da tela principal, para carregar primeira pergunta
        /// </summary>
        public bool inicializado;

        /// <summary>
        /// Indica se usuario errou pergunta. Usado pela tela final para exibir ou nao a resposta correta
        /// </summary>
        public bool errouPergunta;

        /// <summary>
        /// Representa quantidade de pulos que usuario pode realizar
        /// </summary>
        public int contaPulo;

        /// <summary>
        /// Instancia de struct com a questao no momento.
        /// </summary>
        public Questao questaoAtual;

        public List<Questao> questoesNivelA;
        public List<Questao> questoesNivelB;
        public List<Questao> questoesNivelC;
        public List<Questao> questoesNivelD;

        public int Premio
        {
            get
            {
                return valores[nivelAtual-1].Item2; //-1 pq indices de lista tamanho 'n' vão de 0 até n-1
            }
        }

        /// <summary>
        /// Inicia estado do jogo
        /// </summary>
        public void iniciar()
        {
            valorAtual = 0;
            nivelAtual = 1;
            contaPulo = 3;
            questoesNivelA.Clear();
            questoesNivelB.Clear();
            questoesNivelC.Clear();
            questoesNivelD.Clear();
            popularPerguntas();
            inicializado = true;
        }

        /// <summary>
        /// Usado para retornar letra do nivel (A, B, C, ou D)
        /// </summary>
        /// <param name="nivelInt">Representa nivel atual em inteiros (1 a 16)</param>
        /// <returns>Representacao em letra do nivel atual, usado para filtro da busca no SQL</returns>
        private string getNivel(int nivelInt)
        {
            if (nivelInt >= 1 && nivelInt <= 5)
            {
                return "A";
            }
            else if (nivelInt >= 6 && nivelInt <= 10)
            {
                return "B";
            }
            else if (nivelInt >= 11 && nivelInt <= 15)
            {
                return "C";
            }
            else
            {
                return "D";
            }
        }

        private void popularPerguntas()
        {
            using (SqlConnection sqlc = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"))
            {
                sqlc.Open();
                string query = string.Format("SELECT * FROM Perguntas");
                SqlCommand sqlcommand = new SqlCommand(query, sqlc);

                SqlDataReader sqlreader = sqlcommand.ExecuteReader();

                if (sqlreader.HasRows)
                {
                    while (sqlreader.Read())
                    {
                        Questao q = new Questao();
                        q.id = (int)sqlreader["id"];
                        q.pergunta = (string)sqlreader["pergunta"];
                        q.resposta1 = (string)sqlreader["resposta1"];
                        q.resposta2 = (string)sqlreader["resposta2"];
                        q.resposta3 = (string)sqlreader["resposta3"];
                        q.resposta4 = (string)sqlreader["resposta4"];
                        q.resposta = (int)sqlreader["respostacorreta"];
                        q.nivel = (string)sqlreader["tipo"];

                        if (q.nivel == "A")
                        {
                            questoesNivelA.Add(q);
                        }
                        else if (q.nivel == "B")
                        {
                            questoesNivelB.Add(q);
                        }
                        else if (q.nivel == "C")
                        {
                            questoesNivelC.Add(q);
                        }
                        else
                        {
                            questoesNivelD.Add(q);
                        }

                    }
                }
                sqlreader.Close();
            }
        }

        public void mudarQuestao()
        {
            Random r = new Random();
            string nivelChar = getNivel(nivelAtual);
            List<Questao> listaQuestoes = new List<Questao>();

            if (nivelChar == "A")
            {
                listaQuestoes = questoesNivelA;
            }
            else if (nivelChar == "B")
            {
                listaQuestoes = questoesNivelB;
            }
            else if (nivelChar == "C")
            {
                listaQuestoes = questoesNivelC;
            }
            else if (nivelChar == "D")
            {
                listaQuestoes = questoesNivelD;
            }

            int randomIndex = r.Next(listaQuestoes.Count);
            questaoAtual = listaQuestoes[randomIndex];
            listaQuestoes.RemoveAt(randomIndex);
        }

        /// <summary>
        /// Tabela de valores
        /// </summary>
        public List<Tuple<int,int>> valores;

    }
}