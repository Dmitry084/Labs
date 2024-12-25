using System.ComponentModel;
using System.Drawing.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Lab7
{
    public partial class Form1 : Form
    {
        Student[] arr = new Student[20];
        int count = 1;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Rows.Add("20100315", "Захаров Иван Дмитриевич", "131-ПИо", "Институт точных наук и информационных технологий", "Прикладная информатика", "19 декабря 2022г.", 0);
            Student s0 = new Student();
            arr[0] = s0;
            arr[0].recordBook = "20100315";
            arr[0].fullName = "Захаров Иван Дмитриевич";
            arr[0].group = "131-ПИо";
            arr[0].departament = "Институт точных наук и информационных технологий";
            arr[0].specification = "Прикладная информатика";
            arr[0].dateOfAdmission = "19 декабря 2022г.";
            arr[0].id = 0;
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
            label7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }
        private void initDeps()
        {
            List<Departament> Deps = new List<Departament> {
                new Departament{id=1,name="Институт точных наук и информационных технологий"},
                new Departament{id=2,name="Институт гуманитарных наук"},
                new Departament{id=3,name="Институт естественных наук"},
                new Departament{id=4,name="Институт иностранных языков"},
                new Departament{id=5,name="Институт истории и права"},
                new Departament{id=6,name="Институт культуры и искусства"},
                new Departament{id=7,name="Медицинский институт"},
                new Departament{id=8, name = "Институт педагогики и психологии" },
                new Departament{id=9, name = "Институт социальных технологий" },
                new Departament{id=10, name = "Институт экономики и управления" },
                new Departament{id=11, name = "Юридический институт" }
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
                    "Прикладная информатика",
                    "Информационная безопасность",
                    "Математика и компьютерные науки"
                };
                comboBox2.DataSource = list0;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                List<string> list1 = new List<string>
                {
                    "Литература"
                };
                comboBox2.DataSource = list1;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                List<string> list2 = new List<string>
                {
                    "Биология"
                };
                comboBox2.DataSource = list2;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                List<string> list3 = new List<string>
                {
                    "Немецкий язык"
                };
                comboBox2.DataSource = list3;
            }
            if (comboBox1.SelectedIndex == 4)
            {
                List<string> list4 = new List<string>
                {
                    "История"
                };
                comboBox2.DataSource = list4;
            }
            if (comboBox1.SelectedIndex == 5)
            {
                List<string> list1 = new List<string>
                {
                    "Культура"
                };
                comboBox2.DataSource = list1;
            }
            if (comboBox1.SelectedIndex == 6)
            {
                List<string> list2 = new List<string>
                {
                    "Хирургия"
                };
                comboBox2.DataSource = list2;
            }
            if (comboBox1.SelectedIndex == 7)
            {
                List<string> list3 = new List<string>
                {
                    "Педагогика"
                };
                comboBox2.DataSource = list3;
            }
            if (comboBox1.SelectedIndex == 8)
            {
                List<string> list4 = new List<string>
                {
                    "Социальная инженерия"
                };
                comboBox2.DataSource = list4;
            }
            if (comboBox1.SelectedIndex == 9)
            {
                List<string> list3 = new List<string>
                {
                    "Экономика"
                };
                comboBox2.DataSource = list3;
            }
            if (comboBox1.SelectedIndex == 10)
            {
                List<string> list4 = new List<string>
                {
                    "Юриспруденция"
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
            int parsedValue;
            Regex regex = new Regex(@"^\d{3,4}[а,б]?-?[А-Я]{2}[о,з]$");
            if (textBox1.TextLength < 8)
            {
                r = 1;
                MessageBox.Show("Номер студенческого билета должен быть больше 8 символов!");
            }
            if (!int.TryParse(textBox1.Text, out parsedValue))
            {
                r = 1;
                MessageBox.Show("Номер студенческого билета должен состоять только из цифр!");
            }
            if (!regex.IsMatch(textBox3.Text))
            {
                r = 1;
                MessageBox.Show("Такой группы не существует!");
            }

            for (int i = 0; i < count; i++)
            {
                if (arr[i].recordBook == textBox1.Text)
                {
                    r = 1;
                    MessageBox.Show("Пользователь с таким номером студенческого билета уже существует!");
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
                arr[count].id = count;
                dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, comboBox2.Text, dateTimePicker1.Text, count);
                count++;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int r = 0;
            int parsedValue;
            string pattern = "[1-9]{3,4}[а,б]?-[А-Я]{2}[о|з]{1}";
            for (int i = 0; i < count; i++)
            {
                if ((arr[i].recordBook == textBox1.Text) && (arr[i].id != int.Parse(label7.Text)))
                {
                    r++;
                    MessageBox.Show("Пользователь с таким номером студенческого билета уже существует!");
                }
            }

            if (textBox1.TextLength < 8)
            {
                r = 1;
                MessageBox.Show("Номер студенческого билета должен быть больше 8 символов!");
            }
            if (!int.TryParse(textBox1.Text, out parsedValue))
            {
                r = 1;

                MessageBox.Show("Номер студенческого билета должен состоять только из цифр!");
            }

            if (Regex.IsMatch(textBox3.Text, pattern, RegexOptions.IgnoreCase))
            {
                if (r == 0)
                {
                    dataGridView1.CurrentRow.Cells[0].Value = textBox1.Text;
                    dataGridView1.CurrentRow.Cells[1].Value = textBox2.Text;
                    dataGridView1.CurrentRow.Cells[2].Value = textBox3.Text;
                    dataGridView1.CurrentRow.Cells[3].Value = comboBox1.Text;
                    dataGridView1.CurrentRow.Cells[4].Value = comboBox2.Text;
                    dataGridView1.CurrentRow.Cells[5].Value = dateTimePicker1.Text;

                    for (int j = 0; j < count; j++)
                    {
                        if (arr[j].id == int.Parse(label7.Text))
                        {
                            Student s = new Student();
                            arr[j] = s;
                            arr[j].recordBook = textBox1.Text;
                            arr[j].fullName = textBox2.Text;
                            arr[j].group = textBox3.Text;
                            arr[j].departament = comboBox1.Text;
                            arr[j].specification = comboBox2.Text;
                            arr[j].dateOfAdmission = dateTimePicker1.Text;
                        }
                    }
                }
            }
            else
            {
                r = 1;
                MessageBox.Show("Такой группы не существует!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int r = 0;
            for (int i = 0; i < count; i++)
            {
                if (arr[i].recordBook == textBox1.Text)
                {
                    MessageBox.Show("Пользователя с таким номером студенческого билета не существует!");
                    r = 1;
                }
            }
            if (r == 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (arr[i].recordBook == textBox1.Text)
                    {
                        arr[i].recordBook = "";
                        arr[i].fullName = "";
                        arr[i].group = "";
                        arr[i].departament = "";
                        arr[i].specification = "";
                        arr[i].dateOfAdmission = "";
                    }
                }
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }

        }
    }
}