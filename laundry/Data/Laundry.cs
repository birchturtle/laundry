using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace laundry.Data
{
    public class Laundry
    {
        [Key]
        public int ID { get; set; }
        public string Owner { get; set; }
        public bool Color { get; set; }
        public bool Attention { get; set; }
        public String Status { get; set; }
        public String TypeOfWash { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdated { get; set; }
        public string Comment { get; set; }
        public Laundry()
        { 
        }

        public static List<SelectListItem> Statuses { get; } = new List<SelectListItem>()
        {
            new SelectListItem { Value = "Washing", Text = "Washing"},
            new SelectListItem { Value = "Done_washing", Text ="Done washing"},
            new SelectListItem { Value = "Drying", Text = "Drying" },
            new SelectListItem { Value = "Done_drying", Text = "Done drying" },
            new SelectListItem { Value = "Done_done", Text = "Done done" },
        };
        public static List<SelectListItem> WashType { get; } = new List<SelectListItem>()
        {
            new SelectListItem { Value = "Regular", Text = "Regular" },
            new SelectListItem { Value = "Sensitive", Text = "Sensitive" },
            new SelectListItem { Value = "Sheets", Text = "Sheets" },
        };
    }

}
