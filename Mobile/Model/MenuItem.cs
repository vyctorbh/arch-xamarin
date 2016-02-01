using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Model
{
    public class MenuItem
    {
        public string Title { get; set; }

        public string IconSource { get; set; }

        public string MainType { get; set; }

        public Type TargetType { get; set; }
    }
}
