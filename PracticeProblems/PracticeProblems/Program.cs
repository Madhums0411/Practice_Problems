//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using PracticeProblems;
using System.Net;
using System.Xml.Linq;
using System.Collections.Generic;


//Inheritance
//Programmer p1 = new Programmer();

//Console.WriteLine("Salary: " + p1.salary);
//Console.WriteLine("Bonus: " + p1.bonus);

//Aggregation 
//Address a1 = new Address("Ramagiri", "Chitradurga", "Karnataka");
//Employe e1 = new Employe(1, "Madhu", a1);
//e1.display();

//Polymorphism 
//Animal d = new Dog();
//Console.WriteLine(d.color);

//Shape s;
//s = new Shape();
//s.draw();
//s = new Rectangle();
//s.draw();
//s = new Circle();
//s.draw();


////abstract
//Shape s;
//s = new Rectangle();
//s.draw();
//s = new Circle();
//s.draw();

//Encapsulation
//Student student = new Student();
//// Setting values to the properties  
//student.ID = "101";
//student.Name = "Mohan Ram";
//student.Email = "mohan@example.com";
//// getting values  
//Console.WriteLine("ID = " + student.ID);
//Console.WriteLine("Name = " + student.Name);
//Console.WriteLine("Email = " + student.Email);

//List
//{
//    // Create a list of strings  
//    var names = new List<string>();
//    names.Add("Madhu");
//    names.Add("Puni");
//    names.Add("Chethu");
//    names.Add("Abhi");

//    // Iterate list element using foreach loop  
//    foreach (var name in names)
//    {
//        Console.WriteLine(name);
//    }
//}


//Stack
//{
//    Stack<string> names = new Stack<string>();
//    names.Push("Madhu");
//    names.Push("Puni");
//    names.Push("Abhi");
//    names.Push("Chethan");
//    names.Push("Akash");

//    foreach (string name in names)
//    {
//        Console.WriteLine(name);
//    }

//    Console.WriteLine("Peek element: " + names.Peek());
//    Console.WriteLine("Pop: " + names.Pop());
//    Console.WriteLine("After Pop, Peek element: " + names.Peek());

//}

//Queue
//{
//    Queue<string> names = new Queue<string>();
//    names.Enqueue("Madhu");
//    names.Enqueue("Puni");
//    names.Enqueue("Abhi");
//    names.Enqueue("Chethan");
//    names.Enqueue("Akash");    

//    foreach (string name in names)
//    {
//        Console.WriteLine(name);
//    }

//    Console.WriteLine("Peek element: " + names.Peek());
//    Console.WriteLine("Dequeue: " + names.Dequeue());
//    Console.WriteLine("After Dequeue, Peek element: " + names.Peek());
//}

//Linked list
//{
//    // Create a list of strings  
//    var names = new LinkedList<string>();
//    names.AddLast("Madhu");
//    names.AddLast("Abhi");
//    names.AddLast("Puni");
//    names.AddLast("Akash");
//    names.AddFirst("Chethu");//added to first index  

//    // Iterate list element using foreach loop  
//    foreach (var name in names)
//    {
//        Console.WriteLine(name);
//    }
//}

//Generics
{
    GenericClass<string> Name = new GenericClass<string>("Madhu");
    GenericClass<int> number = new GenericClass<int>(411);
    GenericClass<char> character = new GenericClass<char>('R');
}
{
    GenericClass clas = new GenericClass();
    clas.Show("Madhu");
    clas.Show(411);
    clas.Show('R');
}