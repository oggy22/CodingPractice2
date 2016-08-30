using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    public abstract class ProblemBase
    {
        public abstract string Description { get; }

        public abstract Type Input { get; }

        public abstract Type Output { get; }
    }
}
