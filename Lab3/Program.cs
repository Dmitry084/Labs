using System.Diagnostics;

namespace lab3
{

    public class Student
    {
        private string _name;
        public int Age { get; set; }
        public static int Step
        { get; set; }
        public static void WriteInfoStep()
        {
            Console.WriteLine($"Стипендия: {Step} ");
        }
        public Student()
        {
            _name = "Матвей";
            Age = 20;
        }
        public Student(string _name, int Age)
        {
            this._name = _name;
            this.Age = Age;

        }
        
        public void WriteInfo()
        {
            Console.WriteLine("Имя: " + _name + ", Возраст: " + Age);
        }
        static void Step3Mes()
        {
            Console.WriteLine("Степендия за 3 месяца: {0}",StepSum.Sum(Student.Step));
        }
        public void BecomeOlder()
        {
            Age++;
        }
        static void Main(string[] args)
        {
            Student s1 = new();
            s1.WriteInfo();
            Student s2 = new("Иван", 23);
            s2.WriteInfo();
            Student s3 = new() { _name = "Егор", Age = 24 };
            s3.WriteInfo();
            Student.Step = 4000;
            Console.WriteLine($"{s1._name} получает степендию в размере {Student.Step} рублей");
            Student.WriteInfoStep();
            Student.Step3Mes();
        }
        static class StepSum
        {
            public static int Sum(int S)
            {
                return S * 3;

            }
        }

    }
}
