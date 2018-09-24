namespace EQParser
{
    partial class Stats
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TotalHealsLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TotalCastsLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.EncounterLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.HealeeLabel = new System.Windows.Forms.Label();
            this.database1DataSet4 = new EQParser.Database1DataSet4();
            this.totalHealsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totalHealsTableAdapter3 = new EQParser.Database1DataSet4TableAdapters.TotalHealsTableAdapter();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.spellNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalHealsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Spells Cast";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(502, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Heals";
            // 
            // TotalHealsLabel
            // 
            this.TotalHealsLabel.AutoSize = true;
            this.TotalHealsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TotalHealsLabel.Location = new System.Drawing.Point(590, 22);
            this.TotalHealsLabel.Name = "TotalHealsLabel";
            this.TotalHealsLabel.Size = new System.Drawing.Size(35, 15);
            this.TotalHealsLabel.TabIndex = 3;
            this.TotalHealsLabel.Text = "None";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total Casts";
            // 
            // TotalCastsLabel
            // 
            this.TotalCastsLabel.AutoSize = true;
            this.TotalCastsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TotalCastsLabel.Location = new System.Drawing.Point(590, 49);
            this.TotalCastsLabel.Name = "TotalCastsLabel";
            this.TotalCastsLabel.Size = new System.Drawing.Size(35, 15);
            this.TotalCastsLabel.TabIndex = 5;
            this.TotalCastsLabel.Text = "None";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(502, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Encounter";
            // 
            // EncounterLabel
            // 
            this.EncounterLabel.AutoSize = true;
            this.EncounterLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EncounterLabel.Location = new System.Drawing.Point(590, 77);
            this.EncounterLabel.Name = "EncounterLabel";
            this.EncounterLabel.Size = new System.Drawing.Size(35, 15);
            this.EncounterLabel.TabIndex = 7;
            this.EncounterLabel.Text = "None";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(502, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Healee";
            // 
            // HealeeLabel
            // 
            this.HealeeLabel.AutoSize = true;
            this.HealeeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.HealeeLabel.Location = new System.Drawing.Point(590, 102);
            this.HealeeLabel.Name = "HealeeLabel";
            this.HealeeLabel.Size = new System.Drawing.Size(35, 15);
            this.HealeeLabel.TabIndex = 9;
            this.HealeeLabel.Text = "None";
            // 
            // database1DataSet4
            // 
            this.database1DataSet4.DataSetName = "Database1DataSet4";
            this.database1DataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // totalHealsBindingSource
            // 
            this.totalHealsBindingSource.DataMember = "TotalHeals";
            this.totalHealsBindingSource.DataSource = this.database1DataSet4;
            // 
            // totalHealsTableAdapter3
            // 
            this.totalHealsTableAdapter3.ClearBeforeFill = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.spellNameDataGridViewTextBoxColumn});
            this.dataGridView3.DataSource = this.totalHealsBindingSource;
            this.dataGridView3.Location = new System.Drawing.Point(93, 24);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(273, 462);
            this.dataGridView3.TabIndex = 10;
            // 
            // spellNameDataGridViewTextBoxColumn
            // 
            this.spellNameDataGridViewTextBoxColumn.DataPropertyName = "SpellName";
            this.spellNameDataGridViewTextBoxColumn.HeaderText = "SpellName";
            this.spellNameDataGridViewTextBoxColumn.Name = "spellNameDataGridViewTextBoxColumn";
            this.spellNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Stats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 496);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.HealeeLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.EncounterLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TotalCastsLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TotalHealsLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Stats";
            this.Text = "Stats on Drill Down";
            this.Load += new System.EventHandler(this.Stats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalHealsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TotalHealsLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TotalCastsLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label EncounterLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label HealeeLabel;
        private System.Windows.Forms.BindingSource totalHealsBindingSource;
        public Database1DataSet4 database1DataSet4;
        public Database1DataSet4TableAdapters.TotalHealsTableAdapter totalHealsTableAdapter3;
        public System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn spellNameDataGridViewTextBoxColumn;
    }
}