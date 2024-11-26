using System.Xml.Linq;
using System;

namespace lab5
{
    interface IPerson//Интерфейс
    {
        void Iam();
    }
    interface ISpecialist:  IPerson//Производный интерфейс
    {
        new void Iam();
    }
    
    
    class Subject
    {
        public string Sub { get; set; }
        public Subject(string sub) { 
            Sub = sub;
        }
    }
    class Student : ICloneable, IComparable<Student>
    {
        public string _name;
        public int Age { get; set; }
        Subject subject = new Subject("");
        public Student(string _name, int Age, Subject subject)
        {
            this._name = _name;
            this.Age = Age;
            this.subject = subject;
        }
        public virtual void WriteInfo()
        {
            Console.WriteLine("Имя: " + _name + ", Возраст: " + Age + ", Любимый предмет: " + subject.Sub);
        }
        public object Clone()
        {
            return new Student(_name, Age, subject);
        }

        public int CompareTo(Student? other)
        {
            return Age.CompareTo(other?.Age);
        }
        
        
        static void Main(string[] args)
        {
            

            Subject subject = new Subject("Математика");
            ITStudent is1 = new ITStudent("Виталий", 20, subject);
            IPerson isp1 = is1;
            is1.WriteInfo();
            isp1.Iam();

            ITStudent is2 = new ITStudent("Егор", 20, subject);
            ISpecialist isp2 = is2;
            is2.WriteInfo();
            isp2.Iam();

            Student s1 = new Student("Иван", 21, subject);
            s1.WriteInfo();
            Student s2 = (Student)s1.Clone();
            Console.WriteLine(s1.CompareTo(s2));
            
            s2._name = "Матвей";
            s2.WriteInfo();
        }
    }
    class ITStudent : Student, ISpecialist, IPerson
    {
        //Subject subject = new Subject("Математика");
        public ITStudent(string _name, int Age, Subject subject) : base("Егор", 22, subject)
        {
            this._name = _name;
            this.Age = Age;
            //subject = subject;
        }
        void ISpecialist.Iam()
        {
            Console.WriteLine("Я специалист.");
        }
        void IPerson.Iam()
        {
            Console.WriteLine("Я студент.");
        }
    }
}
