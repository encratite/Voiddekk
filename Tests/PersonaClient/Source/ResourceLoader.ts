/// <reference path="Utility.ts" />

class ResourceLoader {
	private scriptsRemaining: string[];
	private imagesRemaining: string[];
	private images: HTMLImageElement[];
	private onCompletion: () => void;

	constructor() {
		this.scriptsRemaining = [];
		this.imagesRemaining = [];
	}

	addScript(source: string) {
		this.scriptsRemaining.push(source);
	}

	addImage(source: string) {
		this.imagesRemaining.push(source);
	}

	getImage(source: string): HTMLImageElement {
		for (var i = 0; i < this.images.length; i++) {
			var image = this.images[i];
			if (image.src == source)
				return image;
		}
		throw 'Unable to find image resource for source "' + source + '"';
	}

	run(onCompletion: () => void) {
		this.onCompletion = onCompletion;
		this.scriptsRemaining.forEach((script: string) => this.loadScript(script));
	}

	private loadScript(source: string) {
		var script = document.createElement('script');
		script.onerror = () => error('Unable to load script "' + source + '".');
		script.onload = () => this.onLoad(source, this.scriptsRemaining);
		script.src = source;
		document.body.appendChild(script);
	}

	private loadImage(source: string) {
		var image = new Image();
		image.onerror = () => error('Unable to load image "' + source + '".');
		image.onload = () => this.onLoad(source, this.imagesRemaining);
		image.src = source;
		this.images.push(image);
	}

	private onLoad(source: string, container: string[]) {
		var index = container.indexOf(source);
		if (index == -1) {
			error('Unable to find "' + source + '" in the remaining resources');
			return;
		}
		container.splice(index, 1);
		this.completionCheck();
	}

	private completionCheck() {
		if (this.scriptsRemaining.length == 0 && this.imagesRemaining.length == 0)
			this.onCompletion();
	}
}