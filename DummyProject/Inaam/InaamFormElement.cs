using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DummyProject.Inaam
{
    public class InaamFormElement
    {
        public string ElementType { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string[] Validations { get; set; }
        public string Placeholder { get; internal set; }
        public string ModelPropertyName { get; internal set; }
    }
}
