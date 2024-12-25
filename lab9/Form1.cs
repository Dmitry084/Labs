using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;
using CsvHelper;
using Newtonsoft.Json;
using CsvHelper.Configuration;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace lab9
{
    public partial class Form1 : Form
    {
        string filename = "";
        string filetype = "";
        public Form1()
        {
            InitializeComponent();
        }
        private void loadtotable(List<Student> students)
        {
            try
            {
                dataGridView1.Rows.Clear();
                foreach (Student s in students)
                {
                    dataGridView1.Rows.Add(s.fullName, s.recordBook, s.specification);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось импортировать данные");
            }
        }
        private void loadfromtable(List<Student> students)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var cells = row.Cells;
                    Student s = new Student((string)cells["Column1"].Value, (string)cells["Column2"].Value, (string)cells["Column3"].Value);//row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(),, row.Cells[3].Value.ToString()

                    students.Add(s);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить данные");
            }
        }
        public void importfromxml()
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            List<Student> students = new List<Student>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            try
            {
                students = (List<Student>)xmlSerializer.Deserialize(fs);
                loadtotable(students);
                MessageBox.Show("Данные успешно импортированы из файла " + filename);

            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось импортировать данные");
                dataGridView1.Rows.Clear();
            }
            fs.Close();
        }
        public void exporttoxml()
        {
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            List<Student> students = new List<Student>();
            loadfromtable(students);
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
                try
                {
                    xmlSerializer.Serialize(fs, students);
                    MessageBox.Show("Данные успешно экспортированы в файл " + filename);
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось экспортировать данные");
                }
                fs.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось экспортировать данные");
            }
        }


        public void importfromcsv()
        {
            StreamReader reader = new StreamReader(filename);
            List<Student> students = new List<Student>();
            try
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split('%');
                    Student p = new Student(values[0], values[1], values[2]);
                    students.Add(p);
                }
                loadtotable(students);
                dataGridView1.Rows.RemoveAt(0);
                MessageBox.Show("Данные успешно импортированы из файла " + filename);

            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось импортировать данные");
                dataGridView1.Rows.Clear();
            }
            reader.Close();
        }
        public void exporttocsv()
        {
            StreamWriter writer = new StreamWriter(filename);
            List<Student> students = new List<Student>();
            loadfromtable(students);
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "%" };
                CsvWriter csv = new CsvWriter(writer, config);
                csv.WriteRecords(students);
                MessageBox.Show("Данные успешно экспортированы в файл " + filename);

            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось экспортировать данные");
            }
            writer.Close();
        }

        public void importfromjson()
        {
            List<Student> students = new List<Student>();
            try
            {
                string json = File.ReadAllText(filename);
                students = JsonConvert.DeserializeObject<List<Student>>(json);
                loadtotable(students);
                MessageBox.Show("Данные успешно импортированы из файла " + filename);

            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось импортировать данные");
                dataGridView1.Rows.Clear();
            }
        }
        public void exporttojson()
        {
            List<Student> students = new List<Student>();
            loadfromtable(students);
            try
            {
                string data = JsonConvert.SerializeObject(students, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filename, data);
                MessageBox.Show("Данные успешно экспортированы в файл " + filename);
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось экспортировать данные");
            }
        }
        public void button1_Click(object sender, EventArgs e)//Добавить
        {
            int r = 0;
            int parsedValue;
            if (textBox2.TextLength < 8)
            {
                r = 1;
                MessageBox.Show("Номер студенческого билета должен быть больше 8 символов!");
            }
            if (!int.TryParse(textBox2.Text, out parsedValue))
            {
                r = 1;
                MessageBox.Show("Номер студенческого билета должен состоять только из цифр!");
            }

            if (r == 0)
            {
                Student s = new Student();
                dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, comboBox1.Text);
            }
        }

        public void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите файл";
            ofd.Filter = "Все файлы (*.*)|*.*|Исходный файл XML (*.xml)|*.xml|Файл CSV," +
                " содержащий значения, разделенные '%' (*.csv)|*.csv|Исходный файл JSON (*.json)|*.json";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filetype = Path.GetExtension(ofd.FileName);
                if (filetype == ".xml" || filetype == ".csv" || filetype == ".json")
                {
                    filename = ofd.FileName;
                    textBox3.Text = filename;
                }
                else
                {
                    MessageBox.Show("Выбранный тип файла не подерживается. Выберите один из следующих - XML, CSV, JSON");
                }
            }
        }

        public void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
        public void button3_Click(object sender, EventArgs e)//Импорт
        {
            if (File.Exists(filename))
            {
                switch (filetype)
                {
                    case ".xml":
                        importfromxml();
                        break;
                    case ".csv":
                        importfromcsv();
                        break;
                    case ".json":
                        importfromjson();
                        break;
                    default:
                        MessageBox.Show("Выбранный тип файла не подерживается. Выберите один из следующих - XML, CSV, JSON");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Файл не найден!");
            }
        }
        public void button4_Click(object sender, EventArgs e)//Экспорт
        {
            if (File.Exists(filename))
            {
                switch (filetype)
                {
                    case ".xml":
                        exporttoxml();
                        break;
                    case ".csv":
                        exporttocsv();
                        break;
                    case ".json":
                        exporttojson();
                        break;
                    default:
                        MessageBox.Show("Выбранный тип файла не подерживается. Выберите один из следующих - XML, CSV, JSON");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Файл не найден!");
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }
    }
}