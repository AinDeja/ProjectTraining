using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            str = Regex.Replace(str, @"\W", string.Empty);//去除括号
            IList<long> numberint = GetNumberic(str);
            IList<string> strinfo = GetStrings(str);
            IList<string> AZinfo = GetAZ(strinfo[0]);//快递编号字母提取
            int az = AZinfo.Count - 1;
            string kb = AZinfo[az] + numberint[0];
            string kdgs="";
            for (int i = 0; i < az; i++)//快递公司 名字组合
            {
                kdgs += AZinfo[i];
            }
            


            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = kdgs;
            this.dataGridView1.Rows[index].Cells[1].Value = kb;
            this.dataGridView1.Rows[index].Cells[2].Value = strinfo[1];
            this.dataGridView1.Rows[index].Cells[3].Value = numberint[1];
            this.dataGridView1.Rows[index].Cells[4].Value = strinfo[2];
        }
        public static IList<long> GetNumberic(string str)
        {
            IList<long> numbericList = new List<long>();
            MatchCollection ms = Regex.Matches(str, @"\d+");
            foreach (Match m in ms)
            {
                numbericList.Add(Convert.ToInt64(m.Value));
            }
            return numbericList;
        }

        public static IList<string> GetStrings(string str)
        {
            IList<string> strList = new List<string>();
            MatchCollection ms = Regex.Matches(str, @"\D+");
            foreach (Match m in ms)
            {
                strList.Add(m.Value);
            }
            return strList;
        }

        public static IList<string> GetAZ(string str)
        {
            IList<string> strList = new List<string>();
            MatchCollection ms = Regex.Matches(str, @"\w");
            foreach (Match m in ms)
            {
                strList.Add(m.Value);
            }
            return strList;
        }
    }
}
