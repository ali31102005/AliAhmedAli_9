using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AliAhmedAli_9
{





    enum Weekdays : byte { Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

    enum Grades : short
    {
        F = 1, E, D, C, B, A
    }
    enum Gender { M, F }

    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Dept { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}, {Gender}, {Dept}";
        }


    }



    internal class Parent
    {
        public virtual void Print()
        {
            Console.WriteLine("Parent");
        }
        private int salary;

        // virtual prop
        public virtual int Salary
        {
            get { return salary; }
            set { salary = value + 1000; }
        }

    }
    internal class Child : Parent
    {
        public sealed override void Print()
        {
            Console.WriteLine("Child");
        }
        public sealed override int Salary
        {
            get { return base.Salary; }
            set { base.Salary = value + 2000; }
        }



        public void DisplaySalary()
        {
            Console.WriteLine(Salary);
        }
    }

    static class Utillity
    {



        public static double CalcPerimeter_Rec(double len)
        {
            return len * 4;
        }



        public static double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }


    }


    internal class ComplexNumber
    {
        public int Real { get; set; }
        public int Imag { get; set; }

        public override string ToString()
        {
            return $"{Real} + {Imag}i";
        }

        public static ComplexNumber operator +(ComplexNumber Left, ComplexNumber Right)
        {


            return new ComplexNumber()
            {
                Real = (Left?.Real ?? 0) + (Right?.Real ?? 0),
                Imag = (Left?.Imag ?? 0) + (Right?.Imag ?? 0),
            };
        }
        public static ComplexNumber operator -(ComplexNumber Left, ComplexNumber Right)
        {
            return new ComplexNumber()
            {
                Real = Left.Real - Right.Real,
                Imag = Left.Imag - Right.Imag,
            };
        }

        public static ComplexNumber operator *(ComplexNumber Left, ComplexNumber Right)
        {
            return new ComplexNumber()
            {
                Real = ((Left?.Real ?? 0) * (Right?.Real ?? 0)) - ((Left?.Imag ?? 0) * (Right?.Imag ?? 0)),
                Imag = ((Left?.Real ?? 0) * (Right?.Imag ?? 0)) + ((Left?.Imag ?? 0) * (Right?.Real ?? 0))
            };
        }



    }

    class Department
    {
        public string dep { get; set; }
        public override bool Equals(object obj)
        {
            Department passed = (Department)obj;
            return passed.dep.Equals(this.dep); 
        }
    }


    internal struct Employee
    {
        private readonly int EmpID;
        private string EmpName;
        private decimal empsalary;
        public Department dept { get; set; }


        public string GetName()
        {
            return EmpName;
        }
        public void SetName(string value)
        {
            EmpName = value.Length <= 20 ? value : value.Substring(0, 20);
        }


        public decimal Salary
        {
            get { return empsalary; }
            set { empsalary = value < 4000 ? 4000 : value; }
        }


        public Employee(int _id, string _Name, decimal _salary)
        {
            EmpID = _id;
            EmpName = _Name;
            empsalary = _salary;
        }

        public override string ToString()
        {
            return $"Emp Id is {EmpID}, Name is {EmpName}, Salary is {empsalary}";
        }
        public decimal Bonus
        {
            get { return empsalary * 0.1M; }
        }


        public override bool Equals(object obj)
        {
            Employee passed = (Employee)obj;
            return passed.EmpID == this.EmpID && passed.dept.Equals(this.dept);
        }



    }



    static class Helper<T>
    {
        public static int SearchArr(T[] Arr, T Value)
        {
            for (int i = 0; i < Arr?.Length; i++)
            {
                if (Value.Equals((Arr[i])))
                    return i;
            }
            return -1;
        }



        public static T Max<T>(T t1, T t2) where T : IComparable
        {
            return t1.CompareTo(t2) > 0 ? t1 : t2;
        }



        public static void ReplaceArray(T[] arr, T Old, T New)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i].Equals(Old) ? New : arr[i];
            }

        }



    }



    struct Rect
    {
        public int Length { get; set; }
        public int Width { get; set; }

    }


    struct Circle
    {
        public double Radius { get; set; }
        public string Color { get; set; }
    }




    #region Part2_p2
    class Stack<T>
    {
        T Element;
        Stack<T> Peek, Next;
        public void Push(T E)
        {
            Stack<T> S = new Stack<T>();
            S.Element = E;
            S.Next = Peek;
            Peek = S;
        }


        public void Pop()
        {
            Peek = Peek.Next;
        }


        public T GetPeek()
        {
            return Peek.Element;
        }
    } 
    #endregion




    class Program
    {



        public static void Swap(ref Rect R1, ref Rect R2)
        {
            Rect T = R1;
            R1 = R2;
            R2 = T;
        }

        #region Part2_P1

        public static T[] ReverseArr<T>(T[] Arr)
        {
            T[] Arr2 = new T[Arr.Length];

            for (int i = Arr.Length - 1, j = 0; i >= 0; i--, j++)
            {
                Arr2[j] = Arr[i];
            }
            return Arr2;
        }
        #endregion

        #region Part2_P3
        public static void Swap<T>(T[] Arr, int ind1, int ind2)
        {
            T Temp = Arr[ind1];
            Arr[ind1] = Arr[ind2];
            Arr[ind2] = Temp;
        }
        #endregion

        #region Part2_P4
        public static T MaxInArr<T>(T[] Arr) where T : IComparable
        {
            T Max = Arr[0];
            for (int i = 0; i < Arr.Length; i++)
            {
                Max = Max.CompareTo(Arr[i]) > 0 ? Max : Arr[i];
            }
            return Max;
        } 
        #endregion

        public static void Main(string[] args)
        {
            #region P1
            //Weekdays d = Weekdays.Monday;
            //for (byte i = 0; i < 7; i++)
            //{
            //    Console.WriteLine($"{d}, {(byte)d}");
            //    d++;
            //}
            #endregion

            #region P2
            //Grades g = Grades.F;
            //for (short i = 0; i < 6; i++)
            //{
            //    Console.WriteLine($"{g}, {(short)g}");
            //    g++;
            //} 
            #endregion

            #region P3

            //Person p1 = new Person() { Dept = "CS", Name = "Ali", Gender = Gender.M, Id = 230900037 };
            //Person p2 = new Person() { Dept = "IT", Name = "Soso", Gender = Gender.F, Id = 230900038 };
            //Console.WriteLine(p1);
            //Console.WriteLine(p2); 
            #endregion

            #region P4
            //Child Child = new Child();
            //Child.Salary = 1000;
            //Child.DisplaySalary();
            #endregion

            #region P5

            //Console.WriteLine(Utillity.CalcPerimeter_Rec(5.5));


            #endregion

            #region P6

            //ComplexNumber c1 = new ComplexNumber() { Real = 5, Imag = 5 };
            //ComplexNumber c2 = new ComplexNumber() { Real = 4, Imag = 5 };
            //ComplexNumber c3 = c1 * c2;
            //Console.WriteLine(c3.ToString()); 
            #endregion

            #region P7

            //Console.WriteLine(Utillity.CelsiusToFahrenheit(615.516));

            #endregion

            #region P8

            //Employee[] emps = { new Employee(1, "ali", 615465), new Employee(2, "Ahmed", 6454) };

            //Console.WriteLine(Helper<Employee>.SearchArr(emps, new Employee(1, "ali", 615465))); 
            #endregion

            #region P9

            //Console.WriteLine(Helper<string>.Max("Alii", "Ali"));
            //Console.WriteLine(Helper<int>.Max(10, 20));
            //Console.WriteLine(Helper<double>.Max(5.5, 5.6));

            #endregion


            #region P10
            //string[] SArr = { "ali", "ahmed", "ali" };
            //foreach (string s in SArr)
            //{
            //    Console.WriteLine(s);
            //}
            //Helper<string>.ReplaceArray(SArr, "ali", "lol");

            //foreach (string s in SArr)
            //{
            //    Console.WriteLine(s);
            //}

            //int[] Arr = { 5, 5, 8, 2, 8, 2, 4, 23, 4, 5 };
            //foreach (int i in Arr)
            //{
            //    Console.WriteLine(i);
            //}
            //Helper<int>.ReplaceArray(Arr, 5, 50);

            //foreach (int i in Arr)
            //{
            //    Console.WriteLine(i);
            //} 
            #endregion



            #region P11

            //Rect r1 = new Rect() { Length = 10, Width = 5 };
            //Rect r2 = new Rect() { Width = 15, Length = 100 };
            //Console.WriteLine(r2.Length);
            //Console.WriteLine(r1.Length);
            //Swap(ref r1, ref r2);
            //Console.WriteLine(r2.Length);
            //Console.WriteLine(r1.Length); 
            #endregion

            #region P12

            //Circle c1 = new Circle() { Radius = 5.5, Color = "red"};
            //Circle c2 = new Circle() { Radius = 5.5, Color = "red"};
            //Console.WriteLine(c1.Equals(c2));
            //Console.WriteLine(c2 == c1);// compilation Error -> not implemented in struct

            #endregion

        }




        //Why is it recommended to explicitly assign values to enum members in some cases? 
        //to ensure clarity, control, compatibility, and readability





        //What happens if you assign a value to an enum member that exceeds the underlying
        //type's range?
        //the compiler will generate a compile-time error because enum values must fit within the range of
        //the specified underlying type


        //What is the purpose of the virtual keyword when used with properties?
        //allows a property to be overridden in derived classes.


        //Why can’t you override a sealed property or method?
        //because the sealed modifier prevents further overriding in derived classes.It is used to stop the inheritance
        //chain for a specific member, ensuring that no class can change its behavior


        //What is the key difference between static and object members? 
        //Static members belong to the class itself, not to any specific instance.
        //They are shared across all instances of the class and can be accessed without creating an object of the class.



        //Can you overload all operators in C#? Explain why or why not. 
        //Fixed Operators: Some operators are not overloadable in C#, such as is, as, new, sizeof, typeof,
        //and delegate. These operators have fixed behavior that cannot be customized.




        //When should you consider changing the underlying type of an enum? 
        //to optimize memory, match external system requirements, fit a larger or smaller value range,
        //or improve performance


        //Why can't a static class have instance constructors? 
        //A static class can't have instance constructors because it cannot be instantiated.
        //Static classes are meant to provide only static members and are not designed to create objects.
        //The purpose of a static class is to group related methods and properties without needing an instance,
        //so having an instance constructor would contradict this purpose.

        //What is the difference between overriding Equals and == for object comparison in C# struct and 
        //class ?
        // struct: By default, Equals compares the actual values of the fields
        // class: By default, Equals compares object references


        //class: The default == compares object references
        //struct: == not implemented by default but you can override it




        //Can generics be constrained to specific types in C#? Provide an example. 
        //Constraints allow you to specify that the type parameter must inherit from a particular class,
        //implement an interface, or have a default constructor, among other conditions.

        //Example:
        //public class MyClass<T> where T : IComparable
        //{
        //    public T Max(T val1, T val2)
        //    {
        //        if (val1.CompareTo(val2) > 0)
        //            return val1;
        //        return val2;
        //    }
        //}



        //What are the key differences between generic methods and generic classes?
        //Generic methods are specific to the method, while generic classes apply to the entire class.


        //Why might using a generic swap method be preferable to implementing custom methods for 
        //each type?

        //A generic swap method is preferable because it allows code reusability,
        //maintainability, and type safety by working with any type.



        //Why is == not implemented by default for structs?
        //To compare the values of a struct's fields, you must explicitly overload the == operator.

        //What we mean by Generalization concept using Generics ?
        //Generalization using Generics means creating methods, classes, or data structures that can operate
        //on any data type without knowing the specific type in advance.This allows code to be more flexible
        //and reusable by enabling operations on multiple types while maintaining type safety.

        //What we mean by hierarchy design in real business ? 
        //Hierarchy design in real business refers to organizing roles, responsibilities,
        //and workflows in a structured manner, typically in a tree-like format.It defines
        //levels of authority, reporting relationships, and the distribution of tasks,
        //ensuring efficient decision-making, management, and communication within an organization.











}
}