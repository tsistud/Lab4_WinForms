namespace Lab4_WinForms
{
    partial class FolderInfoForm
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
            this.dataGridViewFolderInfo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFolderInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFolderInfo
            // 
            this.dataGridViewFolderInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFolderInfo.Location = new System.Drawing.Point(331, 59);
            this.dataGridViewFolderInfo.Name = "dataGridViewFolderInfo";
            this.dataGridViewFolderInfo.RowHeadersWidth = 51;
            this.dataGridViewFolderInfo.RowTemplate.Height = 24;
            this.dataGridViewFolderInfo.Size = new System.Drawing.Size(745, 303);
            this.dataGridViewFolderInfo.TabIndex = 0;
            // 
            // FolderInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 450);
            this.Controls.Add(this.dataGridViewFolderInfo);
            this.Name = "FolderInfoForm";
            this.Text = "FolderInfoForm";
            this.Load += new System.EventHandler(this.FolderInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFolderInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFolderInfo;
    }
}