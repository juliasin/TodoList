using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class ToDoTask
    {
        [Required(ErrorMessage = "The ID is required.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; set; }
        public string Text { get; set; }

    }
}