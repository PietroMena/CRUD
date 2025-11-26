using System;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;

namespace CRUD
{
    public partial class Form1 : Form
    {   
        private string connectionString = "Data Source=localhost;Initial Catalog=FinanceiroDB;User Id=usuario;Password=senha;";

        private int? idSelecionado = null;

        public Form1()
        {
            InitializeComponent();
            ConfigurarComboBoxes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarLancamentos();
            btnExcluir.Enabled = false;
        }

        private void ConfigurarComboBoxes()
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Crédito");
            cmbTipo.Items.Add("Débito");
            cmbTipo.SelectedIndex = 0;

            cmbFiltroTipo.Items.Clear();
            cmbFiltroTipo.Items.Add("Todos");
            cmbFiltroTipo.Items.Add("Crédito");
            cmbFiltroTipo.Items.Add("Débito");
            cmbFiltroTipo.SelectedIndex = 0;
        }

        private void CarregarLancamentos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlQuery = "SELECT ID, Descricao, Valor, DataLancamento, Tipo FROM Lancamentos WHERE 1=1";

                    if (!string.IsNullOrEmpty(txtFiltroDescricao.Text))
                    {
                        sqlQuery += " AND Descricao LIKE @Descricao";
                    }
                    if (cmbFiltroTipo.SelectedItem != null && cmbFiltroTipo.SelectedItem.ToString() != "Todos")
                    {
                        sqlQuery += " AND Tipo = @Tipo";
                    }

                    sqlQuery += " ORDER BY DataLancamento DESC";

                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                    if (!string.IsNullOrEmpty(txtFiltroDescricao.Text))
                    {
          
                        cmd.Parameters.AddWithValue("@Descricao", "%" + txtFiltroDescricao.Text + "%");
                    }
                    if (cmbFiltroTipo.SelectedItem != null && cmbFiltroTipo.SelectedItem.ToString() != "Todos")
                    {
                        cmd.Parameters.AddWithValue("@Tipo", cmbFiltroTipo.SelectedItem.ToString());
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvLancamentos.DataSource = dt;
                    dgvLancamentos.AutoResizeColumns();

                    CalcularSaldo(conn);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void CalcularSaldo(SqlConnection conn)
        {
            decimal totalCredito = 0;
            decimal totalDebito = 0;

            string sqlCredito = "SELECT SUM(Valor) FROM Lancamentos WHERE Tipo = 'Crédito'";
            object resultCredito = new SqlCommand(sqlCredito, conn).ExecuteScalar();
            if (resultCredito != DBNull.Value && resultCredito != null) totalCredito = Convert.ToDecimal(resultCredito);

            string sqlDebito = "SELECT SUM(Valor) FROM Lancamentos WHERE Tipo = 'Débito'";
            object resultDebito = new SqlCommand(sqlDebito, conn).ExecuteScalar();
            if (resultDebito != DBNull.Value && resultDebito != null) totalDebito = Convert.ToDecimal(resultDebito);

            decimal saldo = totalCredito - totalDebito;

            lblSaldo.Text = "Saldo Atual: " + saldo.ToString("C", new CultureInfo("pt-BR"));
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text) || string.IsNullOrWhiteSpace(txtValor.Text) || cmbTipo.SelectedItem == null)
            {
                MessageBox.Show("Preencha Descrição, Valor e Tipo.");
                return;
            }
            if (!decimal.TryParse(txtValor.Text.Replace("R$", "").Trim(), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal valor) || valor <= 0)
            {
                MessageBox.Show("O valor deve ser um número positivo válido (100,50).");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql;

             
                    if (idSelecionado == null)
                    {
                        sql = "INSERT INTO Lancamentos (Descricao, Valor, DataLancamento, Tipo) VALUES (@Descricao, @Valor, @Data, @Tipo)";
                    }
                    else
                    {
                        sql = "UPDATE Lancamentos SET Descricao = @Descricao, Valor = @Valor, DataLancamento = @Data, Tipo = @Tipo WHERE ID = @ID";
                    }

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Descricao", txtDescricao.Text);
                    cmd.Parameters.AddWithValue("@Valor", valor);
                    cmd.Parameters.AddWithValue("@Data", dtpData.Value);
                    cmd.Parameters.AddWithValue("@Tipo", cmbTipo.SelectedItem.ToString());

                    if (idSelecionado != null)
                    {
                        cmd.Parameters.AddWithValue("@ID", idSelecionado.Value);
                    }

                    cmd.ExecuteNonQuery();
                }

                LimparFormulario();
                CarregarLancamentos();
                MessageBox.Show("Lançamento salvo com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (idSelecionado == null) return;

            if (MessageBox.Show("Tem certeza que deseja excluir?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "DELETE FROM Lancamentos WHERE ID = @ID";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@ID", idSelecionado.Value);
                        cmd.ExecuteNonQuery();
                    }
                    LimparFormulario();
                    CarregarLancamentos();
                    MessageBox.Show("Lançamento excluído com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private void LimparFormulario()
        {
            txtDescricao.Clear();
            txtValor.Clear();
            dtpData.Value = DateTime.Now;
            if (cmbTipo.Items.Count > 0) cmbTipo.SelectedIndex = 0;
            idSelecionado = null;
            btnExcluir.Enabled = false;
            txtDescricao.Focus();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarLancamentos();
        }

        private void dgvLancamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLancamentos.Rows[e.RowIndex];

                if (row.Cells["ID"].Value != DBNull.Value && row.Cells["ID"].Value != null)
                {
                    idSelecionado = Convert.ToInt32(row.Cells["ID"].Value);

                    txtDescricao.Text = row.Cells["Descricao"].Value?.ToString() ?? "";
                    txtValor.Text = row.Cells["Valor"].Value?.ToString() ?? "";
                    dtpData.Value = row.Cells["DataLancamento"].Value != DBNull.Value ? Convert.ToDateTime(row.Cells["DataLancamento"].Value) : DateTime.Now;
                    string tipo = row.Cells["Tipo"].Value?.ToString() ?? "";

                    if (cmbTipo.Items.Contains(tipo))
                    {
                        cmbTipo.SelectedItem = tipo;
                    }

                    btnExcluir.Enabled = true;
                }
            }
        }
    }
}