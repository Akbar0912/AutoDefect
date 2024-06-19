using AutoDefect.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoDefect.View
{
    public class TCPConnection
    {
        private Action<string> updateUiCallback;
        private Action<string> updateUiCallback2;
        private TcpClient client;
        private NetworkStream stream;

        public TCPConnection(Action<string> updateUiCallback, Action<string> updateUiCallback2) // Added updateUiCallback2 as a parameter
        {
            this.updateUiCallback = updateUiCallback;
            this.updateUiCallback2 = updateUiCallback2; // Assigned updateUiCallback2
        }

        public async Task ConnectToServerAsync()
        {
            string serverIp = Settings.Default.ServerIP; // Retrieve IP from user settings
            int port = Settings.Default.Port;

            client = new TcpClient();
            try
            {
                await client.ConnectAsync(serverIp, port);
                //await SendMessageToServerAsync(client, "Hello from client!");

                await HandleServerResponseAsync(client);
            }
            catch (Exception ex)
            {
                //updateUiCallback?.Invoke($"Error connecting to server: {ex.Message}");
            }
        }

        public void CloseConnection()
        {
            if (stream != null)
            {
                stream.Close();
                stream = null;
            }
            if (client != null)
            {
                client.Close();
                client = null;
            }
        }

        private async Task HandleServerResponseAsync(TcpClient client)
        {
            try
            {
                stream = client.GetStream();
                byte[] buffer = new byte[1024];
                string incomingData = "";

                while (true)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        // Connection closed by server
                        break;
                    }

                    incomingData += Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Process all complete messages in incomingData
                    while (incomingData.Contains("<p>"))
                    {
                        int startIdx = incomingData.IndexOf("<p>");
                        int endIdx = incomingData.IndexOf("</p>");

                        if (endIdx != -1) // Ensure end tag exists
                        {
                            string message = incomingData.Substring(startIdx + 3, endIdx - startIdx - 3);
                            incomingData = incomingData.Substring(endIdx + 4);

                            ProcessMessage(message);
                        }
                        else
                        {
                            // Incomplete message, wait for more data
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //updateUiCallback?.Invoke($"Error handling server response: {ex.Message}");
            }
        }

        private void ProcessMessage(string message)
        {
            string cleanedData = Regex.Replace(message, "<.*?>", "");
            splitData1(cleanedData);
            splitData2(cleanedData);
        }

        private void splitData2(string input)
        {
            if (input.Length > 2)
            {
                string data2 = input.Substring(2);
                updateUiCallback2?.Invoke(data2);
            }
        }

        private void splitData1(string input)
        {
            if (input.Length >= 2)
            {
                string data1 = input.Substring(0, 2);
                updateUiCallback?.Invoke(data1);
            }
        }

    }
}
