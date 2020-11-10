using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteOpgave
{
    public class FileRequest:IRequest
    {
        public string Request(string path)
        {
            string text = System.IO.File.ReadAllText(path);
            return text;
        }
    }
}
