using Btap_4_4.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Btap_4_4
{
    public partial class securityPanel : Form
    {
        public securityPanel()
        {
            InitializeComponent();
            ViewHistory.DataSource = ReadFile.Instance.readFile();
            //txtCodeSec.Text = "";
        }
        static String passWord = "2021";
        String passHash = BCrypt.Net.BCrypt.HashPassword(passWord);

        String s = "";
        String record;
        private void but1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            xuli(b.Text[0]);
            txtCodeSec.Text = s;
        }

        private void securityPanel_KeyPress(object sender, KeyPressEventArgs e)
        {
            xuli(e.KeyChar);
            txtCodeSec.Text = s;
            if ((Convert.ToInt32(e.KeyChar) == 13))
            {
                s = "";
                txtCodeSec.Text = s;
            }
        }

        private void xuli(char x)
        {
            if (!((Convert.ToInt32(x) == 13) || x.Equals('E')) && !(Convert.ToInt32(x) == 8 || x.Equals('C')) && Convert.ToInt32(x) >= 48 && Convert.ToInt32(x) <= 57)
            {
                s += x;
            }

            else if ((Convert.ToInt32(x) == 8 || x.Equals('C')))
            {
                if (s.Length > 0) s = s.Remove(s.Length - 1);
            }
            else if ((Convert.ToInt32(x) == 13 || x.Equals('E')))
            {
                DateTime time = DateTime.Now;
                String timeString = deleteStringFromIndex.Instance.delete3charLastInDateTime(time.ToString());
                String passType = txtCodeSec.Text;
                Boolean check = BCrypt.Net.BCrypt.Verify(passType, passHash);
                if (check == false)
                    record = timeString + "\t\tAccess Denied";
                else if (check == true)
                    record = timeString + "\t\tGranted";
                WriteFile.Instance.writeFile(record);
                ViewHistory.DataSource = ReadFile.Instance.readFile();
            }
        }

    }
}
