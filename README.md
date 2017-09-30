CSChatworkAPI
=============

Chatwork API library written in C#

# how to use
see and build Example project and run! :fire:

## Example
### get my info
```
var client = new ChatworkClient(ApiToken);

var me = client.GetMe();
Console.WriteLine(me);
```

### get rooms
```
foreach (var room in client.GetRooms())
    Console.WriteLine(room);
```

### get my contacts
```
foreach (var contacts in client.GetContacts())
    Console.WriteLine(contacts);
```

### send message
```
var roomId = me.RoomId; // my chat
var messageBody = "Hello Chatwork!";
var responseMessage = client.SendMessage(roomId, messageBody);
Console.WriteLine($"{responseMessage} as \"{messageBody}\"");
```

### get message
```
var message = client.GetMessage(me.RoomId, responseMessage.MessageId);
Console.WriteLine(message);
```
