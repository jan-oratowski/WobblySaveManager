using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WobblySaveManager.Models
{
    internal class Save
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string SaveType { get; set; }
        public DateTime LastModified { get; set; }
        public Save(string path, string saveType)
        {
            Path = path;
            SaveType = saveType;
            Name = System.IO.Path.GetFileNameWithoutExtension(path);
            LastModified = File.GetLastWriteTime(path);
        }
    }
}
