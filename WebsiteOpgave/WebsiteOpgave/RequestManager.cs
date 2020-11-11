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

        public string MakeRequest(string path)
        {
            return request.Request(path);
        }

        public RequestManager(IRequest r)
        {
            this.request = r;
        }
    }
}
