namespace ShowMeTheData
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
            this.cmbSports = new System.Windows.Forms.ComboBox();
            this.txtSeasonData = new System.Windows.Forms.TextBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.dataSetTeam = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbData = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExtraData = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSports
            // 
            this.cmbSports.FormattingEnabled = true;
            this.cmbSports.Items.AddRange(new object[] {
            "MLB",
            "NBA",
            "NHL",
            "MLS",
            "NFL"});
            this.cmbSports.Location = new System.Drawing.Point(3, 25);
            this.cmbSports.Name = "cmbSports";
            this.cmbSports.Size = new System.Drawing.Size(121, 21);
            this.cmbSports.TabIndex = 0;
            this.cmbSports.SelectedIndexChanged += new System.EventHandler(this.cmbSports_SelectedIndexChanged);
            // 
            // txtSeasonData
            // 
            this.txtSeasonData.Location = new System.Drawing.Point(130, 28);
            this.txtSeasonData.Name = "txtSeasonData";
            this.txtSeasonData.Size = new System.Drawing.Size(100, 20);
            this.txtSeasonData.TabIndex = 3;
            this.txtSeasonData.TextChanged += new System.EventHandler(this.txtSeasonData_TextChanged);
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(513, 47);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 5;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(3, 83);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(513, 351);
            this.txtData.TabIndex = 6;
            // 
            // dataSetTeam
            // 
            this.dataSetTeam.DataSetName = "NewDataSet";
            this.dataSetTeam.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.TableName = "Table1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Enter in a season";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Choose a sport";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Pick the data to display:";
            // 
            // cmbData
            // 
            this.cmbData.FormattingEnabled = true;
            this.cmbData.Location = new System.Drawing.Point(247, 28);
            this.cmbData.Name = "cmbData";
            this.cmbData.Size = new System.Drawing.Size(121, 21);
            this.cmbData.TabIndex = 10;
            this.cmbData.SelectedIndexChanged += new System.EventHandler(this.cmbData_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(383, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 11;
            // 
            // txtExtraData
            // 
            this.txtExtraData.Location = new System.Drawing.Point(386, 28);
            this.txtExtraData.Name = "txtExtraData";
            this.txtExtraData.Size = new System.Drawing.Size(100, 20);
            this.txtExtraData.TabIndex = 12;
            this.txtExtraData.TextChanged += new System.EventHandler(this.txtExtraData_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 469);
            this.Controls.Add(this.txtExtraData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.txtSeasonData);
            this.Controls.Add(this.cmbSports);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSports;
        private System.Windows.Forms.TextBox txtSeasonData;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.TextBox txtData;
        private System.Data.DataSet dataSetTeam;
        private System.Data.DataTable dataTable1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtExtraData;
    }
}

