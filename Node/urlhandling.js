var http = require('http');
var url = require('url');

http.createServer( function (req, res)
    {
        //res.writeHead(200,{'Content-Type': "text/html"});
        //res.write(req.url);

        //var querystr = url.parse(req.url,true).query;
        //var values = querystr.UN +querystr.PWD
        //res.write(values);

        var adr='http://localhost:9000/default.htm?year=2023&month=May';
        var querystr = url.parse(adr, true);

        console.log(querystr.host)
        console.log(querystr.pathname);
        console.log(querystr.search);

        var querystrdata = querystr.query;
        console.log(querystrdata);
        console.log(querystrdata.month);

        res.end();
    }
).listen(9000);