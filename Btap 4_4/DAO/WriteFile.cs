using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Btap_4_4.DAO
{
    class WriteFile
    {
        private static WriteFile instance;

        internal static WriteFile Instance {
            get
            {
                if (instance == null)
                {
                    instance = new WriteFile();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public void writeFile(String s)
        {
            try
            {
                var CurrentDirectory = Directory.GetCurrentDirectory();
                if (CurrentDirectory.Contains("bin\\Debug")) CurrentDirectory = CurrentDirectory.Replace("bin\\Debug", "102190130.txt");
                using (StreamWriter sw = new StreamWriter(CurrentDirectory,true))
                {
                    sw.WriteLine(s);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
