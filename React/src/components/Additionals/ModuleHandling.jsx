import React from "react";
import Button from "./Button";

const ModuleHandling = () => {

    const handleClick = () =>
    {
        alert("Button Clicked");
    }


    const showAlert =() =>{
        alert("Read it..")
    }
    return(
        <div>
           <Button onClick={handleClick} text="Click!!!"></Button>

           <Button onClick={showAlert} text="Read!!!"></Button>
        </div>

    );

}
export default ModuleHandling;