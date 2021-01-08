using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Covid19.Data
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime dob { get; set; }
    }
}
