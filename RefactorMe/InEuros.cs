using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactorMe
{
    public class InEuros : IRate
    {
        public double Rate() => 0.67;
    }
}