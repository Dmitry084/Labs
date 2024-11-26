namespace lab2
{

    class Student
    {
        private string _name;
        public int Age { get; set; }
        private Game _game;
        private Subject _subject;
        public Student(string _name, int Age, Subject _subject, Game _game)
        {
            this._name = _name;
            this.Age = Age;
            this._subject = _subject;
            this._game = _game;
        }
        public void WriteInfo()
        {
            Console.WriteLine("Имя: " + _name + ", Возраст: " + Age + ",Любимый предмет: " + _subject.WriteInfoS() + ", Любимая игра: " + _game.Name);
        }
        public void BecomeOlder(int a)
        {
            a++;
        }
        public void BecomeOlderref(ref int a)
        {
            a++;
        }
        static void Main(string[] args)
        {
            Subject su1 = new Subject("Математика");
            Game g1 = new Game("Ведьмак 3");
            Game g2 = new Game("Terraria");
            Student s1 = new Student("Виталий", 20, su1, g1);
            Student s2 = new Student("Иван", 35,su1,g2);
            int a = s1.Age;
            Console.WriteLine("Возраст до передачи по значению: " +a);
            s1.BecomeOlder(a);
            Console.WriteLine("Возраст до передачи по значению: " + a);

            Console.WriteLine("Возраст до передачи по ссылке: " + a);
            s1.BecomeOlderref(ref a);
            Console.WriteLine("Возраст до передачи по ссылке: " + a);

            //Console.WriteLine(su1._name); // Не работает
            Console.WriteLine(g1.Name); // Работает

            s1.WriteInfo();
            s2.WriteInfo();
        }
        public class Subject
        {
            private string _name;
            public Subject(string _name)
            {
                this._name = _name;

            }
            public string WriteInfoS()
            {
                return _name;
            }

        }
        public class Game
        {
            public string Name;
            public Game(string Name)
            {
                this.Name = Name;
            }
            
        }
    }
    

}
