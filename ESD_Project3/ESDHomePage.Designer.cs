namespace ESD_Project3
{
    partial class mainForm
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
            this.searchPanel = new System.Windows.Forms.Panel();
            this.saveSearch = new System.Windows.Forms.Button();
            this.countyComboBox = new System.Windows.Forms.ComboBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.countyLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.zipTextBox = new System.Windows.Forms.TextBox();
            this.zipLabel = new System.Windows.Forms.Label();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.stateComboBox = new System.Windows.Forms.ComboBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.orgNameTextBox = new System.Windows.Forms.TextBox();
            this.organizationNameLabel = new System.Windows.Forms.Label();
            this.orgTypeComboBox = new System.Windows.Forms.ComboBox();
            this.organizationTypeLabel = new System.Windows.Forms.Label();
            this.searchLabel = new System.Windows.Forms.Label();
            this.esdDataGridView = new System.Windows.Forms.DataGridView();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.esdDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.Azure;
            this.searchPanel.Controls.Add(this.saveSearch);
            this.searchPanel.Controls.Add(this.countyComboBox);
            this.searchPanel.Controls.Add(this.clearButton);
            this.searchPanel.Controls.Add(this.countyLabel);
            this.searchPanel.Controls.Add(this.searchButton);
            this.searchPanel.Controls.Add(this.zipTextBox);
            this.searchPanel.Controls.Add(this.zipLabel);
            this.searchPanel.Controls.Add(this.cityComboBox);
            this.searchPanel.Controls.Add(this.cityLabel);
            this.searchPanel.Controls.Add(this.stateComboBox);
            this.searchPanel.Controls.Add(this.stateLabel);
            this.searchPanel.Controls.Add(this.orgNameTextBox);
            this.searchPanel.Controls.Add(this.organizationNameLabel);
            this.searchPanel.Controls.Add(this.orgTypeComboBox);
            this.searchPanel.Controls.Add(this.organizationTypeLabel);
            this.searchPanel.Controls.Add(this.searchLabel);
            this.searchPanel.Location = new System.Drawing.Point(36, 32);
            this.searchPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(535, 578);
            this.searchPanel.TabIndex = 0;
            // 
            // saveSearch
            // 
            this.saveSearch.BackColor = System.Drawing.Color.LightSkyBlue;
            this.saveSearch.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSearch.Location = new System.Drawing.Point(24, 448);
            this.saveSearch.Name = "saveSearch";
            this.saveSearch.Size = new System.Drawing.Size(490, 39);
            this.saveSearch.TabIndex = 16;
            this.saveSearch.Text = "Save Initial Search";
            this.saveSearch.UseVisualStyleBackColor = false;
            this.saveSearch.Click += new System.EventHandler(this.saveSearch_Click);
            // 
            // countyComboBox
            // 
            this.countyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countyComboBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countyComboBox.FormattingEnabled = true;
            this.countyComboBox.Location = new System.Drawing.Point(255, 204);
            this.countyComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.countyComboBox.Name = "countyComboBox";
            this.countyComboBox.Size = new System.Drawing.Size(259, 26);
            this.countyComboBox.TabIndex = 15;
            this.countyComboBox.SelectedIndexChanged += new System.EventHandler(this.countyComboBox_SelectedIndexChanged);
            // 
            // clearButton
            // 
            this.clearButton.AutoSize = true;
            this.clearButton.BackColor = System.Drawing.Color.Gold;
            this.clearButton.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(255, 378);
            this.clearButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(260, 41);
            this.clearButton.TabIndex = 14;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // countyLabel
            // 
            this.countyLabel.AutoSize = true;
            this.countyLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countyLabel.Location = new System.Drawing.Point(141, 209);
            this.countyLabel.Name = "countyLabel";
            this.countyLabel.Size = new System.Drawing.Size(93, 25);
            this.countyLabel.TabIndex = 9;
            this.countyLabel.Text = "County:";
            // 
            // searchButton
            // 
            this.searchButton.AutoSize = true;
            this.searchButton.BackColor = System.Drawing.Color.MediumTurquoise;
            this.searchButton.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(23, 378);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(216, 41);
            this.searchButton.TabIndex = 13;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // zipTextBox
            // 
            this.zipTextBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipTextBox.Location = new System.Drawing.Point(255, 303);
            this.zipTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.zipTextBox.Name = "zipTextBox";
            this.zipTextBox.Size = new System.Drawing.Size(259, 26);
            this.zipTextBox.TabIndex = 12;
            // 
            // zipLabel
            // 
            this.zipLabel.AutoSize = true;
            this.zipLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipLabel.Location = new System.Drawing.Point(123, 300);
            this.zipLabel.Name = "zipLabel";
            this.zipLabel.Size = new System.Drawing.Size(112, 25);
            this.zipLabel.TabIndex = 11;
            this.zipLabel.Text = "ZIP Code:";
            // 
            // cityComboBox
            // 
            this.cityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cityComboBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(255, 257);
            this.cityComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(259, 26);
            this.cityComboBox.TabIndex = 8;
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityLabel.Location = new System.Drawing.Point(176, 258);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(61, 25);
            this.cityLabel.TabIndex = 7;
            this.cityLabel.Text = "City:";
            // 
            // stateComboBox
            // 
            this.stateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stateComboBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateComboBox.Location = new System.Drawing.Point(255, 166);
            this.stateComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stateComboBox.Name = "stateComboBox";
            this.stateComboBox.Size = new System.Drawing.Size(259, 26);
            this.stateComboBox.TabIndex = 6;
            this.stateComboBox.SelectedIndexChanged += new System.EventHandler(this.stateComboBox_SelectedIndexChanged);
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateLabel.Location = new System.Drawing.Point(160, 167);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(75, 25);
            this.stateLabel.TabIndex = 5;
            this.stateLabel.Text = "State:";
            // 
            // orgNameTextBox
            // 
            this.orgNameTextBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orgNameTextBox.Location = new System.Drawing.Point(255, 129);
            this.orgNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.orgNameTextBox.Name = "orgNameTextBox";
            this.orgNameTextBox.Size = new System.Drawing.Size(259, 26);
            this.orgNameTextBox.TabIndex = 4;
            // 
            // organizationNameLabel
            // 
            this.organizationNameLabel.AutoSize = true;
            this.organizationNameLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.organizationNameLabel.Location = new System.Drawing.Point(19, 127);
            this.organizationNameLabel.Name = "organizationNameLabel";
            this.organizationNameLabel.Size = new System.Drawing.Size(216, 25);
            this.organizationNameLabel.TabIndex = 3;
            this.organizationNameLabel.Text = "Organization Name:";
            // 
            // orgTypeComboBox
            // 
            this.orgTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orgTypeComboBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orgTypeComboBox.FormattingEnabled = true;
            this.orgTypeComboBox.Location = new System.Drawing.Point(255, 84);
            this.orgTypeComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.orgTypeComboBox.Name = "orgTypeComboBox";
            this.orgTypeComboBox.Size = new System.Drawing.Size(259, 26);
            this.orgTypeComboBox.TabIndex = 2;
            // 
            // organizationTypeLabel
            // 
            this.organizationTypeLabel.AutoSize = true;
            this.organizationTypeLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.organizationTypeLabel.Location = new System.Drawing.Point(31, 79);
            this.organizationTypeLabel.Name = "organizationTypeLabel";
            this.organizationTypeLabel.Size = new System.Drawing.Size(204, 25);
            this.organizationTypeLabel.TabIndex = 1;
            this.organizationTypeLabel.Text = "Organization Type:";
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLabel.Location = new System.Drawing.Point(213, 22);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(141, 36);
            this.searchLabel.TabIndex = 0;
            this.searchLabel.Text = "SEARCH";
            // 
            // esdDataGridView
            // 
            this.esdDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.esdDataGridView.BackgroundColor = System.Drawing.Color.Azure;
            this.esdDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.esdDataGridView.Location = new System.Drawing.Point(595, 32);
            this.esdDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.esdDataGridView.Name = "esdDataGridView";
            this.esdDataGridView.Size = new System.Drawing.Size(1011, 578);
            this.esdDataGridView.TabIndex = 2;
            this.esdDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.esdDataGridView_CellContentClick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1739, 673);
            this.Controls.Add(this.esdDataGridView);
            this.Controls.Add(this.searchPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emergency Services Directory";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.esdDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.ComboBox stateComboBox;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.TextBox orgNameTextBox;
        private System.Windows.Forms.Label organizationNameLabel;
        private System.Windows.Forms.ComboBox orgTypeComboBox;
        private System.Windows.Forms.Label organizationTypeLabel;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.ComboBox cityComboBox;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox zipTextBox;
        private System.Windows.Forms.Label zipLabel;
        private System.Windows.Forms.Label countyLabel;
        private System.Windows.Forms.ComboBox countyComboBox;
        private System.Windows.Forms.DataGridView esdDataGridView;
        private System.Windows.Forms.Button saveSearch;
    }
}

