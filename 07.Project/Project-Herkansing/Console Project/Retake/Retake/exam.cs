using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retake
{
    public class exam
    {
        public int degree;
        public List<subject> subjects;
        public exam()
        {
            subjects = new List<subject>();
        }
    }
}
