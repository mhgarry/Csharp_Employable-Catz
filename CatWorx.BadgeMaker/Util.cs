using System;
using System.IO;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker //namespace
{
    class Util //class for utility methods/functions
    {
        public static void PrintEmployees(List<Employee> employees) //declared method as static which means it belongs to util class 
        {
             for (int i = 0; i < employees.Count; i++) //iterate through the list of employees
            {
                string employeeTemplate = "{0, -10}\t{1, -20}\t{2}"; //formatting our templated string
                Console.WriteLine(String.Format(employeeTemplate, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl())); //write each indexed employee and their information individually to the console 
            }
        }
        public static void MakeCSV(List<Employee> employees)
        {   // check if data directory exists
            if ( !Directory.Exists("data"))
            {   //if doesn't exist create directory
                Directory.CreateDirectory("data");
                //use StreamWRiter to write a new .csv file of employees
                using (StreamWriter file = new StreamWriter("data/employees.csv"))
                {   //write "ID, Nmae, and PhotoUrl" into file
                    file.WriteLine("ID,Name,PhotoUrl");

                    //loop over employees
                    for (int i = 0; i < employees.Count; i++)
                    {
                        //write each employee to the csv file 
                        string employeeTemplate = "{0},{1},{2}";
                        file.WriteLine(String.Format(employeeTemplate, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));                        
                    }
                }
            }
        }
        //Loop over the given employeees 
        //Write each employee's info as a comma-seperated string using csv file

    }
}