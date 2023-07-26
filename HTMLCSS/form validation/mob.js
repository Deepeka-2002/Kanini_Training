function validateName() {
    var entered_name = document.getElementById("name");
    var regName = /^[A-Za-z\s]*$/;
    if (entered_name.value == "" || !entered_name.value.match(regName)) {
      entered_name.classList.remove("valid");
      entered_name.classList.add("invalid");
      document.getElementById("result").innerHTML = "Please enter valid Username";
      entered_name.focus();
      return false;
    } else {
      entered_name.classList.remove("invalid");
      entered_name.classList.add("valid");
    }
  }
  
  function validateContactNo() {
    var re = /^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$/;
    var entered_phnumber = document.getElementById("phoneNumber");
    if (entered_phnumber.value.match(re)) {
      entered_phnumber.classList.remove("invalid");
      entered_phnumber.classList.add("valid");
    } else {
      entered_phnumber.classList.remove("valid");
      entered_phnumber.classList.add("invalid");
      document.getElementById("result").innerHTML = "Please enter valid phone number ";
      entered_phnumber.focus();
    }
  }
  
  function emailValidation() {
    var entered_email = document.getElementById("emailid");
    var validRegex =/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    if (entered_email.value.match(validRegex)) {
      entered_email.classList.remove("invalid");
      entered_email.classList.add("valid");
    } else {
      entered_email.classList.remove("valid");
      entered_email.classList.add("invalid");
      document.getElementById("result").innerHTML = "Please enter valid emailid";
      entered_email.focus();
    }
  }
  
  function validateAddress() {
    var entered_address = document.getElementById("address");
    if (entered_address.value == "") {
      entered_address.classList.remove("valid");
      entered_address.classList.add("invalid");
      document.getElementById("result").innerHTML = "Please enter valid Credentials";
      entered_address.focus();
    } else {
      entered_address.classList.remove("invalid");
      entered_address.classList.add("valid");
    }
  }
  
  var comboPrices = {
    option1: 799,
    option2: 899,
    option3: 1199,
    option4: 299,
    option5: 999,
  };
  
  function costCalculation() {
  if(true){
    var check1 = document.getElementById("option1").checked;
    var check2 = document.getElementById("option3").checked;
    var check3 = document.getElementById("option3").checked;
    var check4 = document.getElementById("option4").checked;
    var check5 = document.getElementById("option5").checked;
    var originalPrice = 0;
    if (check1 || check2 || check3 || check4 || check5) {
      if (check1) {
        originalPrice += comboPrices.option1;
      }
      if (check2) {
        originalPrice += comboPrices.option2;
      }
      if (check3) {
        originalPrice += comboPrices.option3;
      }
      if (check4) {
        originalPrice += comboPrices.option4;
      }
      if (check5) {
        originalPrice += comboPrices.option5;
      }
      if (originalPrice >= 2000) {
        var discount = (originalPrice * 20) / 100;
        var netPrice = originalPrice - discount;
        document.getElementById("result").innerHTML =
          "Order has been placed successfully. You are requested to pay Rs." + Math.round(netPrice) + " on delivery.";
      } else {
        document.getElementById("result").innerHTML =
          "Order has been placed successfully. You are requested to pay Rs." + Math.round(originalPrice) + " on delivery.";
      }
    } else {
      document.getElementById("result").innerHTML = "No selection has been made.";
    }
  }
  }
  