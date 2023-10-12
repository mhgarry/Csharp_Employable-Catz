using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker //our entry point to our file. Like a container to our program
{
    class Program
    {
        static List<string> GetEmployees() //we are creating a method as an empty list to store a list of strings classified as employees
        {
            List<string> employees = new List<string>(); //we are creating an empty list of strings to populate with our argument 'employees'
            while (true) //we are creating a while loop that will continue while the following conditions are true
            {

                Console.WriteLine("Please Enter the name of an employee: (leave blank to exit): "); //print this prompt to console to show user

                string input = Console.ReadLine() ?? ""; //make a variable called input with the type of string that is consumed and stored by the console

                if (input == "")
                {
                    break;
                } // the escape clause to the while loop. The loop is true until an empty string is input into the console whcih means the program will keep running until then
                Employee employee = new Employee(); //create an instance of our Employee() class
                employee.FirstName = input; 
                employees.Add(input); //this built in 'Add' method adds the strings we inputted in the console during the while loop to the list of strings
            }
            return employees; //this line returns our newly forumlated list of employees fufilling our agreeent to create a new List with a string of employees
        }
        static void PrintEmployees(List<string> employees) //we are creating a method to print our list of employees to the conosle. Threfore we are inputting our List generated from our method GetEmployees()
        {
            for (int i = 0; i < employees.Count; i++) //iterate through the list of employees
            {
                Console.WriteLine(employees[i]); //write each indexed employee individually to the console
            }
        }
        static void Main(string[] args) //our entry point to our program that will consume both of our methods to make a program that takes input from the console and prints it out
        {
            List<string> employees = GetEmployees(); //Starts our get employees function method when called as an argument and returns our list of employees
            PrintEmployees(employees); //recieves our list of employees from our GetEmployees() method and prints them to the console
        }
    }
}