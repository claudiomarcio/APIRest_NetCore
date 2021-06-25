﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ED.Domain.Model.Models.Entities
{
    public class Category
    {    
        public int CodCategory { get; set; }
        public string Name { get; set; }
        public List<Author> Authors { get; set; }
    }
}
