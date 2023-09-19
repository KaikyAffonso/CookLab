﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Model
{
    public class Post
    {
        public int Id { get; set; }
        public User User { get; set; }    

        public Recipe Recipe { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } 


    }
}
