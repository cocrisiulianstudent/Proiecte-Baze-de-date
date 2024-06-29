namespace DotNetOracle
{
    partial class FormaTerenSportiv
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
            this.dataGridTerenSportiv = new System.Windows.Forms.DataGridView();
            this.gbEditareInformatiiTerenSportiv = new System.Windows.Forms.GroupBox();
            this.btnStergereTerenSportiv = new System.Windows.Forms.Button();
            this.btnModificaTerenSportiv = new System.Windows.Forms.Button();
            this.txtTipSport = new System.Windows.Forms.TextBox();
            this.txtDenumire = new System.Windows.Forms.TextBox();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.txtSuprafata = new System.Windows.Forms.TextBox();
            this.btnAdaugareTerenSportiv = new System.Windows.Forms.Button();
            this.lblAdresa = new System.Windows.Forms.Label();
            this.lblTipSport = new System.Windows.Forms.Label();
            this.lblSuprafata = new System.Windows.Forms.Label();
            this.lblDenumire = new System.Windows.Forms.Label();
            this.btnMeniu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTerenSportiv)).BeginInit();
            this.gbEditareInformatiiTerenSportiv.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridTerenSportiv
            // 
            this.dataGridTerenSportiv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTerenSportiv.Location = new System.Drawing.Point(12, 12);
            this.dataGridTerenSportiv.Name = "dataGridTerenSportiv";
            this.dataGridTerenSportiv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTerenSportiv.Size = new System.Drawing.Size(745, 368);
            this.dataGridTerenSportiv.TabIndex = 1;
            this.dataGridTerenSportiv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTerenSportiv_CellContentClick);
            this.dataGridTerenSportiv.SelectionChanged += new System.EventHandler(this.dataGridTerenSportiv_SelectionChanged);
            // 
            // gbEditareInformatiiTerenSportiv
            // 
            this.gbEditareInformatiiTerenSportiv.Controls.Add(this.btnStergereTerenSportiv);
            this.gbEditareInformatiiTerenSportiv.Controls.Add(this.btnModificaTerenSportiv);
            this.gbEditareInformatiiTerenSportiv.Controls.Add(this.txtTipSport);
            this.gbEditareInformatiiTerenSportiv.Controls.Add(this.txtDenumire);
            this.gbEditareInformatiiTerenSportiv.Controls.Add(this.txtAdresa);
            this.gbEditareInformatiiTerenSportiv.Controls.Add(this.txtSuprafata);
            this.gbEditareInformatiiTerenSportiv.Controls.Add(this.btnAdaugareTerenSportiv);
            this.gbEditareInformatiiTerenSportiv.Controls.Add(this.lblAdresa);
            this.gbEditareInformatiiTerenSportiv.Controls.Add(this.lblTipSport);
            this.gbEditareInformatiiTerenSportiv.Controls.Add(this.lblSuprafata);
            this.gbEditareInformatiiTerenSportiv.Controls.Add(this.lblDenumire);
            this.gbEditareInformatiiTerenSportiv.Location = new System.Drawing.Point(763, 12);
            this.gbEditareInformatiiTerenSportiv.Name = "gbEditareInformatiiTerenSportiv";
            this.gbEditareInformatiiTerenSportiv.Size = new System.Drawing.Size(286, 324);
            this.gbEditareInformatiiTerenSportiv.TabIndex = 2;
            this.gbEditareInformatiiTerenSportiv.TabStop = false;
            this.gbEditareInformatiiTerenSportiv.Text = "Editare informatii Teren Sportiv";
            // 
            // btnStergereTerenSportiv
            // 
            this.btnStergereTerenSportiv.Location = new System.Drawing.Point(13, 264);
            this.btnStergereTerenSportiv.Name = "btnStergereTerenSportiv";
            this.btnStergereTerenSportiv.Size = new System.Drawing.Size(252, 50);
            this.btnStergereTerenSportiv.TabIndex = 7;
            this.btnStergereTerenSportiv.Text = "Stergere Teren Sportiv";
            this.btnStergereTerenSportiv.UseVisualStyleBackColor = true;
            this.btnStergereTerenSportiv.Click += new System.EventHandler(this.btnStergereTerenSportiv_Click);
            // 
            // btnModificaTerenSportiv
            // 
            this.btnModificaTerenSportiv.Location = new System.Drawing.Point(13, 208);
            this.btnModificaTerenSportiv.Name = "btnModificaTerenSportiv";
            this.btnModificaTerenSportiv.Size = new System.Drawing.Size(252, 50);
            this.btnModificaTerenSportiv.TabIndex = 6;
            this.btnModificaTerenSportiv.Text = "Modifica Teren Sportiv";
            this.btnModificaTerenSportiv.UseVisualStyleBackColor = true;
            this.btnModificaTerenSportiv.Click += new System.EventHandler(this.btnModificaTerenSportiv_Click);
            // 
            // txtTipSport
            // 
            this.txtTipSport.Location = new System.Drawing.Point(100, 80);
            this.txtTipSport.Name = "txtTipSport";
            this.txtTipSport.Size = new System.Drawing.Size(165, 20);
            this.txtTipSport.TabIndex = 3;
            // 
            // txtDenumire
            // 
            this.txtDenumire.Location = new System.Drawing.Point(100, 28);
            this.txtDenumire.Name = "txtDenumire";
            this.txtDenumire.Size = new System.Drawing.Size(165, 20);
            this.txtDenumire.TabIndex = 1;
            // 
            // txtAdresa
            // 
            this.txtAdresa.Location = new System.Drawing.Point(100, 106);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(165, 20);
            this.txtAdresa.TabIndex = 4;
            // 
            // txtSuprafata
            // 
            this.txtSuprafata.Location = new System.Drawing.Point(100, 54);
            this.txtSuprafata.Name = "txtSuprafata";
            this.txtSuprafata.Size = new System.Drawing.Size(165, 20);
            this.txtSuprafata.TabIndex = 2;
            // 
            // btnAdaugareTerenSportiv
            // 
            this.btnAdaugareTerenSportiv.Location = new System.Drawing.Point(13, 152);
            this.btnAdaugareTerenSportiv.Name = "btnAdaugareTerenSportiv";
            this.btnAdaugareTerenSportiv.Size = new System.Drawing.Size(252, 50);
            this.btnAdaugareTerenSportiv.TabIndex = 5;
            this.btnAdaugareTerenSportiv.Text = "Adaugare Teren Sportiv";
            this.btnAdaugareTerenSportiv.UseVisualStyleBackColor = true;
            this.btnAdaugareTerenSportiv.Click += new System.EventHandler(this.btnAdaugareTerenSportiv_Click);
            // 
            // lblAdresa
            // 
            this.lblAdresa.AutoSize = true;
            this.lblAdresa.Location = new System.Drawing.Point(10, 110);
            this.lblAdresa.Name = "lblAdresa";
            this.lblAdresa.Size = new System.Drawing.Size(40, 13);
            this.lblAdresa.TabIndex = 19;
            this.lblAdresa.Text = "Adresa";
            // 
            // lblTipSport
            // 
            this.lblTipSport.AutoSize = true;
            this.lblTipSport.Location = new System.Drawing.Point(10, 83);
            this.lblTipSport.Name = "lblTipSport";
            this.lblTipSport.Size = new System.Drawing.Size(50, 13);
            this.lblTipSport.TabIndex = 18;
            this.lblTipSport.Text = "Tip Sport";
            // 
            // lblSuprafata
            // 
            this.lblSuprafata.AutoSize = true;
            this.lblSuprafata.Location = new System.Drawing.Point(10, 57);
            this.lblSuprafata.Name = "lblSuprafata";
            this.lblSuprafata.Size = new System.Drawing.Size(53, 13);
            this.lblSuprafata.TabIndex = 17;
            this.lblSuprafata.Text = "Suprafata";
            // 
            // lblDenumire
            // 
            this.lblDenumire.AutoSize = true;
            this.lblDenumire.Location = new System.Drawing.Point(10, 31);
            this.lblDenumire.Name = "lblDenumire";
            this.lblDenumire.Size = new System.Drawing.Size(52, 13);
            this.lblDenumire.TabIndex = 16;
            this.lblDenumire.Text = "Denumire";
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
            // FormaTerenSportiv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 395);
            this.Controls.Add(this.btnMeniu);
            this.Controls.Add(this.dataGridTerenSportiv);
            this.Controls.Add(this.gbEditareInformatiiTerenSportiv);
            this.Name = "FormaTerenSportiv";
            this.Text = "TerenSportiv";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTerenSportiv)).EndInit();
            this.gbEditareInformatiiTerenSportiv.ResumeLayout(false);
            this.gbEditareInformatiiTerenSportiv.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridTerenSportiv;
        private System.Windows.Forms.GroupBox gbEditareInformatiiTerenSportiv;
        private System.Windows.Forms.Button btnStergereTerenSportiv;
        private System.Windows.Forms.Button btnModificaTerenSportiv;
        private System.Windows.Forms.TextBox txtTipSport;
        private System.Windows.Forms.TextBox txtDenumire;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.TextBox txtSuprafata;
        private System.Windows.Forms.Button btnAdaugareTerenSportiv;
        private System.Windows.Forms.Label lblAdresa;
        private System.Windows.Forms.Label lblTipSport;
        private System.Windows.Forms.Label lblSuprafata;
        private System.Windows.Forms.Label lblDenumire;
        private System.Windows.Forms.Button btnMeniu;
    }
}