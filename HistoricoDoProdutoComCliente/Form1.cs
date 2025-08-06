using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace HistoricoProdutosAppComCliente
{
    public partial class Form1 : Form
    {
        private bool modoSelecaoProduto = false;

        public Form1()
        {
            InitializeComponent();

            // Inicializa valores padrão das datas (últimos 30 dias)
            dtpDataInicial.Value = DateTime.Today.AddDays(-30);
            dtpDataFinal.Value = DateTime.Today;

            dgvHistorico.CellClick += dgvHistorico_CellClick;
        }

        private void dgvHistorico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvHistorico.Columns.Contains("descricao"))
            {
                txtBusca.Text = dgvHistorico.Rows[e.RowIndex].Cells["descricao"].Value.ToString();
                modoSelecaoProduto = true;

                btnPesquisar.PerformClick();

                modoSelecaoProduto = false;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string codigo = txtBuscaCodigo.Text.Trim();
            string nome = txtBusca.Text.Trim();
            DateTime dataInicial = dtpDataInicial.Value.Date;
            DateTime dataFinal = dtpDataFinal.Value.Date.AddDays(1).AddTicks(-1); // Inclui o dia completo

            if (string.IsNullOrEmpty(codigo) && string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Digite o código ou parte do nome do produto.");
                return;
            }

            // Feedback visual durante a consulta
            btnPesquisar.Enabled = false;
            btnPesquisar.Text = "Buscando...";
            Application.DoEvents();

            dgvHistorico.DataSource = null;
            dgvHistorico.Rows.Clear();

            string connString = "Server=localhost;Database=seu_banco_de_dados;Uid=seu_usuario;Pwd=sua_senha;Charset=utf8;";
            string query = @"
                SELECT
                    p.codigo,
                    p.descricao,
                    h.data,
                    h.op,
                    h.quantidade,
                    v.cupom AS Pedido,
                    c.cupom AS NFCe,
                    f.ide_nnf AS NFe,
                    e.documento,
                    h.fornecedor,
                    h.saldo,
                    u.usuario,
                    h.obs,
                    COALESCE(gv.nome_razaosocial, gc.nome_razaosocial, f.dest_xnome) AS cliente
                FROM tbl_historico AS h
                LEFT JOIN tbl_produtos AS p ON h.id_produtos = p.id_produtos
                LEFT JOIN tbl_vendas AS v ON h.id_vendas = v.id_vendas
                LEFT JOIN tbl_nfcevendas AS c ON h.id_nfcevendas = c.id_nfcevendas
                LEFT JOIN tbl_nfe AS f ON h.id_nfe = f.id_nfe
                LEFT JOIN tbl_clientes AS gv ON v.id_clientes = gv.id_clientes
                LEFT JOIN tbl_clientes AS gc ON c.id_clientes = gc.id_clientes
                LEFT JOIN tbl_entradas AS e ON h.id_entradas = e.id_entradas
                LEFT JOIN tbl_usuarios AS u ON h.id_usuarios = u.id_usuarios
                WHERE (@codigo = '' OR p.codigo = @codigo)
                  AND (@descricao = '' OR p.descricao LIKE @descricao)
                  AND (h.data BETWEEN @dataInicial AND @dataFinal)
                ORDER BY h.data DESC;
            ";

            try
            {
                using (var conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                        cmd.Parameters.AddWithValue("@descricao", nome + "%"); // LIKE 'texto%'
                        cmd.Parameters.AddWithValue("@dataInicial", dataInicial);
                        cmd.Parameters.AddWithValue("@dataFinal", dataFinal);

                        using (var reader = cmd.ExecuteReader())
                        {
                            var dt = new DataTable();
                            dt.Load(reader);
                            dgvHistorico.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar o banco de dados:\n" + ex.Message);
            }
            finally
            {
                btnPesquisar.Enabled = true;
                btnPesquisar.Text = "Pesquisar Histórico";
            }
        }
    }
}
