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
            textBox1.Text = $"星座：{sign}\r\n你的生命靈數是：{sum}\r\n{resultText}";
        }
        static string GetZodiacSign(int month, int day)
        {
            switch (month)
            {
                case 1:
                    return day <= 19 ? "Capricorn摩羯座" : "Aquarius水瓶座";
                case 2:
                    return day <= 18 ? "Aquarius水瓶座" : "Pisces雙魚座";
                case 3:
                    return day <= 20 ? "Pisces雙魚座" : "Aries牡羊座";
                case 4:
                    return day <= 19 ? "Aries牡羊座" : "Taurus金牛座";
                case 5:
                    return day <= 20 ? "Taurus金牛座" : "Gemini雙子座";
                case 6:
                    return day <= 21 ? "Gemini雙子座" : "Cancer巨蟹座";
                case 7:
                    return day <= 22 ? "Cancer巨蟹座" : "Leo獅子座";
                case 8:
                    return day <= 22 ? "Leo獅子座" : "Virgo處女座";
                case 9:
                    return day <= 22 ? "Virgo處女座" : "Libra天秤座";
                case 10:
                    return day <= 23 ? "Libra天秤座" : "Scorpio天蠍座";
                case 11:
                    return day <= 22 ? "Scorpio天蠍座" : "Sagittarius射手座";
                case 12:
                    return day <= 21 ? "Sagittarius射手座" : "Capricorn摩羯座";
                default:
                    return "未知星座";
            }
        }
        static string Find(string sign, int number)
        {
            string path = "生命靈數.txt";
            if (!File.Exists(path))
            {
                return "找不到生命靈數資料檔案。";
            }

            string text = File.ReadAllText(path);

            // 先抓到該星座的段落
            string sectionPattern = $"【[^\\r\\n]*{Regex.Escape(sign)}[^\\r\\n]*】([\\s\\S]*?)(?=\\r?\\n\\s*【|\\Z)";
            var sectionMatch = Regex.Match(text, sectionPattern, RegexOptions.Multiline);
            if (!sectionMatch.Success)
            {
                return $"未找到與「{sign}」對應的星座段落。";
            }

            string section = sectionMatch.Groups[1].Value;
            string linePattern = $"生命靈數{number}：([^\\r\\n]*)";
            var m = Regex.Match(section, linePattern);
            if (m.Success)
            {
                return m.Groups[1].Value.Trim();
            }
            else
            {
                return "未找到對應的生命靈數說明。";
            }
        }

   
    }
}