var http = require('http');
var uc = require('upper-case');

http.createServer(function(req,res)
{/*
    res.writeHead(200,{'Content-Type':'text/html'});
    res.write(uc.upperCase("mail sent"));
    res.end();
*/

var nodemailer = require('nodemailer');

    var transporter = nodemailer.createTransport(
        {
            service: 'gmail',
            auth: {
                user: 'dpka5569@gmail.com',
                pass: 'deepekadp@2002'
            }
        }
    );

    var mailOptions =
    {
        from: 'dpka5569@gmail.com',
        to: 'dpka5569@gmail.com',        //add more comma separated receipients 
        subject: 'Sending Email using Node.js',
        text: 'That was easy!'                   // html: '<h1>Welcome</h1><p>That was easy!</p>'
    };

    transporter.sendMail(mailOptions, function (error, info)
    {
        if (error) {
            console.log(error);
        } else {
            console.log('Email sent: ' + info.response);
        }
    });
}).listen(8080)