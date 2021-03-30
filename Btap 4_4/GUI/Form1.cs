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
        }
        static String passWord = "2021";
        String passHash = BCrypt.Net.BCrypt.HashPassword(passWord);

        String s = "";
        private void but1_Click(object sender, EventArgs e)
        {
            s += "1";
            txtCodeSec.Text = s;
        }

        private void but2_Click(object sender, EventArgs e)
        {
            s += "2";
            txtCodeSec.Text = s;
        }

        private void but3_Click(object sender, EventArgs e)
        {
            s += "3";
            txtCodeSec.Text = s;
        }

        private void but4_Click(object sender, EventArgs e)
        {
            s += "4";
            txtCodeSec.Text = s;
        }

        private void but5_Click(object sender, EventArgs e)
        {
            s += "5";
            txtCodeSec.Text = s;
        }

        private void but6_Click(object sender, EventArgs e)
        {
            s += "6";
            txtCodeSec.Text = s;
        }

        private void but7_Click(object sender, EventArgs e)
        {
            s += "7";
            txtCodeSec.Text = s;
        }

        private void but8_Click(object sender, EventArgs e)
        {
            s += "8";
            txtCodeSec.Text = s;
        }

        private void but9_Click(object sender, EventArgs e)
        {
            s += "9";
            txtCodeSec.Text = s;
        }

        private void but0_Click(object sender, EventArgs e)
        {
            s += "0";
            txtCodeSec.Text = s;
        }

        private void butC_Click(object sender, EventArgs e)
        {
            if(s.Length > 0) s = s.Remove(s.Length - 1);
            txtCodeSec.Text = s;
        }
        
        String record;
        private void butE_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            String timeString = deleteStringFromIndex.Instance.delete3charLastInDateTime(time.ToString());
            String passType = txtCodeSec.Text;
            Boolean check = BCrypt.Net.BCrypt.Verify(passType, passHash);
            if (s.Length == 1 && check == false)
                record = timeString + "\tRestricted Access";
            else if (check == false)
                record = timeString + "\tAccess Denied";
            else if (check == true)
                record = timeString + "\tGranted";
            WriteFile.Instance.writeFile(record);
            ViewHistory.DataSource = ReadFile.Instance.readFile();
        }
    }
}
