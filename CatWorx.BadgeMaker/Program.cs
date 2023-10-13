using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker //our entry point to our file. Like a container to our program
{
    class Program
    {
        static List<Employee> GetEmployees() //we are creating a method as an empty list to store a list of strings classified as employees
        {
            List<Employee> employees = new List<Employee>(); //we are creating an empty list of strings to populate with our argument 'employees'
            while (true) //we are creating a while loop that will continue while the following conditions are true
            {

                Console.WriteLine("Please Enter the first name of an employee: (leave blank to exit): "); //print this prompt to console to show user

                string firstName = Console.ReadLine() ?? ""; //make a variable called input with the type of string that is consumed and stored by the console

                if (firstName == "")
                {
                    break;
                } // the escape clause to the while loop. The loop is true until an empty string is input into the console whcih means the program will keep running until then
                //add a Console.Readline for each value
                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine() ?? ""; //reads and enters last name 
                Console.Write("Enter your ID: "); // get id value
                int id = Int32.Parse(Console.ReadLine() ?? ""); //convert the integer into a string so it can be read by console
                Console.Write("Enter Photo URL:"); //get photo url value
                string photoUrl = Console.ReadLine() ?? "";

                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl); //create an instance of our Employee() class and add employee information using class
                 employees.Add(currentEmployee); //this built in 'Add' method adds the strings we inputted in the console during the while loop to the list of strings
            }
            return employees; //this line returns our newly forumlated list of employees fufilling our agreeent to create a new List with a string of employees
        }
        async static Task Main(string[] args) //our entry point to our program that will consume both of our methods to make a program that takes input from the console and prints it out
        {
            List<Employee> employees = GetEmployees(); //Starts our get employees function method when called as an argument and returns our list of employees
            Util.PrintEmployees(employees); //recieves our list of employees from our GetEmployees() method and prints them to the console
            Util.MakeCSV(employees); //generates our CSV file with our list of employees
            await Util.MakeBadges(employees); //generate badges using MakeBadges method
        }
    }
}