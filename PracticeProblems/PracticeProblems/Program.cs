//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using PracticeProblems;
using System.Net;
using System.Xml.Linq;


    ////Inheritance
    //Programmer p1 = new Programmer();

    //Console.WriteLine("Salary: " + p1.salary);
    //Console.WriteLine("Bonus: " + p1.bonus);

    //Aggregation 
    Address a1 = new Address("G-13, Sec-3", "Noida", "UP");
    Employe e1 = new Employe(1, "Sonoo", a1);
    e1.display();
