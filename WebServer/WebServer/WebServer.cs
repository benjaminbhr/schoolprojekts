using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebServer
{
    public class WebServer
    {
        public bool isrunning;
        private int timeout = 8;
        private Encoding charEncoder = Encoding.UTF8;
        private Socket serverSocket;
        private string contentPath;

        private Dictionary<string, string> extensions = new Dictionary<string, string>()
        {
            {"htm", "text/html"},
            {"html", "text/html"},
            {"xml", "text/xml"},
            {"txt", "text/plain"},
            {"css", "text/css"},
            {"png", "image/png"},
            {"gif", "image/gif"},
            {"jpg", "image/jpg"},
            {"jpeg", "image/jpeg"},
            {"zip", "application/zip"}
        };

        public bool start(IPAddress ipAddress, int port, int maxNOfCon, string contentPath)
        {
            if (isrunning) return false; // If it is already running, exit.

            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                    ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(ipAddress, port));
                serverSocket.Listen(maxNOfCon);
                serverSocket.ReceiveTimeout = timeout;
                serverSocket.SendTimeout = timeout;
                isrunning = true;
                this.contentPath = contentPath;
            }
            catch { return false; }

            // Our thread that will listen connection requests
            // and create new threads to handle them.
            Thread requestListenerT = new Thread(() =>
            {
                while (isrunning)
                {
                    Socket clientSocket;
                    try
                    {
                        clientSocket = serverSocket.Accept();
                        // Create new thread to handle the request and continue to listen the socket.
                        Thread requestHandler = new Thread(() =>
                        {
                            clientSocket.ReceiveTimeout = timeout;
                            clientSocket.SendTimeout = timeout;
                            try
                            {
                                HandleTheRequest(clientSocket);
                            }
                            catch
                            {
                                try
                                {
                                    clientSocket.Close();
                                }
                                catch(Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        });
                        requestHandler.Start();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            });
            requestListenerT.Start();

            return true;
        }

        public void stop()
        {
            if (isrunning)
            {
                isrunning = false;
                try { serverSocket.Close(); }
                catch { }
                serverSocket = null;
            }
        }

        private void HandleTheRequest(Socket clientSocket)
        {
            byte[] buffer = new byte[10240];
            int receivedBCount = clientSocket.Receive(buffer); // Receive request
            string strReceived = charEncoder.GetString(buffer, 0, receivedBCount);

            string httpMethod = strReceived.Substring(0, strReceived.IndexOf(" "));

            int start = strReceived.IndexOf(httpMethod) + httpMethod.Length + 1;
            int length = strReceived.LastIndexOf("HTTP") - start - 1;

            string requestedUrl = strReceived.Substring(start, length);

            string requestedFile;
            //Finds out if GET or POST request, and runs "NotImplemented" method if not.
            if (httpMethod.Equals("GET") || httpMethod.Equals("POST"))
                requestedFile = requestedUrl.Split('?')[0];
            else
            {
                NotImplemented(clientSocket);
                return;
            }

            //Replaces "/" in path to \ to support directory pathing.
            requestedFile = requestedFile.Replace("/", @"\").Replace("\\..", "");
            start = requestedFile.LastIndexOf('.') + 1;
            //LastIndexOf returns -1 if not found, so if start is higher than 0, it means there was specified a file.
            if (start > 0)
            {
                length = requestedFile.Length - start;
                string extension = requestedFile.Substring(start, length);
                //checks if we support the current extension, runs NotFound method if not.
                if (extensions.ContainsKey(extension))
                    //Checks if file exists
                    if (File.Exists(contentPath + requestedFile))
                        SendOkResponse(clientSocket,
                          File.ReadAllBytes(contentPath + requestedFile), extensions[extension]);
                    else
                        NotFound(clientSocket);
            }
            else
            {
                if (requestedFile.Substring(length - 1, 1) != @"\")
                    requestedFile += @"\";
                if (File.Exists(contentPath + requestedFile + "index.htm"))
                    SendOkResponse(clientSocket,
                      File.ReadAllBytes(contentPath + requestedFile + "\\index.htm"), "text/html");
                else if (File.Exists(contentPath + requestedFile + "index.html"))
                    SendOkResponse(clientSocket,
                      File.ReadAllBytes(contentPath + requestedFile + "\\index.html"), "text/html");
                else
                    NotFound(clientSocket);
            }
        }

        private void NotImplemented(Socket clientSocket)
        {

            SendResponse(clientSocket, "<html><head><metahttp - equiv =\"Content-Type\" content=\"text/html; charset = utf - 8\"></ head >< body >< h2 > Atasoy Simple WebServer </ h2 >< div > 501 - Method NotImplemented </ div ></ body ></ html > ", "501 Not Implemented", "text/html");
        }

        private void NotFound(Socket clientSocket)
        {

            SendResponse(clientSocket, "<html><head><meta http - equiv =\"Content-Type\" content=\"text/html; charset = utf - 8\"></head><body><h2>Atasoy Simple Web Server </ h2 >< div > 404 - Not Found </ div ></ body ></ html > ", "404 Not Found", "text/html");
        }

        private void SendOkResponse(Socket clientSocket, byte[] bContent, string contentType)
        {
            SendResponse(clientSocket, bContent, "200 OK", contentType);
        }

        // For strings
        private void SendResponse(Socket clientSocket, string strContent, string responseCode,
                                  string contentType)
        {
            byte[] bContent = charEncoder.GetBytes(strContent);
            SendResponse(clientSocket, bContent, responseCode, contentType);
        }

        // For byte arrays
        private void SendResponse(Socket clientSocket, byte[] bContent, string responseCode,
                                  string contentType)
        {
            try
            {
                byte[] bHeader = charEncoder.GetBytes(
                    "HTTP/1.1 " + responseCode + "\r\n"
                    + "Server: Atasoy Simple Web Server\r\n"
                    + "Content-Length: " + bContent.Length.ToString() + "\r\n"
                    + "Connection: close\r\n"
                    + "Content-Type: " + contentType + "\r\n\r\n");
                clientSocket.Send(bHeader);
                clientSocket.Send(bContent);
                clientSocket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
