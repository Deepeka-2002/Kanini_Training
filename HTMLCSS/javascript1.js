function f1(){
    document.getElementById("demo").innerHTML="Welcome Deepekaaa!";
    var x=5, y=19;
    document.getElementById("p2").innerHTML=x+y;
    {
        let a=5; b=1;z=null;
        document.getElementById("p3").innerHTML=a+b;

        let x=5; y="hello";
        document.getElementById("p4").innerHTML=x+ " " +y;
        
        var  c=67, d=3;
        document.getElementById("p5").innerHTML=c*d;

    }
}

function f2(x,y){
    document.getElementById("para1").innerHTML=x+z;
    {
        document.getElementById("para2").innerHTML=x+y;

    }
}

function f3(){
    student= {rno:100, name:'Deepeka', address:'15, Arunagiri nather Street'}
    document.getElementById("para3").innerHTML= student.rno + ' '+student.name+' '+ student.address;
}
