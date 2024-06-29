using System;

namespace DotNetOracle
{
    partial class FormaInchirieriAparatFoto
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
            this.dataGridInchirieriAparateFoto = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbAparateFoto = new System.Windows.Forms.ComboBox();
            this.cmbClienti = new System.Windows.Forms.ComboBox();
            this.btnStergereInchiriere = new System.Windows.Forms.Button();
            this.lblNumeClient = new System.Windows.Forms.Label();
            this.btnModificaInchiriereAparatFoto = new System.Windows.Forms.Button();
            this.txtDataInceput = new System.Windows.Forms.TextBox();
            this.txtDataSfarsit = new System.Windows.Forms.TextBox();
            this.btnAdaugareInchiriereAparatFoto = new System.Windows.Forms.Button();
            this.lblDataSfarsit = new System.Windows.Forms.Label();
            this.lblDataInceput = new System.Windows.Forms.Label();
            this.lblNumeAparat = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInchirieriAparateFoto)).BeginInit();
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
            // dataGridInchirieriAparateFoto
            // 
            this.dataGridInchirieriAparateFoto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInchirieriAparateFoto.Location = new System.Drawing.Point(12, 12);
            this.dataGridInchirieriAparateFoto.Name = "dataGridInchirieriAparateFoto";
            this.dataGridInchirieriAparateFoto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridInchirieriAparateFoto.Size = new System.Drawing.Size(745, 371);
            this.dataGridInchirieriAparateFoto.TabIndex = 14;
            this.dataGridInchirieriAparateFoto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridInchirieriAparateFoto_CellContentClick);
            this.dataGridInchirieriAparateFoto.SelectionChanged += new System.EventHandler(this.dataGridInchirieriAparateFoto_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbAparateFoto);
            this.groupBox1.Controls.Add(this.cmbClienti);
            this.groupBox1.Controls.Add(this.btnStergereInchiriere);
            this.groupBox1.Controls.Add(this.lblNumeClient);
            this.groupBox1.Controls.Add(this.btnModificaInchiriereAparatFoto);
            this.groupBox1.Controls.Add(this.txtDataInceput);
            this.groupBox1.Controls.Add(this.txtDataSfarsit);
            this.groupBox1.Controls.Add(this.btnAdaugareInchiriereAparatFoto);
            this.groupBox1.Controls.Add(this.lblDataSfarsit);
            this.groupBox1.Controls.Add(this.lblDataInceput);
            this.groupBox1.Controls.Add(this.lblNumeAparat);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(763, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 324);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editare informatii Inchirieri Aparat Foto";
            // 
            // cmbAparateFoto
            // 
            this.cmbAparateFoto.FormattingEnabled = true;
            this.cmbAparateFoto.Location = new System.Drawing.Point(100, 61);
            this.cmbAparateFoto.Name = "cmbAparateFoto";
            this.cmbAparateFoto.Size = new System.Drawing.Size(165, 21);
            this.cmbAparateFoto.TabIndex = 2;
            // 
            // cmbClienti
            // 
            this.cmbClienti.FormattingEnabled = true;
            this.cmbClienti.Location = new System.Drawing.Point(100, 34);
            this.cmbClienti.Name = "cmbClienti";
            this.cmbClienti.Size = new System.Drawing.Size(165, 21);
            this.cmbClienti.TabIndex = 1;
            // 
            // btnStergereInchiriere
            // 
            this.btnStergereInchiriere.Location = new System.Drawing.Point(13, 264);
            this.btnStergereInchiriere.Name = "btnStergereInchiriere";
            this.btnStergereInchiriere.Size = new System.Drawing.Size(252, 50);
            this.btnStergereInchiriere.TabIndex = 7;
            this.btnStergereInchiriere.Text = "Stergere Inchirieri Aparat Foto";
            this.btnStergereInchiriere.UseVisualStyleBackColor = true;
            this.btnStergereInchiriere.Click += new System.EventHandler(this.btnStergereInchiriereAparatFoto_Click);
            // 
            // lblNumeClient
            // 
            this.lblNumeClient.AutoSize = true;
            this.lblNumeClient.Location = new System.Drawing.Point(10, 37);
            this.lblNumeClient.Name = "lblNumeClient";
            this.lblNumeClient.Size = new System.Drawing.Size(64, 13);
            this.lblNumeClient.TabIndex = 40;
            this.lblNumeClient.Text = "Nume Client";
            this.lblNumeClient.Visible = false;
            // 
            // btnModificaInchiriereAparatFoto
            // 
            this.btnModificaInchiriereAparatFoto.Location = new System.Drawing.Point(13, 208);
            this.btnModificaInchiriereAparatFoto.Name = "btnModificaInchiriereAparatFoto";
            this.btnModificaInchiriereAparatFoto.Size = new System.Drawing.Size(252, 50);
            this.btnModificaInchiriereAparatFoto.TabIndex = 6;
            this.btnModificaInchiriereAparatFoto.Text = "Modifica Inchirieri Aparat Foto";
            this.btnModificaInchiriereAparatFoto.UseVisualStyleBackColor = true;
            this.btnModificaInchiriereAparatFoto.Click += new System.EventHandler(this.btnModificaInchiriereAparatFoto_Click);
            // 
            // txtDataInceput
            // 
            this.txtDataInceput.Location = new System.Drawing.Point(100, 88);
            this.txtDataInceput.Name = "txtDataInceput";
            this.txtDataInceput.Size = new System.Drawing.Size(165, 20);
            this.txtDataInceput.TabIndex = 3;
            // 
            // txtDataSfarsit
            // 
            this.txtDataSfarsit.Location = new System.Drawing.Point(100, 114);
            this.txtDataSfarsit.Name = "txtDataSfarsit";
            this.txtDataSfarsit.Size = new System.Drawing.Size(165, 20);
            this.txtDataSfarsit.TabIndex = 4;
            // 
            // btnAdaugareInchiriereAparatFoto
            // 
            this.btnAdaugareInchiriereAparatFoto.Location = new System.Drawing.Point(13, 152);
            this.btnAdaugareInchiriereAparatFoto.Name = "btnAdaugareInchiriereAparatFoto";
            this.btnAdaugareInchiriereAparatFoto.Size = new System.Drawing.Size(252, 50);
            this.btnAdaugareInchiriereAparatFoto.TabIndex = 5;
            this.btnAdaugareInchiriereAparatFoto.Text = "Adaugare Inchirieri Aparat Foto";
            this.btnAdaugareInchiriereAparatFoto.UseVisualStyleBackColor = true;
            this.btnAdaugareInchiriereAparatFoto.Click += new System.EventHandler(this.btnAdaugareInchiriereAparatFoto_Click);
            // 
            // lblDataSfarsit
            // 
            this.lblDataSfarsit.AutoSize = true;
            this.lblDataSfarsit.Location = new System.Drawing.Point(10, 118);
            this.lblDataSfarsit.Name = "lblDataSfarsit";
            this.lblDataSfarsit.Size = new System.Drawing.Size(65, 13);
            this.lblDataSfarsit.TabIndex = 19;
            this.lblDataSfarsit.Text = "Data_Sfarsit";
            // 
            // lblDataInceput
            // 
            this.lblDataInceput.AutoSize = true;
            this.lblDataInceput.Location = new System.Drawing.Point(10, 91);
            this.lblDataInceput.Name = "lblDataInceput";
            this.lblDataInceput.Size = new System.Drawing.Size(72, 13);
            this.lblDataInceput.TabIndex = 18;
            this.lblDataInceput.Text = "Data_Inceput";
            // 
            // lblNumeAparat
            // 
            this.lblNumeAparat.AutoSize = true;
            this.lblNumeAparat.Location = new System.Drawing.Point(10, 63);
            this.lblNumeAparat.Name = "lblNumeAparat";
            this.lblNumeAparat.Size = new System.Drawing.Size(69, 13);
            this.lblNumeAparat.TabIndex = 16;
            this.lblNumeAparat.Text = "Nume Aparat";
            this.lblNumeAparat.Visible = false;
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
            // FormaInchirieriAparatFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 392);
            this.Controls.Add(this.btnMeniu);
            this.Controls.Add(this.dataGridInchirieriAparateFoto);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormaInchirieriAparatFoto";
            this.Text = "FormaInchirieriAparateFoto";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInchirieriAparateFoto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Button btnMeniu;
        private System.Windows.Forms.DataGridView dataGridInchirieriAparateFoto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStergereInchiriere;
        private System.Windows.Forms.Label lblNumeClient;
        private System.Windows.Forms.Button btnModificaInchiriereAparatFoto;
        private System.Windows.Forms.TextBox txtDataInceput;
        private System.Windows.Forms.TextBox txtDataSfarsit;
        private System.Windows.Forms.Button btnAdaugareInchiriereAparatFoto;
        private System.Windows.Forms.Label lblDataSfarsit;
        private System.Windows.Forms.Label lblDataInceput;
        private System.Windows.Forms.Label lblNumeAparat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAparateFoto;
        private System.Windows.Forms.ComboBox cmbClienti;
    }
}