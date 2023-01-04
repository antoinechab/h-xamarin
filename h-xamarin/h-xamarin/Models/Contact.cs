using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace h_xamarin.Models
{
    [Table("Contact")]
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Firtsname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Comment { get; set; }

        public string DisplayName { get; set; }
    }
}
