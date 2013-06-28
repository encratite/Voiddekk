/// <reference path="Utility.ts" />

class ResourceLoader {
	private scriptsRemaining: string[];
	private imagesRemaining: string[];
	private onCompletion: () => void;

	constructor(scripts: string[], images: string[], onCompletion: () => void ) {
		this.scriptsRemaining = scripts;
		this.imagesRemaining = images;
		this.onCompletion = onCompletion;
	}

	public run() {
		this.scriptsRemaining.forEach((script: string) => this.loadScript(script));
	}

	private loadScript(url: string) {
		var script = document.createElement('script');
		script.onerror = () => error('Unable to load script "' + url + '".');
		script.onload = () => this.onScriptLoad(url);
		script.src = url;
		document.body.appendChild(script);
	}

	private onScriptLoad(url: string) {
		var index = this.scriptsRemaining.indexOf(url);
		if (index == -1) {
			error('Unable to find script "' + url + '" in the remaining resources');
			return;
		}
		this.scriptsRemaining.splice(index, 1);
		if (this.doneLoading())
			this.onCompletion();
	}

	private doneLoading(): bool {
		return this.scriptsRemaining.length == 0 && this.imagesRemaining.length == 0;
	}
}