using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DummyProject.Inaam
{
    public class Validations
    {
        public static string Required()
        {
            return "required";
        }

        public static string Email()
        {
            return "email";
        }

        public static string Min(int min)
        {
            return "min:" + min;
        }

        public static string Max(int max)
        {
            return "max:" + max;
        }

        public static string MinLength(int min)
        {
            return "minLength:" + min;
        }

        public static string MaxLength(int max)
        {
            return "maxLength:" + max;
        }
    }
}
