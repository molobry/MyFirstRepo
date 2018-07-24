using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omada
{
    class Tools
    {
        public static void DeleteFiles(string path, string fileContainsName )
        {
            string[] Files = Directory.GetFiles(path);

            foreach (string file in Files)
            {
                if (file.ToUpper().Contains(fileContainsName.ToUpper()))
                {
                    File.Delete(file);
                }
            }

        }
    }
}
