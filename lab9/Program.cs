namespace lab9
{
    class Student
    {
        private int _id;
        private string _recordBook;
        private string _fullName;
        private string _specification;

        public int id { get => _id; set => _id = value; }
        public string recordBook { get => _recordBook; set => _recordBook = value; }
        public string fullName { get => _fullName; set => _fullName = value; }
        public string specification { get => _specification; set => _specification = value; }
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