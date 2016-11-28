using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionAttributeDemo
{
    public class MethodDescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public MethodDescriptionAttribute(string desc)
        {
            Description = desc;
        }
    }
}
