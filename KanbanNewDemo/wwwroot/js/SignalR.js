const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log("Error while establishing connection :(");
        setTimeout(() => start(), 5000);
    }
};

connection.onclose(async () => {
    console.log("Connection closed. Restarting...");
    await start();
});

// Start the connection.
start();