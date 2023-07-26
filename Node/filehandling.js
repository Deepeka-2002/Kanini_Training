var http = require('http');

var fileobj = require('fs');

http.createServer(function(req,res)
    {
       //fileobj.open('sample.txt','w',
       // function(err,file)
       // {
       //     if(err) throw err;
        //    console.log('Saved!');
        // }
       // );


      // fileobj.writeFile('sample.txt', 'Hello!!', 
       //function(err)
       //{
       //     if(err) throw err;
        //    console.log('Saved!');
      // }
       //);


     // fileobj.readFile('sample.txt', funcion(err,data)
     //  {

     //      res.writeHead(200,{'Content-Type':'text/html'});
     //      res.write(data);
      //    return res.end();
      // });
        

     //  fileobj.appendFile('sample.txt', 'Its Deepeka here', 
      // function(err)
      // {
       //    if(err) throw err;
       //    console.log('Saved!');
      // }
      // );

       //fileobj.rename('sample.txt', 'new sample.txt', 
       //function(err)
       //{
       //     if(err) throw err;
       //    console.log('File renamed!');
       //}
       //);

       //fileobj.unlink('new sample.txt', 
       //function(err)
       //{
       //     if(err) throw err;
            console.log('File deleted!');
      // }
      // );

      fileobj.readFile('file.html', function(err,data) 
      
       {
            res.writeHead(200,{'Content-Type':'text/html'});
            res.write(data);
            return res.end();
            
       }
       );
    }
).listen(8080);