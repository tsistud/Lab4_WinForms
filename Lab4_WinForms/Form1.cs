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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size((int)(Screen.PrimaryScreen.WorkingArea.Width * 0.75), (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.75));

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aBOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик: Dair Isakov", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtFolderPath.Text = fbd.SelectedPath;
                    PopulateListBox(fbd.SelectedPath);
                    PopulateDataGridView(fbd.SelectedPath);
                    btnProcessFiles.Visible = true;
                }
            }
        }

        private void PopulateListBox(string folderPath)
        {
            listBoxFolders.Items.Clear();
            string[] directories = Directory.GetDirectories(folderPath);
            foreach (var dir in directories)
            {
                listBoxFolders.Items.Add(Path.GetFileName(dir));
            }
        }

        private void PopulateDataGridView(string folderPath)
        {
            dataGridViewFiles.Rows.Clear();
            dataGridViewFiles.Columns.Clear();
            dataGridViewFiles.Columns.Add("FileName", "Название");
            dataGridViewFiles.Columns.Add("LastModified", "Дата последней модификации");
            dataGridViewFiles.Columns.Add("FileSize", "Количество байт");
            dataGridViewFiles.Columns.Add("Processing", "Процессинг");

            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    dataGridViewFiles.Rows.Add(fileInfo.Name, fileInfo.LastWriteTime, fileInfo.Length);
                }
            }
            else
            {
                MessageBox.Show("Выбранная папка не существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxFolders_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxFolders.SelectedItem != null)
            {
                string selectedFolder = Path.Combine(txtFolderPath.Text, listBoxFolders.SelectedItem.ToString());
                DirectoryInfo dirInfo = new DirectoryInfo(selectedFolder);

                Form folderDetailsForm = new Form();
                folderDetailsForm.Text = "Информация о папке";
                folderDetailsForm.Size = new Size(300, 150);

                Label lblFolderName = new Label();
                lblFolderName.Text = "Название: " + dirInfo.Name;
                lblFolderName.Location = new Point(10, 10);
                lblFolderName.AutoSize = true;
                folderDetailsForm.Controls.Add(lblFolderName);

                Label lblLastModified = new Label();
                lblLastModified.Text = "Дата последней модификации: " + dirInfo.LastWriteTime.ToString();
                lblLastModified.Location = new Point(10, 40);
                lblLastModified.AutoSize = true;
                folderDetailsForm.Controls.Add(lblLastModified);

                folderDetailsForm.Show();
            }
        }

        private void dataGridViewFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string fileName = dataGridViewFiles.Rows[e.RowIndex].Cells["FileName"].Value.ToString();
                string filePath = Path.Combine(txtFolderPath.Text, fileName);

                DialogResult result = MessageBox.Show("Продублировать файл?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string newFilePath = Path.Combine(txtFolderPath.Text, "Copy of " + fileName);
                    File.Copy(filePath, newFilePath);
                    PopulateDataGridView(txtFolderPath.Text);
                }
            }
        }

        private async void btnProcessFiles_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var tasks = dataGridViewFiles.Rows.Cast<DataGridViewRow>().Select(async row =>
            {
                if (row.Cells["FileName"].Value != null)
                {
                    int delay = random.Next(1, dataGridViewFiles.Rows.Count + 1);
                    await Task.Delay(delay * 1000);
                    row.Cells["Processing"].Value = delay;
                }
            }).ToArray();

            await Task.WhenAll(tasks);
        }
    }
    
}

