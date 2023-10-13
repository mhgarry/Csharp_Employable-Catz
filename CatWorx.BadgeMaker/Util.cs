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
            //layout variables for background
            int BADGE_WIDTH = 669;
            int BADGE_HEIGHT = 1044;
            //layout variables for photo image
            int PHOTO_LEFT_X = 184;
            int PHOTO_TOP_Y = 215;
            int PHOTO_RIGHT_X = 486;
            int PHOTO_BOTTOM_Y = 517;
            //makes an instance of the http client that is disposed after codeblock runs
            using (HttpClient client = new HttpClient()) //used to make url into a stream of data to be handled by the SKImage library to create an image
            {
                for (int i = 0; i < employees.Count; i++)
                {   // define an SKImage called phto that awaits the stream of data from the HttpClient specified in employees[i].GetPhotoUrl()
                    SKImage photo = SKImage.FromEncodedData(await client.GetStreamAsync(employees[i].GetPhotoUrl()));
                    //specify that this is the background image of our badge
                    string imagePath = Path.Combine("badge.png");
                    if (File.Exists(imagePath))
                    {
                    SKImage background = SKImage.FromEncodedData(File.OpenRead(imagePath));
                    //writing image to bitmap defining the width and height of badge
                    SKBitmap badge = new SKBitmap(BADGE_WIDTH, BADGE_HEIGHT);
                    //turn our badge into a canvas to insert images onto
                    SKCanvas canvas = new SKCanvas(badge);
                    //we're drawing a background image onto our canvas using the SKRect class which creates a rectangle that takes 4 arguments as each side
                    canvas.DrawImage(background, new SKRect(0,0, BADGE_WIDTH, BADGE_HEIGHT));
                    //we're drawing the photo onto our canvas with the skRect method with specific constraints
                    canvas.DrawImage(photo, new SKRect(PHOTO_LEFT_X, PHOTO_TOP_Y, PHOTO_RIGHT_X, PHOTO_BOTTOM_Y));

                    //renders final image
                    SKImage finalImage = SKImage.FromBitmap(badge);
                    SKData data = finalImage.Encode();
                    //saves and writes data to file called employeeBadge.png
                    data.SaveTo(File.OpenWrite("data/employeeBadge.png"));
                    } else 
                    {
                        Console.WriteLine("File not found: badge.png");
                    }
                }
            }
        }
    }

}