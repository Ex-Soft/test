// https://docs.microsoft.com/en-us/aspnet/core/signalr/javascript-client?view=aspnetcore-5.0

console.log("SignalR.VERSION: %s", signalR.VERSION);

const connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:49987/chatHub")
    .configureLogging(signalR.LogLevel.Information)
    .withAutomaticReconnect()
    .build();

async function start() {
	try {
		await connection.start();
        console.assert(connection.state === signalR.HubConnectionState.Connected);
		console.log("SignalR Connected.");
		document.getElementById("btnStart").disabled = true;
        document.getElementById("btnSend").disabled = false;
	} catch (err) {
        console.assert(connection.state === signalR.HubConnectionState.Disconnected);
		console.log(err);
		setTimeout(start, 5000);
	}
};

/*connection.onclose(async () => {
    await start();
});*/

connection.onclose(error => {
    console.assert(connection.state === signalR.HubConnectionState.Disconnected);
    const li = document.createElement("li");
    li.textContent = `Connection closed due to error "${error}". Try refreshing this page to restart the connection.`;
    document.getElementById("listMessages").appendChild(li);

    start();
});

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("listMessages").appendChild(li);
    li.textContent = `${user} says ${message}`;
});

function send() {
	let user = document.getElementById("textUser").value;
	let message = document.getElementById("textMessage").value;
	connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
};

connection.onreconnecting(error => {
    console.assert(connection.state === signalR.HubConnectionState.Reconnecting);
    const li = document.createElement("li");
    li.textContent = `Connection lost due to error "${error}". Reconnecting.`;
    document.getElementById("listMessages").appendChild(li);
});

connection.onreconnected(connectionId => {
    console.assert(connection.state === signalR.HubConnectionState.Connected);
    const li = document.createElement("li");
    li.textContent = `Connection reestablished. Connected with connectionId "${connectionId}".`;
    document.getElementById("listMessages").appendChild(li);
});
