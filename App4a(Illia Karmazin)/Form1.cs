namespace App4a_Illia_Karmazin_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "index";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = saveFileDialog1.FileName;
                File.WriteAllText(saveFileDialog1.FileName, (Program.Text1 + Program.Text2));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] csv = System.IO.File.ReadAllLines(textBox1.Text);
            int i = 0;
            string tag1 = "<th>", tag2 = "</th>";
            Program.Text2 = "\n</table>\n</body>\n</html>";
            Program.Text1 = "<!DOCTYPE html>\n<html>\n<head>\n<style>\ntable\n{\nfont-family: arial, sans-serif;\nborder-collapse: collapse;\nwidth: 100%;\n}\ntd, th\n{\nborder: 1px solid #dddddd;\ntext-align: left;\npadding: 8px;\n}\ntr:nth-child(even)\n{\nbackground-color: #c9c9c9;\n}\n</style>\n</head>\n<body>\n<table>";
            foreach (var line1 in csv)
            {
                Program.Text1 += "\n<tr>\n";
                var csv2 = line1.Split(';');
                foreach (var line2 in csv2)
                {
                    Program.Text1 += (tag1 + line2 + tag2);
                }
                Program.Text1 += "\n</tr>";
                if (i == 0)
                {
                    tag1 = "<td>";
                    tag2 = "</td>";
                }
                ++i;
            }
            string path = textBox1.Text, path2 = "";
            i = path.Length - 1;
            while (path[i] != '\\') { --i; }
            for (int j = 0; j < i; ++j)
            {
                path2 += path[j];
            }
            textBox2.Text = path2 + "\\index.html";
        }
    }
}