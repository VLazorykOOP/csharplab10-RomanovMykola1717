using System;

class Program
{
    static void Main(string[] args)
    {
        // Задача 1: Обробка винятків

        try
        {
            // Викликаємо метод, який може спричинити StackOverflowException
            RecursiveMethod(1);
        }
        catch (StackOverflowExceptionEx ex)
        {
            Console.WriteLine($"Спричинено StackOverflowException: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Інша помилка: {ex.Message}");
        }


        // Задача 2: Моделювання подій

        // Створення студента
        Student student = new Student("John", 20);

        // Підписка на події
        student.EnteredUniversity += (sender, e) =>
        {
            Console.WriteLine("Подія: Студент вступив до університету!");
        };

        student.ExpelledFromUniversity += (sender, e) =>
        {
            Console.WriteLine("Подія: Студент виключений з університету!");
        };

        // Симуляція подій
        student.EnterUniversity(); // Студент вступив до університету
        student.ExpelFromUniversity(); // Студент виключений з університету
    }

    // Задача 1: Обробка винятків

    // Власний клас винятку для StackOverflowException
    class StackOverflowExceptionEx : Exception
    {
        public StackOverflowExceptionEx(string message) : base(message)
        {
        }
    }

    static void RecursiveMethod(int x)
    {
        if (x == 0)
        {
            return;
        }
        else
        {
            // Викликати метод знову і знову для створення рекурсивного стеку викликів
            RecursiveMethod(x + 1);
        }
    }

    // Задача 2: Моделювання подій

    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // Подія, яка відбувається під час вступу студента до університету
        public event EventHandler EnteredUniversity;

        // Подія, яка відбувається під час виключення студента з університету
        public event EventHandler ExpelledFromUniversity;

        // Конструктор класу
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Метод, який викликає подію вступу до університету
        public void EnterUniversity()
        {
            Console.WriteLine($"{Name} вступив до університету!");
            OnEnteredUniversity();
        }

        // Метод, який викликає подію виключення з університету
        public void ExpelFromUniversity()
        {
            Console.WriteLine($"{Name} виключений з університету!");
            OnExpelledFromUniversity();
        }

        // Метод для виклику події EnteredUniversity
        protected virtual void OnEnteredUniversity()
        {
            EnteredUniversity?.Invoke(this, EventArgs.Empty);
        }

        // Метод для виклику події ExpelledFromUniversity
        protected virtual void OnExpelledFromUniversity()
        {
            ExpelledFromUniversity?.Invoke(this, EventArgs.Empty);
        }
    }
}
