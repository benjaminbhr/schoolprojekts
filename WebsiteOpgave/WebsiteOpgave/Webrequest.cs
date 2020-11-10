using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteOpgave
{
    public class Webrequest:IRequest
    {
        public string Request(string path)
        {
            WebRequest request = WebRequest.Create(path);
            WebResponse response = request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                response.Close();
                // Display the content.
                return responseFromServer;
            }
        }
    }
}
