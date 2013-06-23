function write(line: string) {
    var output = document.getElementById('output');
    output.innerHTML += line + "\n";
}

export function runTest() {
    var url = 'ws://127.0.0.1:81/';
    write('Connecting');
    var socket = new WebSocket(url);
    socket.onopen = function () {
        write('Connected');
    };
    socket.onmessage = function (event) {
        write('Received: ' + event.data);
    };
    socket.onclose = function () {
        write('Disconnected');
    };
}