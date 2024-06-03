using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class body
    {
        public string to { get; set; }
        public ML.notification notification { get; set; }
        public bool content_available { get; set; }
        public string priority { get; set; }
        public ML.data data { get; set; }
    }
}
