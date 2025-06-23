using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace LocalizadorDeCep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lblUf_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cep = txbCep.Text;
            string url = $"https://viacep.com.br/ws/{cep}/json/";
            if(cep.Length < 8)
            {
                MessageBox.Show("CEP inválido", "Erro!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                //Limita a utilização do webClient dentro do escopo:
                using (WebClient navegador = new WebClient())
                {
                    string conteudo = navegador.DownloadString(url);
                    // Converter para UTF-8 (corrigir acentuação)
                    conteudo = Encoding.UTF8.GetString(Encoding.Default.GetBytes(conteudo));
                    //Instanciar um obj do tipo endereco
                    Endereco endereco = new Endereco();

                    endereco = JsonConvert.DeserializeObject<Endereco>(conteudo);

                    // Verificar se endereco.Cep não é nulo:
                    if (!string.IsNullOrEmpty(endereco.Cep))
                    {

                        lblCep.Text = $"CEP:{endereco.Cep}";
                        lblBairro.Text = $"Bairro:{endereco.Bairro}";
                        lblComplemento.Text = $"Complemento:{endereco.Complemento}";
                        lblDdd.Text = $"DDD:{endereco.Ddd}";
                        lblRegiao.Text = $"Região:{endereco.Regiao}";
                        lblUnidade.Text = $"Unidade:{endereco.Unidade}";
                        lblLogradouro.Text = $"Logradouro:{endereco.Logradouro}";
                        lblUf.Text = $"UF:{endereco.Uf}";
                        lblEstado.Text = $"Estado:{endereco.Estado}";
                        lblLocalidade.Text = $"Localidade:{endereco.Localidade}";
                    }

                    else
                    {
                        MessageBox.Show("CEP não encontrado! ");
                    }
                }
               
            }
        }
    }
}
