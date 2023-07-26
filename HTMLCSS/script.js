// var cust_name = document.getElementById("customerName").value;
// var mobile = document.getElementById("mobileNumber").value;
// var acType = document.getElementById("acTypes").value;
// var serviceType = document.getElementById("serviceType").value;
// var email = document.getElementById("email").value;
// var yearlyMaintenance = document.getElementById('yearlyMaintenance').checked;

// validateName();

// function bookAppointment()
// { 

//     let serviceCharge = 0;
//     switch (serviceType) 
//     {
//     case 'Cleaning':
//         serviceCharge = 500;
//         break;
//     case 'Repair':
//         serviceCharge = 1000;
//         break;
//     case 'Gas Refill':
//         serviceCharge = 1500;
//         break;
//     default:
//         serviceCharge = 0;
//     }

//     if (yearlyMaintenance) {
//         serviceCharge += 1000;
//         document.getElementById("result").innerHTML=`Hello ${cust_name}, your service appointment for ${acType} AC ${serviceType} with yearly maintenance will be sent to your email ID ${email} and the estimated service charge will be Rs ${serviceCharge}`;
//       }
//       else(yearlyMaintenance == false){
//         document.getElementById("result").innerHTML=`Hello ${cust_name}, your service appointment for ${acType} AC ${serviceType} without yearly maintenance will be sent to your email ID ${email} and the estimated service charge will be Rs ${serviceCharge}`;
//       }}


// function validateName()
// {
//     var regName = /[A-Za-z]/g;
//     if(regName.test(entered_name))
//     {
//         validateMobile();
//     }
//     else
//     {
//         document.getElementById("result").innerHTML ="Please enter valid name";
//     }
// }

// function validateMobile()
// {
//     var re = /[789]\d{9}$/g;
//     if(re.test(mobile))
//     {
//         validateEmail();
//     }
//     else
//     {
//         document.getElementById("result").innerHTML ="Please enter mobile number";   
//     }
// }

// function validateEmail()
// {
//     var validRegex =/^[a-zA-Z0-9]+@[a-zA-Z0-9.]+/g;
//     if(validRegex.test(email))
//     {
//         validateAddress();
//     }
//     else
//     {
//         document.getElementById("result").innerHTML ="Please enter valid email id";
//     }
// }

// function validateAddress()
// {
//     var entered_address = document.getElementById("address");
//     if (entered_address.value == "")
//     { 
//         document.getElementById("result").innerHTML ="Please enter address";
//     }
//     else{
//         validateAc();
//     }
// }

// function validateAc()
// {
//     if (acType=="")
//     {
//         document.getElementById("result").innerHTML ="Please enter AC type";
//     }
//     else{
//         validateAppointment();
//     }
// }

// function validateAppointment()
// {
//     var appointment = document.getElementById("dateForAppointment").value;
//     if (appointment == "")
//     {
//         document.getElementById("result").innerHTML ="Please select appointment date";
//     }
//     else
//     {
//         bookAppointment();
//     }
// }


var name_pattern = /[a-z]/g
var phone_pattern = /[789]\d{9}/
var email_pattern = /[a-z@gmail.com]/g 

document.getElementById("submit").addEventListener('click',bookAppointment);


function bookAppointment(){
    let checked = document.getElementById("yearlyMaintenance");
    let customerName = document.getElementById("customerName").value;
    let acType = document.getElementById("acType").value;
    let serviceType = document.getElementById("serviceType").value;
    let email = document.getElementById("email").value;
    let phone = document.getElementById("mobileNumber").value;
    let result = document.getElementById("result");
    let serviceCharge = 0;
    
    switch (serviceType)
    {
        case 'Cleaning':
            serviceCharge = 500;
            break;
        case 'Repair':
            serviceCharge = 1000;
            break;
        case 'Gas Refill':
            serviceCharge = 1500;
            break;
        default:
            serviceCharge = 0;
    }


    if(customerName.match(name_pattern) &&  email.match(email_pattern) && phone.match(phone_pattern) && checked.checked ){
        result.innerHTML = `Hello ${customerName}, your service appointment for ${acType} AC
        ${serviceType} with yearly maintenance will be send to your email ID
        ${email} and the estimated service charge will be Rs ${serviceCharge + 1000}`;
    }else if(checked.checked != "true" && email.match(email_pattern) &&  serviceType.length > 0 && customerName.match(name_pattern)){
        result.innerHTML = `Hello ${customerName}, your service appointment for ${acType} AC
        ${serviceType} without yearly maintenance will be send to your email ID
        ${email} and the estimated service charge will be Rs ${serviceCharge}`;
    }else{
        result.innerHTML = "fill the details properly";
    }
    console.log(checked.checked);
}

