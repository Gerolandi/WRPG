using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace WRPG.Classes.GameClass.DataClasses
{
    public struct Save
    {
        public Charecter? Charecter { get; set; }
        public Save(int numSave)
        {
            string path = $"D:\\Formy\\WRPG\\WRPG\\Assets\\Saves\\Charecter{numSave}.json";
            if (File.Exists(path))
            {
                Charecter = JsonSerializer.Deserialize<Charecter>(File.ReadAllText(path));
            }
            else Charecter = null;
        }
        public new string ToString()
        {
            if (Charecter == null) return "Create charecter";
            return Charecter.Name;
        }

    }
}
