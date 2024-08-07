using System.Net.WebSockets;
using System.Text;

namespace Refactoring.Examples;

public class WebSocketExample
{
    public async Task StartWebSocket()
    {
        var client = new ClientWebSocket();
        await client.ConnectAsync(new Uri("ws://localhost:5000/socket"), CancellationToken.None);

        var buffer = new byte[1024];
        while (true)
        {
            var result = await client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, result.Count));
        }
    }
}