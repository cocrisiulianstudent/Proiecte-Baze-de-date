namespace DotNetOracle
{
    partial class FormaUtilizator
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
            this.dataGridUtilizator = new System.Windows.Forms.DataGridView();
            this.gbEditareInformatiiUtilizator = new System.Windows.Forms.GroupBox();
            this.btnStergereUtilizator = new System.Windows.Forms.Button();
            this.btnModificaUtilizator = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtPrenume = new System.Windows.Forms.TextBox();
            this.btnAdaugareUtilizator = new System.Windows.Forms.Button();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPrenume = new System.Windows.Forms.Label();
            this.lblNume = new System.Windows.Forms.Label();
            this.btnMeniu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUtilizator)).BeginInit();
            this.gbEditareInformatiiUtilizator.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridUtilizator
            // 
            this.dataGridUtilizator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUtilizator.Location = new System.Drawing.Point(12, 12);
            this.dataGridUtilizator.Name = "dataGridUtilizator";
            this.dataGridUtilizator.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridUtilizator.Size = new System.Drawing.Size(745, 368);
            this.dataGridUtilizator.TabIndex = 10;
            this.dataGridUtilizator.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridUtilizator_CellContentClick);
            this.dataGridUtilizator.SelectionChanged += new System.EventHandler(this.dataGridUtilizator_SelectionChanged);
            // 
            // gbEditareInformatiiUtilizator
            // 
            this.gbEditareInformatiiUtilizator.Controls.Add(this.btnStergereUtilizator);
            this.gbEditareInformatiiUtilizator.Controls.Add(this.btnModificaUtilizator);
            this.gbEditareInformatiiUtilizator.Controls.Add(this.txtEmail);
            this.gbEditareInformatiiUtilizator.Controls.Add(this.txtNume);
            this.gbEditareInformatiiUtilizator.Controls.Add(this.txtTelefon);
            this.gbEditareInformatiiUtilizator.Controls.Add(this.txtPrenume);
            this.gbEditareInformatiiUtilizator.Controls.Add(this.btnAdaugareUtilizator);
            this.gbEditareInformatiiUtilizator.Controls.Add(this.lblTelefon);
            this.gbEditareInformatiiUtilizator.Controls.Add(this.lblEmail);
            this.gbEditareInformatiiUtilizator.Controls.Add(this.lblPrenume);
            this.gbEditareInformatiiUtilizator.Controls.Add(this.lblNume);
            this.gbEditareInformatiiUtilizator.Location = new System.Drawing.Point(763, 12);
            this.gbEditareInformatiiUtilizator.Name = "gbEditareInformatiiUtilizator";
            this.gbEditareInformatiiUtilizator.Size = new System.Drawing.Size(286, 319);
            this.gbEditareInformatiiUtilizator.TabIndex = 6;
            this.gbEditareInformatiiUtilizator.TabStop = false;
            this.gbEditareInformatiiUtilizator.Text = "Editare informatii Utilizator";
            // 
            // btnStergereUtilizator
            // 
            this.btnStergereUtilizator.Location = new System.Drawing.Point(13, 264);
            this.btnStergereUtilizator.Name = "btnStergereUtilizator";
            this.btnStergereUtilizator.Size = new System.Drawing.Size(252, 50);
            this.btnStergereUtilizator.TabIndex = 8;
            this.btnStergereUtilizator.Text = "Stergere Utilizator";
            this.btnStergereUtilizator.UseVisualStyleBackColor = true;
            this.btnStergereUtilizator.Click += new System.EventHandler(this.btnStergereUtilizator_Click);
            // 
            // btnModificaUtilizator
            // 
            this.btnModificaUtilizator.Location = new System.Drawing.Point(13, 208);
            this.btnModificaUtilizator.Name = "btnModificaUtilizator";
            this.btnModificaUtilizator.Size = new System.Drawing.Size(252, 50);
            this.btnModificaUtilizator.TabIndex = 7;
            this.btnModificaUtilizator.Text = "Modifica Utilizator";
            this.btnModificaUtilizator.UseVisualStyleBackColor = true;
            this.btnModificaUtilizator.Click += new System.EventHandler(this.btnModificaUtilizator_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(100, 81);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(165, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(100, 29);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(165, 20);
            this.txtNume.TabIndex = 2;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(100, 107);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(165, 20);
            this.txtTelefon.TabIndex = 5;
            // 
            // txtPrenume
            // 
            this.txtPrenume.Location = new System.Drawing.Point(100, 55);
            this.txtPrenume.Name = "txtPrenume";
            this.txtPrenume.Size = new System.Drawing.Size(165, 20);
            this.txtPrenume.TabIndex = 3;
            // 
            // btnAdaugareUtilizator
            // 
            this.btnAdaugareUtilizator.Location = new System.Drawing.Point(13, 152);
            this.btnAdaugareUtilizator.Name = "btnAdaugareUtilizator";
            this.btnAdaugareUtilizator.Size = new System.Drawing.Size(252, 50);
            this.btnAdaugareUtilizator.TabIndex = 6;
            this.btnAdaugareUtilizator.Text = "Adaugare Utilizator";
            this.btnAdaugareUtilizator.UseVisualStyleBackColor = true;
            this.btnAdaugareUtilizator.Click += new System.EventHandler(this.btnAdaugareUtilizator_Click);
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Location = new System.Drawing.Point(10, 111);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(43, 13);
            this.lblTelefon.TabIndex = 19;
            this.lblTelefon.Text = "Telefon";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(10, 84);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 18;
            this.lblEmail.Text = "Email";
            // 
            // lblPrenume
            // 
            this.lblPrenume.AutoSize = true;
            this.lblPrenume.Location = new System.Drawing.Point(10, 58);
            this.lblPrenume.Name = "lblPrenume";
            this.lblPrenume.Size = new System.Drawing.Size(49, 13);
            this.lblPrenume.TabIndex = 17;
            this.lblPrenume.Text = "Prenume";
            // 
            // lblNume
            // 
            this.lblNume.AutoSize = true;
            this.lblNume.Location = new System.Drawing.Point(10, 32);
            this.lblNume.Name = "lblNume";
            this.lblNume.Size = new System.Drawing.Size(35, 13);
            this.lblNume.TabIndex = 16;
            this.lblNume.Text = "Nume";
            // 
            // btnMeniu
            // 
            this.btnMeniu.Location = new System.Drawing.Point(776, 338);
            this.btnMeniu.Name = "btnMeniu";
            this.btnMeniu.Size = new System.Drawing.Size(252, 45);
            this.btnMeniu.TabIndex = 0;
            this.btnMeniu.Text = "Meniu";
            this.btnMeniu.UseVisualStyleBackColor = true;
            this.btnMeniu.Click += new System.EventHandler(this.btnMeniu_Click);
            // 
            // FormaUtilizator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 395);
            this.Controls.Add(this.btnMeniu);
            this.Controls.Add(this.dataGridUtilizator);
            this.Controls.Add(this.gbEditareInformatiiUtilizator);
            this.Name = "FormaUtilizator";
            this.Text = "Utilizator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUtilizator)).EndInit();
            this.gbEditareInformatiiUtilizator.ResumeLayout(false);
            this.gbEditareInformatiiUtilizator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridUtilizator;
        private System.Windows.Forms.GroupBox gbEditareInformatiiUtilizator;
        private System.Windows.Forms.Button btnStergereUtilizator;
        private System.Windows.Forms.Button btnModificaUtilizator;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtPrenume;
        private System.Windows.Forms.Button btnAdaugareUtilizator;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPrenume;
        private System.Windows.Forms.Label lblNume;
        private System.Windows.Forms.Button btnMeniu;
    }
}