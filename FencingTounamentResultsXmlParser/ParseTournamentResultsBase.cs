using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using FencingDataModels;

namespace FencingTournamentResultsXmlParser
{
    public class ParseTournamentResultsBase
    {
        public XElement xdoc;
        public ParseTournamentResultsBase(string filepath)
        {
            if (!System.IO.File.Exists(filepath)) { throw new FileNotFoundException(); }
            else { this.xdoc = XElement.Load(filepath); }
        }

    }
}

