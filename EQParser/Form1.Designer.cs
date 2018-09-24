namespace EQParser
{
    partial class Form1
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelResult = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalHealDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalHealCTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spellNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.encounterDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eachHealDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.healeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalHealsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSet1 = new EQParser.Database1DataSet1();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.encounterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalHealsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSet = new EQParser.Database1DataSet();
            this.totalHealsTableAdapter = new EQParser.Database1DataSetTableAdapters.TotalHealsTableAdapter();
            this.totalHealsTableAdapter1 = new EQParser.Database1DataSet1TableAdapters.TotalHealsTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalHealsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalHealsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 67);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(44, 94);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(37, 13);
            this.labelResult.TabIndex = 1;
            this.labelResult.Text = "Status";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(850, 536);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Your Heals";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.totalHealDataGridViewTextBoxColumn,
            this.totalHealCTDataGridViewTextBoxColumn,
            this.playerNameDataGridViewTextBoxColumn,
            this.spellNameDataGridViewTextBoxColumn,
            this.encounterDataGridViewTextBoxColumn1,
            this.eachHealDataGridViewTextBoxColumn,
            this.healeeDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.totalHealsBindingSource1;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(844, 530);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // totalHealDataGridViewTextBoxColumn
            // 
            this.totalHealDataGridViewTextBoxColumn.DataPropertyName = "TotalHeal";
            this.totalHealDataGridViewTextBoxColumn.HeaderText = "TotalHeal";
            this.totalHealDataGridViewTextBoxColumn.Name = "totalHealDataGridViewTextBoxColumn";
            this.totalHealDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalHealCTDataGridViewTextBoxColumn
            // 
            this.totalHealCTDataGridViewTextBoxColumn.DataPropertyName = "TotalHealCT";
            this.totalHealCTDataGridViewTextBoxColumn.HeaderText = "TotalHealCT";
            this.totalHealCTDataGridViewTextBoxColumn.Name = "totalHealCTDataGridViewTextBoxColumn";
            this.totalHealCTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // playerNameDataGridViewTextBoxColumn
            // 
            this.playerNameDataGridViewTextBoxColumn.DataPropertyName = "PlayerName";
            this.playerNameDataGridViewTextBoxColumn.HeaderText = "PlayerName";
            this.playerNameDataGridViewTextBoxColumn.Name = "playerNameDataGridViewTextBoxColumn";
            this.playerNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // spellNameDataGridViewTextBoxColumn
            // 
            this.spellNameDataGridViewTextBoxColumn.DataPropertyName = "SpellName";
            this.spellNameDataGridViewTextBoxColumn.HeaderText = "SpellName";
            this.spellNameDataGridViewTextBoxColumn.Name = "spellNameDataGridViewTextBoxColumn";
            this.spellNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // encounterDataGridViewTextBoxColumn1
            // 
            this.encounterDataGridViewTextBoxColumn1.DataPropertyName = "Encounter";
            this.encounterDataGridViewTextBoxColumn1.HeaderText = "Encounter";
            this.encounterDataGridViewTextBoxColumn1.Name = "encounterDataGridViewTextBoxColumn1";
            this.encounterDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // eachHealDataGridViewTextBoxColumn
            // 
            this.eachHealDataGridViewTextBoxColumn.DataPropertyName = "EachHeal";
            this.eachHealDataGridViewTextBoxColumn.HeaderText = "EachHeal";
            this.eachHealDataGridViewTextBoxColumn.Name = "eachHealDataGridViewTextBoxColumn";
            this.eachHealDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // healeeDataGridViewTextBoxColumn
            // 
            this.healeeDataGridViewTextBoxColumn.DataPropertyName = "Healee";
            this.healeeDataGridViewTextBoxColumn.HeaderText = "Healee";
            this.healeeDataGridViewTextBoxColumn.Name = "healeeDataGridViewTextBoxColumn";
            this.healeeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalHealsBindingSource1
            // 
            this.totalHealsBindingSource1.DataMember = "TotalHeals";
            this.totalHealsBindingSource1.DataSource = this.database1DataSet1;
            // 
            // database1DataSet1
            // 
            this.database1DataSet1.DataSetName = "Database1DataSet1";
            this.database1DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(283, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(858, 562);
            this.tabControl1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.encounterDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.totalHealsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(13, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(268, 469);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 50;
            // 
            // encounterDataGridViewTextBoxColumn
            // 
            this.encounterDataGridViewTextBoxColumn.DataPropertyName = "Encounter";
            this.encounterDataGridViewTextBoxColumn.HeaderText = "Encounter";
            this.encounterDataGridViewTextBoxColumn.Name = "encounterDataGridViewTextBoxColumn";
            this.encounterDataGridViewTextBoxColumn.ReadOnly = true;
            this.encounterDataGridViewTextBoxColumn.Width = 130;
            // 
            // totalHealsBindingSource
            // 
            this.totalHealsBindingSource.DataMember = "TotalHeals";
            this.totalHealsBindingSource.DataSource = this.database1DataSet;
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // totalHealsTableAdapter
            // 
            this.totalHealsTableAdapter.ClearBeforeFill = true;
            // 
            // totalHealsTableAdapter1
            // 
            this.totalHealsTableAdapter1.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(413, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select your log file, drill down by double clicking encounter and then by healee";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(128, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 66);
            this.button2.TabIndex = 7;
            this.button2.Text = "Log Chunker";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 634);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Narogg\'s Heal Parser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalHealsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalHealsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Database1DataSet database1DataSet;
        private System.Windows.Forms.BindingSource totalHealsBindingSource;
        private Database1DataSetTableAdapters.TotalHealsTableAdapter totalHealsTableAdapter;
        private Database1DataSet1 database1DataSet1;
        private System.Windows.Forms.BindingSource totalHealsBindingSource1;
        private Database1DataSet1TableAdapters.TotalHealsTableAdapter totalHealsTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalHealDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalHealCTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn spellNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn encounterDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn eachHealDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn healeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn encounterDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}