using System.Diagnostics;
using System.Globalization;
using WobblySaveManager.Models;

namespace WobblySaveManager
{
    public partial class StartForm : Form
    {
        private readonly string _savePath;
        private readonly ListViewGroup _backupsGroup = new ListViewGroup("Backups", HorizontalAlignment.Right);
        private readonly ListViewGroup _currentGroup = new ListViewGroup("Current", HorizontalAlignment.Right);
        private readonly ListViewGroup _archivesGroup = new ListViewGroup("Archives", HorizontalAlignment.Right);
        public StartForm()
        {
            InitializeComponent();
            var savePath = Helpers.GetSavePath();
            if (savePath == null)
            {
                MessageBox.Show("Save path not found :(", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            _savePath = savePath!;
            txtSavePath.Text = _savePath;
            Reload();

            lvSaves.Groups.Add(_currentGroup);
            lvSaves.Groups.Add(_backupsGroup);
            lvSaves.Groups.Add(_archivesGroup);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", _savePath);
        }

        private void Reload()
        {
            var folders = Directory.GetDirectories(_savePath);

            lvSaves.Items.Clear();

            foreach (var folder in folders)
            {
                if (folder.EndsWith("_Backups"))
                {
                    FillWithBackups(folder);
                }
                else if (folder.EndsWith("Archive"))
                {
                    FillWithArchives(folder); ;
                }
                else
                {
                    FillWithCurrent(folder);
                }
            }

        }

        private void FillWithBackups(string backupsPath)
        {
            var backups = Helpers.GetBackups(backupsPath);
            backups.OrderByDescending(backup => backup.LastModified).ToList().ForEach(backup =>
            {
                var item = new ListViewItem(backup.Name, _backupsGroup);
                item.SubItems.Add(backup.LastModified.ToString(CultureInfo.InvariantCulture));
                item.SubItems.Add("???");
                item.Tag = backup.Path;
                lvSaves.Items.Add(item);
            });
        }
        private void FillWithArchives(string archivesPath)
        {
            var backups = Helpers.GetArchives(archivesPath);
            backups.OrderByDescending(backup => backup.LastModified).ToList().ForEach(backup =>
            {
                var item = new ListViewItem(backup.Name, _archivesGroup);
                item.SubItems.Add(backup.LastModified.ToString(CultureInfo.InvariantCulture));
                item.SubItems.Add("???");
                item.Tag = backup.Path;
                lvSaves.Items.Add(item);
            });
        }

        private void FillWithCurrent(string currentPath)
        {
            var current = new Save(currentPath, "current");
            var item = new ListViewItem(current.Name, _currentGroup);
            item.SubItems.Add(current.LastModified.ToString(CultureInfo.InvariantCulture));
            item.SubItems.Add("???");
            item.Tag = current.Path;
            lvSaves.Items.Add(item);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void lvSaves_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvSaves_DoubleClick(object sender, EventArgs e)
        {
            if (lvSaves.SelectedItems.Count == 0)
            {
                return;
            }

            var selectedItem = lvSaves.SelectedItems[0];
            
            if (selectedItem.Group == _currentGroup && MessageBox.Show(
                    "Do you want to archive current save?",
                    "Archive...",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var itemPath = selectedItem.Tag as string;
                Helpers.ArchiveCurrent(itemPath!, _savePath);
                MessageBox.Show("Current save archived", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reload();
            }

            if ((selectedItem.Group == _backupsGroup || selectedItem.Group == _archivesGroup) && MessageBox.Show(
                    "Do you want to restore this backup? Current save will be overwritten",
                    "Restore...",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var itemPath = selectedItem.Tag as string;
                var currentPath = _currentGroup.Items[0].Tag as string;
                Helpers.RestoreBackup(currentPath!, itemPath!);
                MessageBox.Show("Backup restored", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reload();
            }
        }
    }
}
