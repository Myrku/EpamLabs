using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Lab3_Unit
{
    public class Triangle
    {
        public bool Triangle_Check(float a, float b, float c)
        {
            if (a > 0 && b > 0 && c > 0)
            {
                if (a + b <= c || a + c <= b || c + b <= a)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
