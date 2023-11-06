using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ClientTcp : IDisposable
{
    private string hostName;
    private int port;

    private bool serverConnection;
    private bool streamConnection;

    private TcpClient client;
    private NetworkStream stream;

    public bool IsRun { get; set; } = true;
    public bool ServerConnection => serverConnection;
    public bool StreamConnection => streamConnection;

    public event Action<string> OnServerAnswered;


    public ClientTcp(string hostName, int port)
    {
        client = new TcpClient();
        this.hostName = hostName;
        this.port = port;
    }
    private void ParseResponse(ref string stringResponse)
    {
        for (int i = 0; i < stringResponse.Length; i++)
        {
            if (stringResponse[i] == '\n')
            {
                var ans = "";
                for (int j = 0; j <= i; j++)
                {
                    ans += stringResponse[j];
                }
                OnServerAnswered?.Invoke(ans);
                if (i < stringResponse.Length - 1)
                {
                    stringResponse = stringResponse.Substring(i + 1);
                    ParseResponse(ref stringResponse);
                }
                else
                {
                    stringResponse = "";
                }
                break;
            }
        }
    }

    public async Task Observ()
    {
        var stringResponse = "";
        await client.ConnectAsync(hostName, port);
        Debug.Log("<color=yellow>TiktokSDK:</color><color=green> Tiktok server connection successful! </color>");
        serverConnection = true;
        CreateStream();
        while (IsRun)
        {
            if (stream.DataAvailable)
            {
                var response = new byte[65535];
                stream.Read(response);

                stringResponse += Encoding.UTF8.GetString(response).Trim('\0');
                Debug.Log(stringResponse);
                ParseResponse(ref stringResponse);
            }
        }
        stream.Close();
    }

    public async Task SendData(string data)
    {
        CreateStream();
        var requestData = Encoding.UTF8.GetBytes(data);

        await stream.WriteAsync(requestData);
        streamConnection = true;
        Debug.Log("<color=yellow>TiktokSDK:</color><color=green>Tiktok stream connection successful! </color>");
    }

    private void CreateStream()
    {
        if (stream == null)
            stream = client.GetStream();
    }

    public void Dispose()
    {
        stream.Close();
        client.Close();
        stream?.Dispose();
        client?.Dispose();
    }
}