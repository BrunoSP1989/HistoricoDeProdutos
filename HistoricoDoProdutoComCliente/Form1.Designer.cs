namespace HistoricoProdutosAppComCliente
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.TextBox txtBuscaCodigo;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.DataGridView dgvHistorico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDataInicial; // Novo
        private System.Windows.Forms.DateTimePicker dtpDataFinal;   // Novo
        private System.Windows.Forms.Label label3; // Novo
        private System.Windows.Forms.Label label4; // Novo

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtBusca = new TextBox();
            txtBuscaCodigo = new TextBox();
            btnPesquisar = new Button();
            dgvHistorico = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            dtpDataInicial = new DateTimePicker();
            dtpDataFinal = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHistorico).BeginInit();
            SuspendLayout();
            // 
            // txtBusca
            // 
            txtBusca.Location = new Point(180, 11);
            txtBusca.Name = "txtBusca";
            txtBusca.Size = new Size(250, 23);
            txtBusca.TabIndex = 1;
            // 
            // txtBuscaCodigo
            // 
            txtBuscaCodigo.Location = new Point(568, 10);
            txtBuscaCodigo.Name = "txtBuscaCodigo";
            txtBuscaCodigo.Size = new Size(146, 23);
            txtBuscaCodigo.TabIndex = 2;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(564, 39);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(150, 23);
            btnPesquisar.TabIndex = 7;
            btnPesquisar.Text = "Pesquisar Histórico";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // dgvHistorico
            // 
            dgvHistorico.AllowUserToAddRows = false;
            dgvHistorico.AllowUserToDeleteRows = false;
            dgvHistorico.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHistorico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorico.Location = new Point(10, 80);
            dgvHistorico.Name = "dgvHistorico";
            dgvHistorico.ReadOnly = true;
            dgvHistorico.Size = new Size(1079, 475);
            dgvHistorico.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(163, 15);
            label1.TabIndex = 0;
            label1.Text = "Buscar por nome do produto:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(440, 14);
            label2.Name = "label2";
            label2.Size = new Size(106, 15);
            label2.TabIndex = 2;
            label2.Text = "Buscar por código:";
            // 
            // dtpDataInicial
            // 
            dtpDataInicial.Format = DateTimePickerFormat.Short;
            dtpDataInicial.Location = new Point(86, 40);
            dtpDataInicial.Name = "dtpDataInicial";
            dtpDataInicial.Size = new Size(200, 23);
            dtpDataInicial.TabIndex = 5;
            // 
            // dtpDataFinal
            // 
            dtpDataFinal.Format = DateTimePickerFormat.Short;
            dtpDataFinal.Location = new Point(358, 40);
            dtpDataFinal.Name = "dtpDataFinal";
            dtpDataFinal.Size = new Size(200, 23);
            dtpDataFinal.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 44);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 3;
            label3.Text = "Data inicial:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(292, 44);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 6;
            label4.Text = "Data final:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1114, 591);
            Controls.Add(label1);
            Controls.Add(txtBusca);
            Controls.Add(label2);
            Controls.Add(txtBuscaCodigo);
            Controls.Add(label3);
            Controls.Add(dtpDataInicial);
            Controls.Add(label4);
            Controls.Add(dtpDataFinal);
            Controls.Add(btnPesquisar);
            Controls.Add(dgvHistorico);
            Name = "Form1";
            Text = "Consulta de Histórico de Produtos";
            ((System.ComponentModel.ISupportInitialize)dgvHistorico).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
