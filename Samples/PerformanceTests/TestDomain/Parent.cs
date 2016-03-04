﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.TestDomain
{
    public class Parent
    {
        public int Id { get; set; }

        public int Age { get; set; }

        public List<Son> Sons { get; set; } = new List<Son>();
        
        public List<Daughter> Daughters { get; set; } = new List<Daughter>(); 
    }
}
