using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteOpgave
{
    public class RequestManager
    {
        private IRequest request;

        public string MakeFileRequest(string path)
        {
            request = new FileRequest();
            return request.Request(path);
        }

        public string MakeWebRequest(string path)
        {
            request = new Webrequest();
            return request.Request(path);
        }
    }
}
