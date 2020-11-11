using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteOpgave
{
    public class RequestFactory
    {
        public IRequest CreateRequest(ERequestTypes type)
        {
            switch (type)
            {
                case ERequestTypes.FileRequest:
                    return new FileRequest();
                case ERequestTypes.WebRequest:
                    return new Webrequest();
            }

            return null;
        }
    }
}
