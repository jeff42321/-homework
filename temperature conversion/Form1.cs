namespace temperature_conversion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string value = btn.Text;

            if (value == "." && textBox1.Text.Contains('.'))
            {
                return;
            }

            textBox1.Text += value;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            double tem = double.Parse(textBox1.Text);
            if (radioButton1.Checked)
            {
                double F = (9.0 / 5) * tem + 32;
                label1.Text = $"���G:{tem}�J = {F:F1}�K";

            }
            if (radioButton2.Checked)
            {

                double C = (tem - 32) * 5 / 9.0;

                label1.Text = $"���G�G{tem}�K = {C:F1}�J";
            }

        }
        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = $"���G�G";
        }
    }
}
