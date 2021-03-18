using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace laundry.Data
{
    public class Laundry
    {
        public int ID;
        public IdentityUser Owner;
        public bool Color;
        public Status Status;
        [DataType(DataType.DateTime)]
        public DateTime Created;
        [DataType(DataType.DateTime)]
        public DateTime LastUpdated;
        public string Comment;
        public Laundry()
        {
        }
    }

}
