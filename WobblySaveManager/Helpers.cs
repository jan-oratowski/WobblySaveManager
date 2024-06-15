using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WobblySaveManager.Models;

namespace WobblySaveManager
{
    internal static class Helpers
    {
        public static string? GetSavePath()
        {
            var localLow = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData", "LocalLow");
            var savePath =  Path.Combine(localLow, "RubberBandGames", "Wobbly Life", "Save");
            return Directory.Exists(savePath) ? savePath : null;
        }

        public static List<Save> GetBackups(string savePath) =>
            Directory.GetFiles(Path.Combine(savePath)).Select(file => new Save(file, "backup")).ToList();

        public static List<Save> GetArchives(string savePath) =>
            Directory.GetFiles(Path.Combine(savePath)).Select(file => new Save(file, "archive")).ToList();

        public static void ArchiveCurrent(string savePath, string basePath)
        {
            var archivePath = Path.Combine(basePath, "Archive");
            if (!Directory.Exists(archivePath))
            {
                Directory.CreateDirectory(archivePath);
            }
            
            var archiveFile = Path.Combine(archivePath,
                $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss} Current.zip");

            ZipFile.CreateFromDirectory(savePath, archiveFile);
        }

        public static void RestoreBackup(string savePath, string backupPath)
        {
            Directory.Delete(savePath, true);
            Directory.CreateDirectory(savePath);
            ZipFile.ExtractToDirectory(backupPath, savePath);
        }
    }
}
