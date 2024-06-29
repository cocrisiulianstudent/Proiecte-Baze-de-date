namespace DotNetOracle
{
    partial class FormaAfisare
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
            this.btnFormAparatFoto = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFormClient = new System.Windows.Forms.Button();
            this.btnFormInchiriere = new System.Windows.Forms.Button();
            this.dataGridInchirieriAparateFoto = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInchirieriAparateFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFormAparatFoto
            // 
            this.btnFormAparatFoto.Location = new System.Drawing.Point(1090, 68);
            this.btnFormAparatFoto.Name = "btnFormAparatFoto";
            this.btnFormAparatFoto.Size = new System.Drawing.Size(120, 50);
            this.btnFormAparatFoto.TabIndex = 7;
            this.btnFormAparatFoto.Text = "Formular Aparat Foto";
            this.btnFormAparatFoto.UseVisualStyleBackColor = true;
            this.btnFormAparatFoto.Click += new System.EventHandler(this.btnFormAparatFoto_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1090, 282);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 50);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnFormClient
            // 
            this.btnFormClient.Location = new System.Drawing.Point(1090, 12);
            this.btnFormClient.Name = "btnFormClient";
            this.btnFormClient.Size = new System.Drawing.Size(120, 50);
            this.btnFormClient.TabIndex = 5;
            this.btnFormClient.Text = "Formular Client";
            this.btnFormClient.UseVisualStyleBackColor = true;
            this.btnFormClient.Click += new System.EventHandler(this.btnFormularClient_Click);
            // 
            // btnFormInchiriere
            // 
            this.btnFormInchiriere.Location = new System.Drawing.Point(1090, 124);
            this.btnFormInchiriere.Name = "btnFormInchiriere";
            this.btnFormInchiriere.Size = new System.Drawing.Size(120, 50);
            this.btnFormInchiriere.TabIndex = 8;
            this.btnFormInchiriere.Text = "Formular Inchiriere Aparat Foto";
            this.btnFormInchiriere.UseVisualStyleBackColor = true;
            this.btnFormInchiriere.Click += new System.EventHandler(this.btnFormInchiriere_Click);
            // 
            // dataGridInchirieriAparateFoto
            // 
            this.dataGridInchirieriAparateFoto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInchirieriAparateFoto.Location = new System.Drawing.Point(12, 12);
            this.dataGridInchirieriAparateFoto.Name = "dataGridInchirieriAparateFoto";
            this.dataGridInchirieriAparateFoto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridInchirieriAparateFoto.Size = new System.Drawing.Size(1072, 320);
            this.dataGridInchirieriAparateFoto.TabIndex = 6;
            // 
            // FormaAfisare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 352);
            this.Controls.Add(this.btnFormAparatFoto);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnFormClient);
            this.Controls.Add(this.btnFormInchiriere);
            this.Controls.Add(this.dataGridInchirieriAparateFoto);
            this.Name = "FormaAfisare";
            this.Text = "FormaAfisare";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInchirieriAparateFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFormAparatFoto;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnFormClient;
        private System.Windows.Forms.Button btnFormInchiriere;
        private System.Windows.Forms.DataGridView dataGridInchirieriAparateFoto;
    }
}