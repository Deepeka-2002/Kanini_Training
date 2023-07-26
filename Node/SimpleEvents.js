var http = require('http');
//var fileobj = require('fs');
var events = require('events');
//var readstream = fileobj.createReadStream('./Basics.js');

http.createServer(function(req,res)
{
var myEventHandler = function()
{
    console.log('I scored 1000');
}

var eventEmitter = new events.EventEmitter();

eventEmitter.on('RESULTS OUT', myEventHandler);
eventEmitter.emit('RESULTS OUT');

/*
var readstream = fileobj.createReadStream('./Basics.js');

readstream.on('open', function()
{
    console.log('The file is open');
});
*/


}).listen(8080);
