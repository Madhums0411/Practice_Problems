using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    class GenericClass<T>
    {
        public GenericClass(T msg)
        {
            Console.WriteLine(msg);
        }
    }

    class GenericClass
    {
        public void Show<T>(T msg)
        {
            Console.WriteLine(msg);
        }
    }
}
