namespace lab6
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
        static void Main(string[] args)
        {
            string? name="";
            int age=0;
            
            try
            {
                Console.Write("Введите имя студента: ");
                name = Console.ReadLine();
                
            }
            catch (FormatException)
            {
                Console.WriteLine("Не тот формат");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Аргумент не может быть меньше нуля");
            }
            finally
            {
                Console.WriteLine("Имя сохранено");
            }
            try
            {
                Console.Write("Введите возраст студента: ");
                age = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Не тот формат");
                Console.Write("Введите возраст студента ещё раз: ");
                age = Convert.ToInt32(Console.ReadLine());
                

            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Аргумент не может быть меньше нуля");
            }
            finally
            {
                Console.WriteLine("Возраст сохранён");

            }
            Student s1 = new Student(name, age);
            s1.WriteInfo();
        }
    }
}
