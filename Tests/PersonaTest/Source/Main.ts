function error(message: string) {
    alert(message);
}

class ResourceLoader {
    private remainingResources: string[];
    private onCompletion;

    constructor(scripts: string[], onCompletion) {
        this.remainingResources = scripts;
        this.onCompletion = onCompletion;
        scripts.forEach(function (script: string) {
            this.loadScript(script);
        });
    }

    loadScript(url: string) {
        var script = document.createElement('script');
        script.onerror = function () {
            error('Unable to load script "' + url + '".');
        }
        script.onload = function () {
            this.onScriptLoad(url);
        };
        script.src = url;
        document.body.appendChild(script);
    }

    onScriptLoad(url: string) {
        var index = this.remainingResources.indexOf(url);
        if (index == -1) {
            error('Unable to find script "' + url + '" in the remaining resources');
            return;
        }
        this.remainingResources = this.remainingResources.splice(index, 1);
        if (this.remainingResources.length == 0)
            this.onCompletion();
    }
}