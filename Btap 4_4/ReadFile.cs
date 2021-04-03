using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Btap_4_4.DAO
{
    class ReadFile
    {
        private static ReadFile instance;

        public static ReadFile Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReadFile();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        String[] s;
        public String[] readFile()
        {
            int countLine = 0;
            int line = 0;
            String stringLine;
            try
            {
                var CurrentDirectory = Directory.GetCurrentDirectory();
                if (CurrentDirectory.Contains("bin\\Debug")) CurrentDirectory = CurrentDirectory.Replace("bin\\Debug", "102190130.txt");
                using (StreamReader sr = new StreamReader(CurrentDirectory))
                {
                    while (sr.ReadLine() != null) countLine++;
                    sr.Close();
                }
                s = new String[countLine];
                using (StreamReader sr = new StreamReader(CurrentDirectory))
                {
                    while ((stringLine = sr.ReadLine())!= null)
                    {
                        s[line] = stringLine.ToString();
                        line++;
                    }
                    sr.Close();
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return s;
        }
    }
}
