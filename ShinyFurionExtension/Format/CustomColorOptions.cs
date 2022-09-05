using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinyFurionExtension.Format
{
    public class CustomColorOptions : SimpleConsoleFormatterOptions
    {
        public string? CustomPrefix { get; set; }
    }
}
