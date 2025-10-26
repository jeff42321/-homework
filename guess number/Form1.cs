using System;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace guess_number
{
    public partial class Form1 : Form
    {
        private List<MyDeta> myList;
        public Form1()
        {
            InitializeComponent();
        }
        static List<MyDeta> CreateList()
        {
            Random rnd = new Random();
            return new List<MyDeta>() {
                new MyDeta{RandomNum = rnd.Next(0,10) },
                new MyDeta{RandomNum = rnd.Next(0,10) },
                new MyDeta{RandomNum = rnd.Next(0,10) },
                new MyDeta{RandomNum = rnd.Next(0,10) },
                };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            myList = CreateList();
            button1.Enabled = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (myList != null && myList.Count > 0)
            {
                var Num1 = myList[0].RandomNum;
                var Num2 = myList[1].RandomNum;
                var Num3 = myList[2].RandomNum;
                var Num4 = myList[3].RandomNum;
                MessageBox.Show($"答案是 {Num1}{Num2}{Num3}{Num4}");
            }
            else
            {
                MessageBox.Show($"請按開始");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (myList?.Count != null && textBox1.Text.Length == 4 && int.TryParse(textBox1.Text, out int result))
            {
                int[] tex = textBox1.Text.Select(s => int.Parse(s.ToString())).ToArray();
                MyDeta[] array = myList.ToArray();
                //找出位置不一樣的數字
                var differencesA = array.Select((value, index) =>
                new { Index = index, Value1 = value.RandomNum, Value2 = tex.ElementAtOrDefault(index) })
                .Where(x => x.Value1 != x.Value2).ToList();
                var A = textBox1.Text.Length - differencesA.Count;

                var differencesB = differencesA.Select(x => x.Value1).ToList();//答案中位置錯誤的數字
                int B = differencesA.Count(x =>
                {
                    if (differencesB.Contains(x.Value2))
                    {
                        differencesB.Remove(x.Value2);
                        return true;
                    }
                    return false;
                });
                if (A == textBox1.Text.Length)
                {

                    label3.Text += ("4A\n");
                }
                else
                {
                    label3.Text += $"{A}A{B}B\n";
                }
            }
            else
            {
                MessageBox.Show($"請按開始並輸入有效值");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            myList.Clear();
            textBox1.Text = "";
            label3.Text = "";
        }
    }
}

