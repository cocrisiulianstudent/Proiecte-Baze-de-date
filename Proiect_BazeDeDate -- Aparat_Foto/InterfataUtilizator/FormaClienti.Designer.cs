namespace DotNetOracle
{
    partial class FormaClienti
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
            this.dataGridClienti = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStergereClient = new System.Windows.Forms.Button();
            this.btnModificaClient = new System.Windows.Forms.Button();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtNumeClient = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPrenumeClient = new System.Windows.Forms.TextBox();
            this.btnAdaugareClient = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.lblPrenumeClient = new System.Windows.Forms.Label();
            this.lblNumeClient = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClienti)).BeginInit();
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
            // dataGridClienti
            // 
            this.dataGridClienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridClienti.Location = new System.Drawing.Point(12, 12);
            this.dataGridClienti.Name = "dataGridClienti";
            this.dataGridClienti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridClienti.Size = new System.Drawing.Size(745, 368);
            this.dataGridClienti.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStergereClient);
            this.groupBox1.Controls.Add(this.btnModificaClient);
            this.groupBox1.Controls.Add(this.txtTelefon);
            this.groupBox1.Controls.Add(this.txtNumeClient);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtPrenumeClient);
            this.groupBox1.Controls.Add(this.btnAdaugareClient);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.lblTelefon);
            this.groupBox1.Controls.Add(this.lblPrenumeClient);
            this.groupBox1.Controls.Add(this.lblNumeClient);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(763, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 324);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editare informatii Clienti";
            // 
            // btnStergereClient
            // 
            this.btnStergereClient.Location = new System.Drawing.Point(13, 264);
            this.btnStergereClient.Name = "btnStergereClient";
            this.btnStergereClient.Size = new System.Drawing.Size(252, 50);
            this.btnStergereClient.TabIndex = 7;
            this.btnStergereClient.Text = "Stergere Client";
            this.btnStergereClient.UseVisualStyleBackColor = true;
            this.btnStergereClient.Click += new System.EventHandler(this.btnStergereClient_Click);
            // 
            // btnModificaClient
            // 
            this.btnModificaClient.Location = new System.Drawing.Point(13, 208);
            this.btnModificaClient.Name = "btnModificaClient";
            this.btnModificaClient.Size = new System.Drawing.Size(252, 50);
            this.btnModificaClient.TabIndex = 6;
            this.btnModificaClient.Text = "Modifica Client";
            this.btnModificaClient.UseVisualStyleBackColor = true;
            this.btnModificaClient.Click += new System.EventHandler(this.btnModificaClient_Click);
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(100, 79);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(165, 20);
            this.txtTelefon.TabIndex = 3;
            // 
            // txtNumeClient
            // 
            this.txtNumeClient.Location = new System.Drawing.Point(100, 27);
            this.txtNumeClient.Name = "txtNumeClient";
            this.txtNumeClient.Size = new System.Drawing.Size(165, 20);
            this.txtNumeClient.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(100, 105);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(165, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // txtPrenumeClient
            // 
            this.txtPrenumeClient.Location = new System.Drawing.Point(100, 53);
            this.txtPrenumeClient.Name = "txtPrenumeClient";
            this.txtPrenumeClient.Size = new System.Drawing.Size(165, 20);
            this.txtPrenumeClient.TabIndex = 2;
            // 
            // btnAdaugareClient
            // 
            this.btnAdaugareClient.Location = new System.Drawing.Point(13, 152);
            this.btnAdaugareClient.Name = "btnAdaugareClient";
            this.btnAdaugareClient.Size = new System.Drawing.Size(252, 50);
            this.btnAdaugareClient.TabIndex = 5;
            this.btnAdaugareClient.Text = "Adaugare Client";
            this.btnAdaugareClient.UseVisualStyleBackColor = true;
            this.btnAdaugareClient.Click += new System.EventHandler(this.btnAdaugareClient_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(10, 109);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 19;
            this.lblEmail.Text = "Email";
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Location = new System.Drawing.Point(10, 82);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(43, 13);
            this.lblTelefon.TabIndex = 18;
            this.lblTelefon.Text = "Telefon";
            // 
            // lblPrenumeClient
            // 
            this.lblPrenumeClient.AutoSize = true;
            this.lblPrenumeClient.Location = new System.Drawing.Point(10, 56);
            this.lblPrenumeClient.Name = "lblPrenumeClient";
            this.lblPrenumeClient.Size = new System.Drawing.Size(81, 13);
            this.lblPrenumeClient.TabIndex = 17;
            this.lblPrenumeClient.Text = "Prenume_Client";
            // 
            // lblNumeClient
            // 
            this.lblNumeClient.AutoSize = true;
            this.lblNumeClient.Location = new System.Drawing.Point(10, 30);
            this.lblNumeClient.Name = "lblNumeClient";
            this.lblNumeClient.Size = new System.Drawing.Size(67, 13);
            this.lblNumeClient.TabIndex = 16;
            this.lblNumeClient.Text = "Nume_Client";
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
            // FormaClienti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 395);
            this.Controls.Add(this.btnMeniu);
            this.Controls.Add(this.dataGridClienti);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormaClienti";
            this.Text = "FormaClienti";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClienti)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMeniu;
        private System.Windows.Forms.DataGridView dataGridClienti;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStergereClient;
        private System.Windows.Forms.Button btnModificaClient;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtNumeClient;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPrenumeClient;
        private System.Windows.Forms.Button btnAdaugareClient;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.Label lblPrenumeClient;
        private System.Windows.Forms.Label lblNumeClient;
        private System.Windows.Forms.Label label4;
    }
}