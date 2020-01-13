using System;

namespace TestSolution1.Xml
{
    [Serializable()]
    public class ParamValue
    {
        public string ClientName { get; set; }
        public string ParamName { get; set; }
        public double Value { get; set; }
    }
}