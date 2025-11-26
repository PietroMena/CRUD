namespace CRUD
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_Descricao = new Label();
            txtDescricao = new TextBox();
            label_Valor = new Label();
            txtValor = new TextBox();
            label1 = new Label();
            dtpData = new DateTimePicker();
            label2 = new Label();
            cmbTipo = new ComboBox();
            btnSalvar = new Button();
            btnExcluir = new Button();
            btnLimpar = new Button();
            lbl_Filtro = new Label();
            txtFiltroDescricao = new TextBox();
            label3 = new Label();
            cmbFiltroTipo = new ComboBox();
            dgvLancamentos = new DataGridView();
            lblSaldo = new Label();
            btnFiltrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLancamentos).BeginInit();
            SuspendLayout();
            // 
            // label_Descricao
            // 
            label_Descricao.AutoSize = true;
            label_Descricao.Location = new Point(12, 28);
            label_Descricao.Name = "label_Descricao";
            label_Descricao.Size = new Size(61, 15);
            label_Descricao.TabIndex = 0;
            label_Descricao.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(12, 45);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(180, 23);
            txtDescricao.TabIndex = 1;
            // 
            // label_Valor
            // 
            label_Valor.AutoSize = true;
            label_Valor.Location = new Point(12, 90);
            label_Valor.Name = "label_Valor";
            label_Valor.Size = new Size(36, 15);
            label_Valor.TabIndex = 2;
            label_Valor.Text = "Valor:";
            // 
            // txtValor
            // 
            txtValor.Location = new Point(12, 108);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(100, 23);
            txtValor.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 151);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 4;
            label1.Text = "Data:";
            // 
            // dtpData
            // 
            dtpData.Location = new Point(12, 169);
            dtpData.Name = "dtpData";
            dtpData.Size = new Size(200, 23);
            dtpData.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 222);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 6;
            label2.Text = "Tipo:";
            // 
            // cmbTipo
            // 
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(12, 240);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(121, 23);
            cmbTipo.TabIndex = 7;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(69, 352);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 8;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(117, 306);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 9;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(23, 306);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(75, 23);
            btnLimpar.TabIndex = 10;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // lbl_Filtro
            // 
            lbl_Filtro.AutoSize = true;
            lbl_Filtro.Location = new Point(320, 28);
            lbl_Filtro.Name = "lbl_Filtro";
            lbl_Filtro.Size = new Size(91, 15);
            lbl_Filtro.TabIndex = 11;
            lbl_Filtro.Text = "Filtrar Descrição";
            // 
            // txtFiltroDescricao
            // 
            txtFiltroDescricao.Location = new Point(320, 46);
            txtFiltroDescricao.Name = "txtFiltroDescricao";
            txtFiltroDescricao.Size = new Size(150, 23);
            txtFiltroDescricao.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(503, 28);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 13;
            label3.Text = "Filtrar Tipo";
            // 
            // cmbFiltroTipo
            // 
            cmbFiltroTipo.FormattingEnabled = true;
            cmbFiltroTipo.Location = new Point(503, 46);
            cmbFiltroTipo.Name = "cmbFiltroTipo";
            cmbFiltroTipo.Size = new Size(121, 23);
            cmbFiltroTipo.TabIndex = 14;
            // 
            // dgvLancamentos
            // 
            dgvLancamentos.BackgroundColor = Color.Black;
            dgvLancamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLancamentos.Location = new Point(308, 89);
            dgvLancamentos.Name = "dgvLancamentos";
            dgvLancamentos.Size = new Size(424, 239);
            dgvLancamentos.TabIndex = 15;
            dgvLancamentos.CellClick += dgvLancamentos_CellClick;
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Location = new Point(470, 352);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(107, 15);
            lblSaldo.TabIndex = 16;
            lblSaldo.Text = "Saldo Atual: R$0,00";
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(657, 45);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(75, 23);
            btnFiltrar.TabIndex = 17;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnFiltrar);
            Controls.Add(lblSaldo);
            Controls.Add(dgvLancamentos);
            Controls.Add(cmbFiltroTipo);
            Controls.Add(label3);
            Controls.Add(txtFiltroDescricao);
            Controls.Add(lbl_Filtro);
            Controls.Add(btnLimpar);
            Controls.Add(btnExcluir);
            Controls.Add(btnSalvar);
            Controls.Add(cmbTipo);
            Controls.Add(label2);
            Controls.Add(dtpData);
            Controls.Add(label1);
            Controls.Add(txtValor);
            Controls.Add(label_Valor);
            Controls.Add(txtDescricao);
            Controls.Add(label_Descricao);
            Name = "Form1";
            Text = "CRUD Financeiro";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLancamentos).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label label_Descricao;
        private TextBox txtDescricao;
        private Label label_Valor;
        private TextBox txtValor;
        private Label label1;
        private DateTimePicker dtpData;
        private Label label2;
        private ComboBox cmbTipo;
        private Button btnSalvar;
        private Button btnExcluir;
        private Button btnLimpar;
        private Label lbl_Filtro;
        private TextBox txtFiltroDescricao;
        private Label label3;
        private ComboBox cmbFiltroTipo;
        private DataGridView dgvLancamentos;
        private Label lblSaldo;
        private Button btnFiltrar;
    }
}