namespace DotNetOracle
{
    partial class FormaAparatFoto
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
            this.btnMeniu = new System.Windows.Forms.Button();
            this.dataGridAparatFoto = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxDisponibilitate = new System.Windows.Forms.CheckBox();
            this.btnStergeAparatFoto = new System.Windows.Forms.Button();
            this.btnModificaAparatFoto = new System.Windows.Forms.Button();
            this.txtNumeModel = new System.Windows.Forms.TextBox();
            this.txtTarifZi = new System.Windows.Forms.TextBox();
            this.txtDescriere = new System.Windows.Forms.TextBox();
            this.btnAdaugareAparatFoto = new System.Windows.Forms.Button();
            this.lblTarifZi = new System.Windows.Forms.Label();
            this.lblDisponibilitate = new System.Windows.Forms.Label();
            this.lblDescriere = new System.Windows.Forms.Label();
            this.lblNumeModel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAparatFoto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // dataGridAparatFoto
            // 
            this.dataGridAparatFoto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAparatFoto.Location = new System.Drawing.Point(12, 12);
            this.dataGridAparatFoto.Name = "dataGridAparatFoto";
            this.dataGridAparatFoto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridAparatFoto.Size = new System.Drawing.Size(745, 368);
            this.dataGridAparatFoto.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxDisponibilitate);
            this.groupBox1.Controls.Add(this.btnStergeAparatFoto);
            this.groupBox1.Controls.Add(this.btnModificaAparatFoto);
            this.groupBox1.Controls.Add(this.txtNumeModel);
            this.groupBox1.Controls.Add(this.txtTarifZi);
            this.groupBox1.Controls.Add(this.txtDescriere);
            this.groupBox1.Controls.Add(this.btnAdaugareAparatFoto);
            this.groupBox1.Controls.Add(this.lblTarifZi);
            this.groupBox1.Controls.Add(this.lblDisponibilitate);
            this.groupBox1.Controls.Add(this.lblDescriere);
            this.groupBox1.Controls.Add(this.lblNumeModel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(763, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 324);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editare informatii Aparat Foto";
            // 
            // checkBoxDisponibilitate
            // 
            this.checkBoxDisponibilitate.AutoSize = true;
            this.checkBoxDisponibilitate.Location = new System.Drawing.Point(100, 90);
            this.checkBoxDisponibilitate.Name = "checkBoxDisponibilitate";
            this.checkBoxDisponibilitate.Size = new System.Drawing.Size(40, 17);
            this.checkBoxDisponibilitate.TabIndex = 3;
            this.checkBoxDisponibilitate.Text = "Da";
            this.checkBoxDisponibilitate.UseVisualStyleBackColor = true;
            // 
            // btnStergeAparatFoto
            // 
            this.btnStergeAparatFoto.Location = new System.Drawing.Point(13, 264);
            this.btnStergeAparatFoto.Name = "btnStergeAparatFoto";
            this.btnStergeAparatFoto.Size = new System.Drawing.Size(252, 50);
            this.btnStergeAparatFoto.TabIndex = 7;
            this.btnStergeAparatFoto.Text = "Stergere Aparat Foto";
            this.btnStergeAparatFoto.UseVisualStyleBackColor = true;
            this.btnStergeAparatFoto.Click += new System.EventHandler(this.btnStergereAparatFoto_Click);
            // 
            // btnModificaAparatFoto
            // 
            this.btnModificaAparatFoto.Location = new System.Drawing.Point(13, 208);
            this.btnModificaAparatFoto.Name = "btnModificaAparatFoto";
            this.btnModificaAparatFoto.Size = new System.Drawing.Size(252, 50);
            this.btnModificaAparatFoto.TabIndex = 6;
            this.btnModificaAparatFoto.Text = "Modifica Aparat Foto";
            this.btnModificaAparatFoto.UseVisualStyleBackColor = true;
            this.btnModificaAparatFoto.Click += new System.EventHandler(this.btnModificaAparatFoto_Click);
            // 
            // txtNumeModel
            // 
            this.txtNumeModel.Location = new System.Drawing.Point(100, 36);
            this.txtNumeModel.Name = "txtNumeModel";
            this.txtNumeModel.Size = new System.Drawing.Size(165, 20);
            this.txtNumeModel.TabIndex = 1;
            // 
            // txtTarifZi
            // 
            this.txtTarifZi.Location = new System.Drawing.Point(100, 114);
            this.txtTarifZi.Name = "txtTarifZi";
            this.txtTarifZi.Size = new System.Drawing.Size(165, 20);
            this.txtTarifZi.TabIndex = 4;
            // 
            // txtDescriere
            // 
            this.txtDescriere.Location = new System.Drawing.Point(100, 62);
            this.txtDescriere.Name = "txtDescriere";
            this.txtDescriere.Size = new System.Drawing.Size(165, 20);
            this.txtDescriere.TabIndex = 2;
            // 
            // btnAdaugareAparatFoto
            // 
            this.btnAdaugareAparatFoto.Location = new System.Drawing.Point(13, 152);
            this.btnAdaugareAparatFoto.Name = "btnAdaugareAparatFoto";
            this.btnAdaugareAparatFoto.Size = new System.Drawing.Size(252, 50);
            this.btnAdaugareAparatFoto.TabIndex = 5;
            this.btnAdaugareAparatFoto.Text = "Adaugare Aparat Foto";
            this.btnAdaugareAparatFoto.UseVisualStyleBackColor = true;
            this.btnAdaugareAparatFoto.Click += new System.EventHandler(this.btnAdaugareAparatFoto_Click);
            // 
            // lblTarifZi
            // 
            this.lblTarifZi.AutoSize = true;
            this.lblTarifZi.Location = new System.Drawing.Point(10, 118);
            this.lblTarifZi.Name = "lblTarifZi";
            this.lblTarifZi.Size = new System.Drawing.Size(43, 13);
            this.lblTarifZi.TabIndex = 19;
            this.lblTarifZi.Text = "Tarif_Zi";
            // 
            // lblDisponibilitate
            // 
            this.lblDisponibilitate.AutoSize = true;
            this.lblDisponibilitate.Location = new System.Drawing.Point(10, 91);
            this.lblDisponibilitate.Name = "lblDisponibilitate";
            this.lblDisponibilitate.Size = new System.Drawing.Size(72, 13);
            this.lblDisponibilitate.TabIndex = 18;
            this.lblDisponibilitate.Text = "Disponibilitate";
            // 
            // lblDescriere
            // 
            this.lblDescriere.AutoSize = true;
            this.lblDescriere.Location = new System.Drawing.Point(10, 65);
            this.lblDescriere.Name = "lblDescriere";
            this.lblDescriere.Size = new System.Drawing.Size(52, 13);
            this.lblDescriere.TabIndex = 17;
            this.lblDescriere.Text = "Descriere";
            // 
            // lblNumeModel
            // 
            this.lblNumeModel.AutoSize = true;
            this.lblNumeModel.Location = new System.Drawing.Point(10, 39);
            this.lblNumeModel.Name = "lblNumeModel";
            this.lblNumeModel.Size = new System.Drawing.Size(70, 13);
            this.lblNumeModel.TabIndex = 16;
            this.lblNumeModel.Text = "Nume_Model";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(431, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 9;
            this.label4.Visible = false;
            // 
            // FormaAparatFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 398);
            this.Controls.Add(this.btnMeniu);
            this.Controls.Add(this.dataGridAparatFoto);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormaAparatFoto";
            this.Text = "FormaAparatFoto";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAparatFoto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMeniu;
        private System.Windows.Forms.DataGridView dataGridAparatFoto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStergeAparatFoto;
        private System.Windows.Forms.Button btnModificaAparatFoto;
        private System.Windows.Forms.TextBox txtNumeModel;
        private System.Windows.Forms.TextBox txtTarifZi;
        private System.Windows.Forms.TextBox txtDescriere;
        private System.Windows.Forms.Button btnAdaugareAparatFoto;
        private System.Windows.Forms.Label lblTarifZi;
        private System.Windows.Forms.Label lblDisponibilitate;
        private System.Windows.Forms.Label lblDescriere;
        private System.Windows.Forms.Label lblNumeModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxDisponibilitate;
    }
}