using System;
using CSChatworkAPI;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ChatworkClient(Properties.Settings.Default.APIToken);

            // rooms
            Console.WriteLine("=== Rooms ===");
            foreach (var room in client.GetRooms())
            {
                Console.WriteLine(room);
            }

            // send message
            const int roomId = int.MinValue; // TODO:yourRoomId
            const string body = "Hello Chatwork!";
            var resp = client.SendMessage(roomId, body);
            Console.WriteLine(resp);
            Console.WriteLine("Message: id={0} body={1}", resp.message_id, body);
        }
    }
}
