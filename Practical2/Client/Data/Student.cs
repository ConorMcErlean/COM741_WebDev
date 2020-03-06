using System;

namespace Client.Data {

    public class Student
    {
        // implement the Student
        public int Id { get; set;}
        public string Name {get; set;}
        public int Age {get; set;}

        public override string ToString()
        {
            string StudentAsString = $"\tID: {Id} Name: {Name} Age:{Age}\n";
            return StudentAsString;
        }// ToString
        
    }
    
}