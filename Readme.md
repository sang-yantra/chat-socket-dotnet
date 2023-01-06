### A console application for chat server

This is a console app that implements a chat server which emits random binary data every 5 sec
response in json
```
{ username: "", message: "" }
```

## Clone, build and run the application

## How to connect this web socket

1. Open a blank chrome tab
2. Open conole tab
	```
	let chatWss = new WebSocket("ws://localhost:8080/Chat");
	chatWss.onmessage = async (e) => { 
		const text = await e.data.text();
		console.log(text)
	}
	```
3. Close the connection before closing the tab
	```
	chatWss.close();
	```
	
