/* See the file "LICENSE" for the full license governing this code. */

using System;
using CSChatworkAPI;

namespace Example
{
    class Program
    {
        private const string ApiToken = @"yourAPIToken";

        static void Main(string[] args)
        {
            var client = new ChatworkClient(ApiToken);

            // Me
            Console.WriteLine("=== Me ===");
            Console.WriteLine(client.GetMe());

            // rooms
            Console.WriteLine("=== Rooms ===");
            foreach (var room in client.GetRooms())
            {
                Console.WriteLine(room);
            }

            // members
            Console.WriteLine("=== Contacts ===");
            foreach (var contacts in client.GetContacts())
            {
                Console.WriteLine(contacts);
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
