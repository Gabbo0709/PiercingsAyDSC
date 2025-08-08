namespace PiercingsOwner.Presentacion
{
    partial class vistaGestionarProductos
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
            tablaProductos = new DataGridView();
            bttnEntrada = new Button();
            bttnSalida = new Button();
            bttnDeshabilitar = new Button();
            bttnAniadir = new Button();
            txtSalida = new TextBox();
            txtEntrada = new TextBox();
            ((System.ComponentModel.ISupportInitialize)tablaProductos).BeginInit();
            SuspendLayout();
            // 
            // tablaProductos
            // 
            tablaProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tablaProductos.Location = new Point(12, 23);
            tablaProductos.Name = "tablaProductos";
            tablaProductos.RowHeadersWidth = 51;
            tablaProductos.Size = new Size(908, 295);
            tablaProductos.TabIndex = 0;
            tablaProductos.CellContentClick += tablaProductos_CellContentClick;
            // 
            // bttnEntrada
            // 
            bttnEntrada.Location = new Point(277, 376);
            bttnEntrada.Name = "bttnEntrada";
            bttnEntrada.Size = new Size(143, 29);
            bttnEntrada.TabIndex = 1;
            bttnEntrada.Text = "Registrar Entrada";
            bttnEntrada.UseVisualStyleBackColor = true;
            bttnEntrada.Click += bttnEntrada_Click;
            // 
            // bttnSalida
            // 
            bttnSalida.Location = new Point(12, 376);
            bttnSalida.Name = "bttnSalida";
            bttnSalida.Size = new Size(154, 29);
            bttnSalida.TabIndex = 2;
            bttnSalida.Text = "Registrar Salida";
            bttnSalida.UseVisualStyleBackColor = true;
            bttnSalida.Click += bttnSalida_Click;
            // 
            // bttnDeshabilitar
            // 
            bttnDeshabilitar.Location = new Point(512, 377);
            bttnDeshabilitar.Name = "bttnDeshabilitar";
            bttnDeshabilitar.Size = new Size(180, 29);
            bttnDeshabilitar.TabIndex = 3;
            bttnDeshabilitar.Text = "Deshabilitar Producto";
            bttnDeshabilitar.UseVisualStyleBackColor = true;
            bttnDeshabilitar.Click += bttnDeshabilitar_Click;
            // 
            // bttnAniadir
            // 
            bttnAniadir.Location = new Point(748, 376);
            bttnAniadir.Name = "bttnAniadir";
            bttnAniadir.Size = new Size(172, 29);
            bttnAniadir.TabIndex = 4;
            bttnAniadir.Text = "Añadir producto";
            bttnAniadir.UseVisualStyleBackColor = true;
            bttnAniadir.Click += bttnAniadir_Click;
            // 
            // txtSalida
            // 
            txtSalida.Location = new Point(172, 377);
            txtSalida.Name = "txtSalida";
            txtSalida.Size = new Size(33, 27);
            txtSalida.TabIndex = 5;
            // 
            // txtEntrada
            // 
            txtEntrada.Location = new Point(426, 376);
            txtEntrada.Name = "txtEntrada";
            txtEntrada.Size = new Size(33, 27);
            txtEntrada.TabIndex = 6;
            txtEntrada.TextChanged += txtEntrada_TextChanged;
            // 
            // adminMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 450);
            Controls.Add(txtEntrada);
            Controls.Add(txtSalida);
            Controls.Add(bttnAniadir);
            Controls.Add(bttnDeshabilitar);
            Controls.Add(bttnSalida);
            Controls.Add(bttnEntrada);
            Controls.Add(tablaProductos);
            Name = "adminMenu";
            Text = "Form1";
            Load += adminMenu_Load;
            ((System.ComponentModel.ISupportInitialize)tablaProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView tablaProductos;
        private Button bttnEntrada;
        private Button bttnSalida;
        private Button bttnDeshabilitar;
        private Button bttnAniadir;
        private TextBox txtSalida;
        private TextBox txtEntrada;
    }
}