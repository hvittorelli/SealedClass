using System;

namespace SealedClass
{
    interface IEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Fullname();
        public double Pay();
    }

    class Program
    {
        class Employee : IEmployee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public Employee()
            {
                Id = 0;
                FirstName = string.Empty;
                LastName = string.Empty;
            }
            public Employee(int id, string firstName, string lastName)
            {
                Id = id;
                FirstName = firstName;
                LastName = lastName;
            }
            public string Fullname()
            {
                return FirstName + " " + LastName;
            }
            public virtual double Pay()
            {
                double salary;
                Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
                salary = double.Parse(Console.ReadLine());
                return salary;
            }
        }
        sealed class Executive : Employee
        {
            public string Title { get; set; }
            public double Salary { get; set; }

            public Executive() : base()
            {
                Title = string.Empty;
                Salary = 0;
            }

            public Executive(int id, string firstName, string lastName, string title, double salary)
                : base(id, firstName, lastName)
            {
                Title = title;
                Salary = salary;
            }

            public override double Pay()
            {
                Console.WriteLine($"As an Executive, what is {this.Fullname()}'s weekly salary?");
                Salary = double.Parse(Console.ReadLine());
                Salary = Salary * 52;
                return Salary;
            }
        }
        static void Main(string[] args)
        {
            Employee employeeOne = new Employee(7, "Johnny", "Jones");
            Console.WriteLine($"Employee ID: {employeeOne.Id} \n{employeeOne.Fullname()} is paid {employeeOne.Pay()}");

            Executive executiveOne = new Executive();
            executiveOne.Id = 12;
            executiveOne.FirstName = "Sarah";
            executiveOne.LastName = "Scottsman";
            Console.WriteLine($"Employee ID: {executiveOne.Id} \n{executiveOne.Fullname()} is paid {executiveOne.Pay()} yearly.");
        }
    }
 }