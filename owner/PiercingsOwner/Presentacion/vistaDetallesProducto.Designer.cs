namespace PiercingsOwner.Presentacion
{
    partial class vistaDetallesProducto
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
            lblName = new Label();
            lblCategory = new Label();
            lblColor = new Label();
            lblSize = new Label();
            label5 = new Label();
            picProduct = new PictureBox();
            txtName = new TextBox();
            lblMaterial = new Label();
            txtColor = new TextBox();
            txtSize = new TextBox();
            txtMaterial = new TextBox();
            titleProduct = new Label();
            lblInventory = new Label();
            txtInventory = new TextBox();
            bttnImagenes = new Button();
            bttnGuardar = new Button();
            drpdwnCategory = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)picProduct).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(43, 88);
            lblName.Name = "lblName";
            lblName.Size = new Size(54, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Nombre:";
            lblName.Click += label1_Click;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(43, 142);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(61, 15);
            lblCategory.TabIndex = 1;
            lblCategory.Text = "Categoria:";
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Location = new Point(43, 191);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(39, 15);
            lblColor.TabIndex = 2;
            lblColor.Text = "Color:";
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(43, 247);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(77, 15);
            lblSize.TabIndex = 3;
            lblSize.Text = "Tamaño/Talla";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 374);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 4;
            label5.Text = "Material";
            // 
            // picProduct
            // 
            picProduct.Location = new Point(372, 120);
            picProduct.Name = "picProduct";
            picProduct.Size = new Size(293, 142);
            picProduct.TabIndex = 5;
            picProduct.TabStop = false;
            // 
            // txtName
            // 
            txtName.Location = new Point(126, 85);
            txtName.Name = "txtName";
            txtName.Size = new Size(121, 23);
            txtName.TabIndex = 6;
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Location = new Point(43, 299);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(50, 15);
            lblMaterial.TabIndex = 8;
            lblMaterial.Text = "Material";
            // 
            // txtColor
            // 
            txtColor.Location = new Point(126, 191);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(121, 23);
            txtColor.TabIndex = 9;
            // 
            // txtSize
            // 
            txtSize.Location = new Point(126, 244);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(121, 23);
            txtSize.TabIndex = 10;
            // 
            // txtMaterial
            // 
            txtMaterial.Location = new Point(126, 291);
            txtMaterial.Name = "txtMaterial";
            txtMaterial.Size = new Size(121, 23);
            txtMaterial.TabIndex = 11;
            // 
            // titleProduct
            // 
            titleProduct.AutoSize = true;
            titleProduct.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            titleProduct.Location = new Point(290, 9);
            titleProduct.Name = "titleProduct";
            titleProduct.Size = new Size(215, 37);
            titleProduct.TabIndex = 12;
            titleProduct.Text = "Producto ID-01";
            // 
            // lblInventory
            // 
            lblInventory.AutoSize = true;
            lblInventory.Location = new Point(383, 90);
            lblInventory.Name = "lblInventory";
            lblInventory.Size = new Size(60, 15);
            lblInventory.TabIndex = 13;
            lblInventory.Text = "Inventario";
            lblInventory.Click += label8_Click;
            // 
            // txtInventory
            // 
            txtInventory.Location = new Point(467, 85);
            txtInventory.Name = "txtInventory";
            txtInventory.Size = new Size(100, 23);
            txtInventory.TabIndex = 14;
            // 
            // bttnImagenes
            // 
            bttnImagenes.Location = new Point(478, 270);
            bttnImagenes.Name = "bttnImagenes";
            bttnImagenes.Size = new Size(75, 23);
            bttnImagenes.TabIndex = 15;
            bttnImagenes.Text = "Imagenes";
            bttnImagenes.UseVisualStyleBackColor = true;
            // 
            // bttnGuardar
            // 
            bttnGuardar.Location = new Point(478, 299);
            bttnGuardar.Name = "bttnGuardar";
            bttnGuardar.Size = new Size(75, 23);
            bttnGuardar.TabIndex = 16;
            bttnGuardar.Text = "Guardar cambios";
            bttnGuardar.UseVisualStyleBackColor = true;
            // 
            // drpdwnCategory
            // 
            drpdwnCategory.FormattingEnabled = true;
            drpdwnCategory.Location = new Point(126, 139);
            drpdwnCategory.Name = "drpdwnCategory";
            drpdwnCategory.Size = new Size(121, 23);
            drpdwnCategory.TabIndex = 17;
            // 
            // vistaDetallesProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(drpdwnCategory);
            Controls.Add(bttnGuardar);
            Controls.Add(bttnImagenes);
            Controls.Add(txtInventory);
            Controls.Add(lblInventory);
            Controls.Add(titleProduct);
            Controls.Add(txtMaterial);
            Controls.Add(txtSize);
            Controls.Add(txtColor);
            Controls.Add(lblMaterial);
            Controls.Add(txtName);
            Controls.Add(picProduct);
            Controls.Add(label5);
            Controls.Add(lblSize);
            Controls.Add(lblColor);
            Controls.Add(lblCategory);
            Controls.Add(lblName);
            Name = "vistaDetallesProducto";
            Text = "vistaDetallesProducto";
            Load += vistaDetallesProducto_Load;
            ((System.ComponentModel.ISupportInitialize)picProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblCategory;
        private Label lblColor;
        private Label lblSize;
        private Label label5;
        private PictureBox picProduct;
        private TextBox txtName;
        private Label lblMaterial;
        private TextBox txtColor;
        private TextBox txtSize;
        private TextBox txtMaterial;
        private Label titleProduct;
        private Label lblInventory;
        private TextBox txtInventory;
        private Button bttnImagenes;
        private Button bttnGuardar;
        private ComboBox drpdwnCategory;
    }
}