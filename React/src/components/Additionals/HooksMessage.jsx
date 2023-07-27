import React, {useState,useEffect} from"react";

const HooksMessage = () =>{

    const [name, setName] = useState('');
    const[message, setMessage] = useState('');

    const handleNameChange = (event) =>{
        setName(event.target.value);
    };
    const handleButtonClick = () =>
    {
       setMessage(`Hello, ${name}!`);
    }

    useEffect (() =>{
        document.title = `Hello, ${name}!`;
    },[name]

    );

    return(
        <div>
            <lable>Enter your Name: </lable>
            <input type="text" value={name} onChange={handleNameChange}></input>
            <button onClick ={handleButtonClick}>Click</button>
            <p>{message}</p>
        </div>
    );
}
export default HooksMessage;