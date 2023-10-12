namespace CatWorx.BadgeMaker //namespace our container for our program
{
    class Employee //this class stores employee info
    {
        public string FirstName; //stores employees first name to be publically used throughout program
        public string LastName; //stores employees last name to be publically used throughout program
        public int Id; //assigns an id to each employee
        public string PhotoUrl; //links a url of a photo to each employee
        public Employee(string firstName, string lastName, int id, string photoUrl)
        { //our class constructor for our Employee class
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            PhotoUrl = photoUrl;
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
        public int GetId() 
        {
            return Id;
        }
        public string GetPhotoUrl() {
            return PhotoUrl;
        }
    }
}