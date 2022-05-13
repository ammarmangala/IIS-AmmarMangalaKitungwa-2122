using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retake
{
    public class Report
    {
        public teacher teacher;
        public @class Class;
        public List<subject> subject;
        public List<student> student;
        
        public Report()
        {
            student = new List<student>();
            subject = new List<subject>();
        }
    }
}
