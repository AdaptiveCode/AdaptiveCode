﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInterface
{
    public class Duck
    {
        public DuckEnumerator GetEnumerator()
        {
            return new DuckEnumerator();
        }
    }
}
