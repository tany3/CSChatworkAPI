/* See the file "LICENSE" for the full license governing this code. */

using System;
using CSChatworkAPI;

namespace Example
{
    class Program
    {
        private static string ApiToken = @"yourAPIToken";

        static void Main()
        {
            var client = new ChatworkClient(ApiToken);

            // Me
            Console.WriteLine("=== Me ===");
            var me = client.GetMe();
            Console.WriteLine(me);

            // rooms
            Console.WriteLine("=== Rooms ===");
            foreach (var room in client.GetRooms())
                Console.WriteLine(room);

            // members
            Console.WriteLine("=== Contacts ===");
            foreach (var contacts in client.GetContacts())
                Console.WriteLine(contacts);

            // send message
            Console.WriteLine("=== Send Message ===");
            var roomId = me.RoomId; // my chat
            var messageBody = "Hello Chatwork!";
            var responseMessage = client.SendMessage(roomId, messageBody);
            Console.WriteLine($"{responseMessage} as \"{messageBody}\"");

            // get message
            Console.WriteLine("=== Get Message ===");
            var message = client.GetMessage(me.RoomId, responseMessage.MessageId);
            Console.WriteLine(message);
        }
    }
}
