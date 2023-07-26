var http = require('http');
var fileobj = require('fs');

http.createServer(function(req,res)
{

        fileobj.readFile('sample.txt',
             funcion(err, data),
        {
            
            //res.writeHead(200,{'Content-Type':'text/html'});
            //res.write(data);
            //return res.end();
        });
        
    }
).listen(8080);