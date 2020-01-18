using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyDll2
{
    public class PiRCommon
    {
        String personName = "World";

        public PiRCommon()
        {
        }

        public PiRCommon(String personName)
        {
            this.personName = personName;
        }

        public String SayHello()
        {
            return "Hello " + personName + " !";
        }

        public double PiR_2()
        {
            return Math.Pow(Math.PI, 2);
        }

        public String SayBye()
        {
            return "Bye " + personName + " !";
        }
    }
}
