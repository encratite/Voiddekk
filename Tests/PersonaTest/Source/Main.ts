/// <reference path="Persona.ts" />
/// <reference path="ResourceLoader.ts" />

function onLogin(assertion: string) {
	alert('onLogin: ' + assertion);
}

function onLogout() {
	alert('onLogout');
}

function onLoginClick() {
	var id = navigator.id;
	id.watch({ onlogin: onLogin, onlogout: onLogout });
	id.request();
}

function onResourcesLoaded(resourceLoader: ResourceLoader) {
	var button = document.createElement('input')
	button.type = 'button';
	button.onclick = onLoginClick;
	button.value = 'Log in';
	document.body.appendChild(button);
}

function main() {
	var resourceLoader = new ResourceLoader();
	resourceLoader.addScript('https://login.persona.org/include.js');
	resourceLoader.run(onResourcesLoaded);
}

main();