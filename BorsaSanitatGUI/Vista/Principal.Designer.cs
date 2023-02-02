namespace BorsaSanitatGUI.Vista
{
    partial class Principal
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
            this.button1 = new System.Windows.Forms.Button();
            this.DGV_Listado = new System.Windows.Forms.DataGridView();
            this.CB_Departamento = new System.Windows.Forms.ComboBox();
            this.Departamento = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NUD_Inicio = new System.Windows.Forms.NumericUpDown();
            this.NUD_Final = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_Categoria = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Listado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Inicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Final)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Refrescar datos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DGV_Listado
            // 
            this.DGV_Listado.AllowUserToAddRows = false;
            this.DGV_Listado.AllowUserToDeleteRows = false;
            this.DGV_Listado.AllowUserToResizeColumns = false;
            this.DGV_Listado.AllowUserToResizeRows = false;
            this.DGV_Listado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_Listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Listado.Location = new System.Drawing.Point(12, 41);
            this.DGV_Listado.MultiSelect = false;
            this.DGV_Listado.Name = "DGV_Listado";
            this.DGV_Listado.ReadOnly = true;
            this.DGV_Listado.RowTemplate.Height = 25;
            this.DGV_Listado.Size = new System.Drawing.Size(611, 451);
            this.DGV_Listado.TabIndex = 1;
            this.DGV_Listado.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Listado_ColumnHeaderMouseClick);
            // 
            // CB_Departamento
            // 
            this.CB_Departamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Departamento.FormattingEnabled = true;
            this.CB_Departamento.Location = new System.Drawing.Point(717, 84);
            this.CB_Departamento.Name = "CB_Departamento";
            this.CB_Departamento.Size = new System.Drawing.Size(121, 23);
            this.CB_Departamento.TabIndex = 2;
            // 
            // Departamento
            // 
            this.Departamento.AutoSize = true;
            this.Departamento.Location = new System.Drawing.Point(629, 87);
            this.Departamento.Name = "Departamento";
            this.Departamento.Size = new System.Drawing.Size(83, 15);
            this.Departamento.TabIndex = 3;
            this.Departamento.Text = "Departamento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(629, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Posición Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(628, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Posición Final";
            // 
            // NUD_Inicio
            // 
            this.NUD_Inicio.Location = new System.Drawing.Point(719, 121);
            this.NUD_Inicio.Name = "NUD_Inicio";
            this.NUD_Inicio.Size = new System.Drawing.Size(120, 23);
            this.NUD_Inicio.TabIndex = 6;
            this.NUD_Inicio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NUD_Final
            // 
            this.NUD_Final.Location = new System.Drawing.Point(719, 150);
            this.NUD_Final.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NUD_Final.Name = "NUD_Final";
            this.NUD_Final.Size = new System.Drawing.Size(120, 23);
            this.NUD_Final.TabIndex = 7;
            this.NUD_Final.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(649, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Categoria";
            // 
            // CB_Categoria
            // 
            this.CB_Categoria.FormattingEnabled = true;
            this.CB_Categoria.Location = new System.Drawing.Point(717, 52);
            this.CB_Categoria.Name = "CB_Categoria";
            this.CB_Categoria.Size = new System.Drawing.Size(121, 23);
            this.CB_Categoria.TabIndex = 9;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 504);
            this.Controls.Add(this.CB_Categoria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NUD_Final);
            this.Controls.Add(this.NUD_Inicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Departamento);
            this.Controls.Add(this.CB_Departamento);
            this.Controls.Add(this.DGV_Listado);
            this.Controls.Add(this.button1);
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Listado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Inicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Final)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private DataGridView DGV_Listado;
        private ComboBox CB_Departamento;
        private Label Departamento;
        private Label label1;
        private Label label2;
        private NumericUpDown NUD_Inicio;
        private NumericUpDown NUD_Final;
        private Label label3;
        private ComboBox CB_Categoria;
    }
}