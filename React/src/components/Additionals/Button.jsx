import React from "react";


const Button = ({onClick,text}) =>{
    return (
    <button id="but" onClick={onClick}>{text}</button>);
}

export default Button;