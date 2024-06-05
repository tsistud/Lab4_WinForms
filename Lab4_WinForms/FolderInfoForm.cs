using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_WinForms
{
    public partial class FolderInfoForm : Form
    {
        public FolderInfoForm(string folderPath)
        {
            InitializeComponent();
            this.Text = Path.GetFileName(folderPath);
            PopulateDataGridView(folderPath);
        }

        private void FolderInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void PopulateDataGridView(string folderPath)
        {
            dataGridViewFolderInfo.Rows.Clear();
            dataGridViewFolderInfo.Columns.Clear();
            dataGridViewFolderInfo.Columns.Add("FoldName", "Название");
            dataGridViewFolderInfo.Columns.Add("LastModified", "Дата последней модификации");
            dataGridViewFolderInfo.Columns.Add("FolderSize", "Количество байт");

            string[] directories = Directory.GetDirectories(folderPath);
            foreach (var dir in directories)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                long folderSize = GetDirectorySize(dir);
                dataGridViewFolderInfo.Rows.Add(dirInfo.Name, dirInfo.LastWriteTime, folderSize);
            }
        }

        private long GetDirectorySize(string folderPath)
        {
            long size = 0;
            string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                size += fileInfo.Length;
            }
            return size;
        }
    }
}
