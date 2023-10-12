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
        //create a method to make a csv file
        //call the method in the Program.cs file and pass the employee info list into it
        //create a data folder
        //create a file in the data folder to hold the csv file called employees.csv
        //Loop over the given employeees 
        //Write each employee's info as a comma-seperated string using csv file

    }
}