using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorORM
{
    public class Vocabulario
    {
        public string termo { get; set; }

        public List<Vocabulario> vocabulario { get; set; } = new List<Vocabulario>();


    }
}
