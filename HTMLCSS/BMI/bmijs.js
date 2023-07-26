function calculate(){
    var bmi;
    var height = parseInt(document.getElementById("height").value);
    var weight = parseInt(document.getElementById("weight").value);
    bmi = (weight / Math.pow( (height/100), 2 )).toFixed(1); 
    return bmi;
}