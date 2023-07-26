var http = require('http');
var today = require('./mydatetime');

http.createServer(function (req,res)
{
   
   res.writeHead(200, {'Content-Type':'text/html'});
   res.write(today.mydatetime());
   res.end('Done');
   
}

).listen(8080);
