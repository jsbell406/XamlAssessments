using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Mobi_App_Project.Models
{
    public class TodoItem 
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }

        public TodoItem(int iD, string name, string notes, bool done)
        {
            ID = iD;
            Name = name;
            Notes = notes;
            Done = done;
        }
        public TodoItem()
        {
        }
    }

}

//CREATE TABLE Todo(
//    ID INTEGER PRIMARY KEY NOT NULL,
//    Name VARCHAR (30) NOT NULL,
//    Notes VARCHAR(300) NOT NULL,
//   Done INTEGER NOT NULL
//);