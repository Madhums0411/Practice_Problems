﻿//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using PracticeProblems;
using System.Net;
using System.Xml.Linq;


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
Student student = new Student();
// Setting values to the properties  
student.ID = "101";
student.Name = "Mohan Ram";
student.Email = "mohan@example.com";
// getting values  
Console.WriteLine("ID = " + student.ID);
Console.WriteLine("Name = " + student.Name);
Console.WriteLine("Email = " + student.Email);