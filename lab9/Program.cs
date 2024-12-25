using System.Formats.Asn1;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Serialization;
using System;

namespace lab9
{
    public class Student
    {
        public string _fullName;
        public string _recordBook;
        public string _specification;

        public string fullName { get => _fullName; set => _fullName = value; }
        public string recordBook { get => _recordBook; set => _recordBook = value; }
        public string specification { get => _specification; set => _specification = value; }
        public Student(string fullName, string recordBook, string specification)
        {
            this.fullName = fullName;
            this.recordBook = recordBook;
            this.specification = specification;
        }
        public Student()
        {
            fullName="";
            recordBook="";
            specification = "";
        }
    }
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
    
}