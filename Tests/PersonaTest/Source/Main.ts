/// <reference path="ResourceLoader.ts" />

function onResourcesLoaded() {
	alert('Loaded');
}

function main() {
	var resourceLoader = new ResourceLoader(['https://login.persona.org/include.js'], [], onResourcesLoaded);
	resourceLoader.run();
}

main();