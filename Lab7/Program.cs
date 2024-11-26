namespace Lab7
{
    class Student
    {
        //private int _id;
        private string _recordBook;
        private string _fullName;
        private string _departament;
        private string _specification;
        private string _dateOfAdmission;
        private string _group;
        
        // public int id { get => _id; set => _id = value; } 
        public string recordBook { get => _recordBook; set => _recordBook = value; }
        public string fullName { get => _fullName; set => _fullName = value; }
        public string departament  { get => _departament; set => _departament = value; }
        public string specification { get => _specification; set => _specification = value; }
        public string dateOfAdmission { get => _dateOfAdmission; set => _dateOfAdmission = value;}
        public string group { get => _group; set => _group = value; }
    }
    class Departament
    {
        private int _id;
        private string _name;
        public int id { get => _id; set => _id = value; }
        public string name { get => _name; set => _name = value; }
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