namespace InterfataUtilizator
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
            this.dataGridInchirieri = new System.Windows.Forms.DataGridView();
            this.btnFormInchiriere = new System.Windows.Forms.Button();
            this.btnFormUtilizator = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFormTerenSportiv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInchirieri)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridInchirieri
            // 
            this.dataGridInchirieri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInchirieri.Location = new System.Drawing.Point(12, 12);
            this.dataGridInchirieri.Name = "dataGridInchirieri";
            this.dataGridInchirieri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridInchirieri.Size = new System.Drawing.Size(1325, 320);
            this.dataGridInchirieri.TabIndex = 1;
            // 
            // btnFormInchiriere
            // 
            this.btnFormInchiriere.Location = new System.Drawing.Point(1343, 124);
            this.btnFormInchiriere.Name = "btnFormInchiriere";
            this.btnFormInchiriere.Size = new System.Drawing.Size(120, 50);
            this.btnFormInchiriere.TabIndex = 3;
            this.btnFormInchiriere.Text = "Formular Inchiriere";
            this.btnFormInchiriere.UseVisualStyleBackColor = true;
            this.btnFormInchiriere.Click += new System.EventHandler(this.btnFormInchiriere_Click);
            // 
            // btnFormUtilizator
            // 
            this.btnFormUtilizator.Location = new System.Drawing.Point(1343, 12);
            this.btnFormUtilizator.Name = "btnFormUtilizator";
            this.btnFormUtilizator.Size = new System.Drawing.Size(120, 50);
            this.btnFormUtilizator.TabIndex = 1;
            this.btnFormUtilizator.Text = "Formular Utilizator";
            this.btnFormUtilizator.UseVisualStyleBackColor = true;
            this.btnFormUtilizator.Click += new System.EventHandler(this.btnFormUtilizator_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1343, 282);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 50);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // btnFormTerenSportiv
            // 
            this.btnFormTerenSportiv.Location = new System.Drawing.Point(1343, 68);
            this.btnFormTerenSportiv.Name = "btnFormTerenSportiv";
            this.btnFormTerenSportiv.Size = new System.Drawing.Size(120, 50);
            this.btnFormTerenSportiv.TabIndex = 2;
            this.btnFormTerenSportiv.Text = "Formular Teren Sportiv";
            this.btnFormTerenSportiv.UseVisualStyleBackColor = true;
            this.btnFormTerenSportiv.Click += new System.EventHandler(this.btnFormTerenSportiv_Click);
            // 
            // FormaAfisare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 345);
            this.Controls.Add(this.btnFormTerenSportiv);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnFormUtilizator);
            this.Controls.Add(this.btnFormInchiriere);
            this.Controls.Add(this.dataGridInchirieri);
            this.Name = "FormaAfisare";
            this.Text = "Inchirieri Terenuri Sportive";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormaAfisare_FormClosed);
            this.Load += new System.EventHandler(this.FormaAfisare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInchirieri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridInchirieri;
        private System.Windows.Forms.Button btnFormInchiriere;
        private System.Windows.Forms.Button btnFormUtilizator;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnFormTerenSportiv;
    }
}

