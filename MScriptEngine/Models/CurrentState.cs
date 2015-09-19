using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MScriptEngine.Models
{
    public class CurrentState
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public string CharName { get; set; }
        public string BGI { get; set; }
        public string LeftChar { get; set; }
        public string CenterChar { get; set; }
        public string RightChar { get; set; }
        public string MainText { get; set; }

    }
}
