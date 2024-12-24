using System;

namespace lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                Form1 f1 = (Form1)this.Owner;
               Student s = new Student(1,textBox1.Text, textBox2.Text, comboBox1.Text);
                f1.listView1.Text = "";
                f1.listView1.Refresh();
                this.Close();
            }
        }
    }
}