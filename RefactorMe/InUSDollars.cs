using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactorMe
{
    public class InUSDollars : IRate
    {
        public double Rate() => 0.76;
    }
}