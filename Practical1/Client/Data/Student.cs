using System;
namespace Demo.Client.Data
{
    public class Student
    {
        public int Id {get; set;}
        public string Name{get; set;};
        public string Course{get; set;};
        public DateTime Dob{get; set;};
       int age => (DateTime.Now - dob).Days/365;

       public override string ToString(){
           return $"ID:{Id} Name:{Name} Course:{Course} DOB:{Dob.ToShortDateString()} Age:{age}"
       }
    }  
} 