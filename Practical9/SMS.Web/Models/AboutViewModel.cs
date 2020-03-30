using System;

namespace SMS.Web.Models 
{
    public class AboutViewModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Now => DateTime.Now;
        public DateTime Formed { get; set; } = DateTime.Now;
        public string FormedStr => Formed.ToShortDateString();
        public int Days => (DateTime.Now - Formed).Days;
    }
}