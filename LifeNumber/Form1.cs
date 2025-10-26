using System.Text.RegularExpressions;

namespace LifeNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int DigitalRoot(int n)
        {
            if (n < 10)
            {
                return n;
            }
            int sum = Sum(n);

            return DigitalRoot(sum);
        }

        static int Sum(int n)
        {
            if (n < 10)
            {
                return n;
            }
            return (n % 10) + Sum(n / 10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dt = dateTimePicker1.Value;
            string dateString = dt.ToString("yyyyMMdd");
            int dateNumber = int.Parse(dateString);

            int sum = DigitalRoot(dateNumber);
            string sign = GetZodiacSign(dt.Month, dt.Day);

            string resultText = Find(sign, sum);
            textBox1.Text = $"�P�y�G{sign}\r\n�A���ͩR�F�ƬO�G{sum}\r\n{resultText}";
        }
        static string GetZodiacSign(int month, int day)
        {
            switch (month)
            {
                case 1:
                    return day <= 19 ? "Capricorn���~�y" : "Aquarius���~�y";
                case 2:
                    return day <= 18 ? "Aquarius���~�y" : "Pisces�����y";
                case 3:
                    return day <= 20 ? "Pisces�����y" : "Aries�d�Ϯy";
                case 4:
                    return day <= 19 ? "Aries�d�Ϯy" : "Taurus�����y";
                case 5:
                    return day <= 20 ? "Taurus�����y" : "Gemini���l�y";
                case 6:
                    return day <= 21 ? "Gemini���l�y" : "Cancer���ɮy";
                case 7:
                    return day <= 22 ? "Cancer���ɮy" : "Leo��l�y";
                case 8:
                    return day <= 22 ? "Leo��l�y" : "Virgo�B�k�y";
                case 9:
                    return day <= 22 ? "Virgo�B�k�y" : "Libra�ѯ��y";
                case 10:
                    return day <= 23 ? "Libra�ѯ��y" : "Scorpio���Ȯy";
                case 11:
                    return day <= 22 ? "Scorpio���Ȯy" : "Sagittarius�g��y";
                case 12:
                    return day <= 21 ? "Sagittarius�g��y" : "Capricorn���~�y";
                default:
                    return "�����P�y";
            }
        }
        static string Find(string sign, int number)
        {
            string path = "�ͩR�F��.txt";
            if (!File.Exists(path))
            {
                return "�䤣��ͩR�F�Ƹ���ɮסC";
            }

            string text = File.ReadAllText(path);

            // �����ӬP�y���q��
            string sectionPattern = $"�i[^\\r\\n]*{Regex.Escape(sign)}[^\\r\\n]*�j([\\s\\S]*?)(?=\\r?\\n\\s*�i|\\Z)";
            var sectionMatch = Regex.Match(text, sectionPattern, RegexOptions.Multiline);
            if (!sectionMatch.Success)
            {
                return $"�����P�u{sign}�v�������P�y�q���C";
            }

            string section = sectionMatch.Groups[1].Value;
            string linePattern = $"�ͩR�F��{number}�G([^\\r\\n]*)";
            var m = Regex.Match(section, linePattern);
            if (m.Success)
            {
                return m.Groups[1].Value.Trim();
            }
            else
            {
                return "�����������ͩR�F�ƻ����C";
            }
        }

   
    }
}