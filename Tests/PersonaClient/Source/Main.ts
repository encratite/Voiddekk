/// <reference path="Persona.ts" />
/// <reference path="ResourceLoader.ts" />

class PersonaTest {
	textArea: HTMLTextAreaElement;
	socket: WebSocket;
	assertion: string;

	constructor() {
		this.textArea = null;
		this.socket = null;
		this.assertion = null;
	}

	run() {
		var resourceLoader = new ResourceLoader();
		resourceLoader.addScript('https://login.persona.org/include.js');
		resourceLoader.run(this.onResourcesLoaded.bind(this));
	}

	private createDocument() {
		var paragraph1 = document.createElement('p');
		var paragraph2 = document.createElement('p');

		var textArea = document.createElement('textarea');
		textArea.style.width = '50em';
		textArea.style.height = '20em';
		this.textArea = textArea;

		var button = document.createElement('input')
		button.type = 'button';
		button.onclick = this.onLoginClick.bind(this);
		button.value = 'Log in';

		paragraph1.appendChild(textArea);
		paragraph2.appendChild(button);

		document.body.appendChild(paragraph1);
		document.body.appendChild(paragraph2);
	}

	private write(line: string) {
		this.textArea.value += line + '\n';
	}

	private onResourcesLoaded() {
		this.createDocument();
	}

	private onLoginClick() {
		this.write('Logging in');
		var id = navigator.id;
		id.watch({onlogin: this.onLogin.bind(this), onlogout: this.onLogout.bind(this)});
		id.request();
	}

	private onLogin(assertion: string) {
		this.assertion = assertion;
		var url = 'ws://persona:82/';
		this.write('Connecting to ' + url);
		var socket = new WebSocket(url);
		this.socket = socket;
		socket.onopen = this.onSocketOpen.bind(this);
		socket.onclose = this.onSocketClose.bind(this);
		socket.onmessage = this.onSocketMessage.bind(this);
		socket.onerror = this.onSocketError.bind(this);
	}

	private onLogout() {
		this.write('Logged out');
	}

	private onSocketOpen() {
		this.write('Connected, sending assertion');
		this.socket.send(this.assertion);
	}

	private onSocketClose() {
		this.write('Disconnected');
	}

	private onSocketMessage(event: any) {
		this.write('Received: ' + event.data);
	}

	private onSocketError(event: ErrorEvent) {
		this.write('An error occurred');
	}
}

function main() {
	var test = new PersonaTest();
	test.run();
}

main();