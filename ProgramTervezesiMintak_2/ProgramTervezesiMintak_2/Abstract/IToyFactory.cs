using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramTervezesiMintak_2.Abstract
{
    public  interface IToyFactory
    {
        //public int MyProperty { get; set; }
        Toy CreateNew();
    }

    
}
