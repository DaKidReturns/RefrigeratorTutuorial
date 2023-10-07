using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Enumeration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator
{
    internal class XMLLogger
    {
        private string fileName;
        private string logLinesFile;
        public XMLLogger(string fileName) {
            this.fileName = fileName;
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>
<!DOCTYPE log [
<!ENTITY loglines SYSTEM ""loglines.xml"">
]>
<log>
&loglines;
</log>
");

            }
            
            logLinesFile = Path.GetPathRoot(fileName)+"loglines.xml";

        }

        public void LogTemperature(object sender, TemperatureChangedEventArgs e) {
            using (StreamWriter sw = new StreamWriter(logLinesFile, append: true)) {
                sw.WriteLine($"<Temperature>{e.Temperature}</Temperature>");
            
            }
        }
    }
}
