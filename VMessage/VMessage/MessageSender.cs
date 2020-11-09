using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMessage
{
    public class MessageSender
    {
        public void sendMessage(EMessageCarrier type, Message m, bool isHTML)
        {
            //herinde sendes der en email ud til modtageren
            if (type.Equals(EMessageCarrier.Smtp))
            {
                if (isHTML)
                    m.Body = TextManipulator.ConvertBodyToHTML(m.Body);
                //her implementeres alt koden til at sende via Smtp
            }

            if (type.Equals(EMessageCarrier.VMessage))
            {
                if (isHTML)
                    m.Body = TextManipulator.ConvertBodyToHTML(m.Body);
                //her implementeres alt koden til at sende via VMessage
            }
        }

        public void sendMessageToAll(EMessageCarrier type, string[] to, Message m, bool isHTML)
        {
            if (type.Equals(EMessageCarrier.Smtp))
            {
                if (isHTML)
                    m.Body = TextManipulator.ConvertBodyToHTML(m.Body);
                //her implementeres alt koden til at sende via Smtp
            }

            if (type.Equals(EMessageCarrier.VMessage))
            {
                if (isHTML)
                    m.Body = TextManipulator.ConvertBodyToHTML(m.Body);
                //her implementeres alt koden til at sende via VMessage
            }
        }
    }
}
