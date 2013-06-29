/// <reference path="Persona.ts" />
/// <reference path="ResourceLoader.ts" />

class PersonaTest {
	textArea: HTMLTextAreaElement;
	socket: WebSocket;

	constructor() {
		this.textArea = null;
		this.socket = null;
	}

	run() {
		var resourceLoader = new ResourceLoader();
		resourceLoader.addScript('https://login.persona.org/include.js');
		resourceLoader.run(this.onResourcesLoaded);
	}

	private draw() {
		var paragraph1 = document.createElement('p');
		var paragraph2 = document.createElement('p');

		var textArea = document.createElement('textarea');
		this.textArea = textArea;

		var button = document.createElement('input')
		button.type = 'button';
		button.onclick = this.onLoginClick;
		button.value = 'Log in';

		paragraph1.appendChild(textArea);
		paragraph2.appendChild(button);

		document.body.appendChild(paragraph1);
		document.body.appendChild(paragraph2);
	}

	private write(line: string) {
		this.textArea.value += line + '\n';
	}

	private onLogin(assertion: string) {
		var url = 'ws://persona:82/';
		this.write('Connecting to ' + url);
		var socket = new WebSocket(url);
		this.socket = socket;
		socket.onopen = this.onSocketOpen;
		socket.onmessage = this.onSocketMessage;
		socket.onclose = this.onSocketClose;
		socket.send(assertion);
	}

	private onLogout() {
		this.write('Logged out');
	}

	private onLoginClick() {
		this.write('Logging in');
		var id = navigator.id;
		id.watch({ onlogin: this.onLogin, onlogout: this.onLogout });
		id.request();
	}

	private onResourcesLoaded() {
		this.draw();
	}

	private onSocketOpen() {
		this.write('Connected');
	}

	private onSocketMessage(event: any) {
		this.write('Received: ' + event.data);
	}

	private onSocketClose() {
		this.write('Disconnected');
	}
}

function main() {
	var test = new PersonaTest();
	test.run();
}

main();