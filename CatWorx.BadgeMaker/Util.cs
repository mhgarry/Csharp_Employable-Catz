using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using SkiaSharp;

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
        {
            // check if data directory exists
            if (!Directory.Exists("data"))
            {   //create directory if doesn't exist
                Directory.CreateDirectory("data");
                //use streamwriter to make a file called employees.csv
                using (StreamWriter file = new StreamWriter("data/employees.csv"))
                {   //write line "ID,Name, PhtoUrl" to csv file
                    file.WriteLine("ID,Name,PhotoUrl");
                    //loop through employees``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
                    for (int i = 0; i < employees.Count; i++)
                    {
                        //write each employee to csv file
                        string badgeTemplate = "{0},{1},{2}";// make a badge template using the 3 arguemnts representing id, name, and photourl
                        file.WriteLine(String.Format(badgeTemplate, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
                    }
                }
            }
        }
        async public static Task MakeBadges(List<Employee> employees)
        {  
           //makes an instance of the http client that is disposed after codeblock runs
           using(HttpClient client = new HttpClient()) //used to make url into a stream of data to be handled by the SKImage library to create an image
           {
            for (int i = 0; i < employees.Count; i++)
            {
                // convert url into skimage
                //convert badge template into skimage
                // place image on canvas
            }
           }
        //    //make new image 
        //    SKImage newImage = SKImage.FromEncodedData(File.OpenRead("badge.png"));
        //    //Encode image into writable data
        //    SKData data = newImage.Encode();
        //    //save data to a new file called employeeBadge.png
        //    data.SaveTo(File.OpenWrite("data/employeeBadge.png"));
        // }
    }
}

