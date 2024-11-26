using System.Drawing.Text;
using System.Security.Cryptography;

namespace Lab7
{
    public partial class Form1 : Form
    {
        Student[] arr = new Student[20];
        int count = 1;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Rows.Add("20100315", "������� ���� ����������", "131-���", "�������� ������ ���� � �������������� ����������", "���������� �����������", "19 ������� 2022�.");
            Student s0 = new Student();
            arr[0] = s0;
            arr[0].recordBook = "20100315";
            arr[0].fullName = "������� ���� ����������";
            arr[0].group = "131-���";
            arr[0].departament = "�������� ������ ���� � �������������� ����������";
            arr[0].specification = "���������� �����������";
            arr[0].dateOfAdmission = "19 ������� 2022�.";
            initDeps();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
        private void initDeps()
        {
            List<Departament> Deps = new List<Departament> {
                new Departament{id=1,name="�������� ������ ���� � �������������� ����������"},
                new Departament{id=2,name="�������� ������������ ����"},
                new Departament{id=3,name="�������� ������������ ����"},
                new Departament{id=4,name="�������� ����������� ������"},
                new Departament{id=5,name="�������� ������� � �����"},
                new Departament{id=6,name="�������� �������� � ���������"},
                new Departament{id=7,name="����������� ��������"},
                new Departament{id=8, name = "�������� ���������� � ����������" },
                new Departament{id=9, name = "�������� ���������� ����������" },
                new Departament{id=10, name = "�������� ��������� � ����������" },
                new Departament{id=11, name = "����������� ��������" }
            };
            comboBox1.DataSource = Deps;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                List<string> list0 = new List<string>
                {
                    "���������� �����������",
                    "�������������� ������������",
                    "���������� � ������������ �����"
                };
                comboBox2.DataSource = list0;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                List<string> list1 = new List<string>
                {
                    "����������"
                };
                comboBox2.DataSource = list1;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                List<string> list2 = new List<string>
                {
                    "��������"
                };
                comboBox2.DataSource = list2;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                List<string> list3 = new List<string>
                {
                    "�������� ����"
                };
                comboBox2.DataSource = list3;
            }
            if (comboBox1.SelectedIndex == 4)
            {
                List<string> list4 = new List<string>
                {
                    "�������"
                };
                comboBox2.DataSource = list4;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            initDeps();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int r = 0;

            for (int i = 0; i < count; i++)
            {
                if (arr[i].recordBook == textBox1.Text)
                {
                    r = 1;
                    MessageBox.Show("������������ � ����� ������� ������������� ������ ��� ����������!");
                }
            }

            if (r == 0)
            {
                Student s = new Student();
                arr[count] = s;
                arr[count].recordBook = textBox1.Text;
                arr[count].fullName = textBox2.Text;
                arr[count].group = textBox3.Text;
                arr[count].departament = comboBox1.Text;
                arr[count].specification = comboBox2.Text;
                arr[count].dateOfAdmission = dateTimePicker1.Text;
                count++;
                dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, comboBox2.Text, dateTimePicker1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int r = 0;
            for (int i = 0; i < count; i++)
            {
                if (arr[i].recordBook == textBox1.Text)
                {
                    MessageBox.Show("������������ � ����� ������� ������������� ������ ��� ����������!");
                    r = 1;
                }
            }

            if (r == 0)
            {
                dataGridView1.CurrentRow.Cells[0].Value = textBox1.Text;
                dataGridView1.CurrentRow.Cells[1].Value = textBox2.Text;
                dataGridView1.CurrentRow.Cells[2].Value = textBox3.Text;
                dataGridView1.CurrentRow.Cells[3].Value = comboBox1.Text;
                dataGridView1.CurrentRow.Cells[4].Value = comboBox2.Text;
                dataGridView1.CurrentRow.Cells[5].Value = dateTimePicker1.Text;


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < count; i++)
            {
                if (arr[i].recordBook == textBox1.Text)
                {

                }
            }
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }
    }
}