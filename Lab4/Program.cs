namespace lab4
{

    class Student
    {
        public string _name;
        public int Age { get; set; }
        public Student(string _name, int Age)
        {
            this._name = _name;
            this.Age = Age;

        }
        
        public virtual void WriteInfo()//Переопределение метода
        {
            Console.WriteLine("Имя: " + _name + ", Возраст: " + Age);
        }
        public override string ToString()//Переопределение метода ToString()
        {
            return $"Студент: {_name}, {Age}";
        }

        public void BecomeOlder()//Скрытие метода
        {
            Age++;
        }
        public abstract class Person//Абстрактный класс
        {
            public abstract string Name { get; set; }
            public abstract void AbstractMethod();
        }
        static void Main(string[] args)
        {
            Student s1 = new Student("Виталий", 20);

            ITStudent is1 = new ITStudent("Егор",22);//Скрытие метода + Переопределение метода
            is1.WriteInfo();
            Student s3 = (Student)is1;//Скрытие метода + Переопределение метода
            s3.BecomeOlder();//Скрытие метода + Переопределение метода
            s3.WriteInfo();//Скрытие метода + Переопределение метода

            Console.WriteLine(s1);//Переопределение метода ToString()
        }
    }
    class ITStudent : Student
    {
        public ITStudent(string _name, int Age): base("Егор",22)
        {
        }
        public override void WriteInfo()//Переопределение метода
        {
            Console.WriteLine($"Возраст: {base.Age}, Имя: {base._name}");
        }
        public new void BecomeOlder()//Скрытие метода
        {
            Age=Age+2;
        }
    }
}
