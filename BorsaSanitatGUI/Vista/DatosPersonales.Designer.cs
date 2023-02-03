namespace BorsaSanitatGUI.Vista
{
    partial class DatosPersonales
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_DNI = new System.Windows.Forms.TextBox();
            this.TB_Apellido = new System.Windows.Forms.TextBox();
            this.BT_Buscar = new System.Windows.Forms.Button();
            this.LB_Cargando = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "DNI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido:";
            // 
            // TB_DNI
            // 
            this.TB_DNI.Location = new System.Drawing.Point(67, 25);
            this.TB_DNI.Name = "TB_DNI";
            this.TB_DNI.Size = new System.Drawing.Size(100, 23);
            this.TB_DNI.TabIndex = 2;
            // 
            // TB_Apellido
            // 
            this.TB_Apellido.Location = new System.Drawing.Point(266, 25);
            this.TB_Apellido.Name = "TB_Apellido";
            this.TB_Apellido.Size = new System.Drawing.Size(100, 23);
            this.TB_Apellido.TabIndex = 3;
            // 
            // BT_Buscar
            // 
            this.BT_Buscar.Location = new System.Drawing.Point(384, 25);
            this.BT_Buscar.Name = "BT_Buscar";
            this.BT_Buscar.Size = new System.Drawing.Size(75, 23);
            this.BT_Buscar.TabIndex = 4;
            this.BT_Buscar.Text = "Buscar";
            this.BT_Buscar.UseVisualStyleBackColor = true;
            this.BT_Buscar.Click += new System.EventHandler(this.BT_Buscar_Click);
            // 
            // LB_Cargando
            // 
            this.LB_Cargando.AutoSize = true;
            this.LB_Cargando.Location = new System.Drawing.Point(67, 69);
            this.LB_Cargando.Name = "LB_Cargando";
            this.LB_Cargando.Size = new System.Drawing.Size(197, 15);
            this.LB_Cargando.TabIndex = 5;
            this.LB_Cargando.Text = "Cargando datos... Por favor espere...";
            this.LB_Cargando.Visible = false;
            // 
            // DatosPersonales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LB_Cargando);
            this.Controls.Add(this.BT_Buscar);
            this.Controls.Add(this.TB_Apellido);
            this.Controls.Add(this.TB_DNI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DatosPersonales";
            this.Text = "DatosPersonales";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox TB_DNI;
        private TextBox TB_Apellido;
        private Button BT_Buscar;
        private Label LB_Cargando;
    }
}