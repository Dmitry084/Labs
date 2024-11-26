namespace lab1
{
    
    class Student
    {
        private string _name;
        public int Age { get; set; }
        public Student(string _name, int Age)
        {
            this._name = _name;
            this.Age = Age;

        }
        public void WriteInfo()
        {
            Console.WriteLine("Имя: " + _name + ", Возраст: " + Age);
        }
        public void BecomeOlder()
        {
            Age++;
        }
        static void Main(string[] args)
        {
            Student s1 = new Student("Виталий", 20);
            s1.WriteInfo();
            Student s2 = new Student("Иван", 35);
            s2.WriteInfo();
            s1.BecomeOlder();
            s1.WriteInfo();
            s2.BecomeOlder();
            s2.WriteInfo();

        }
    }
}
