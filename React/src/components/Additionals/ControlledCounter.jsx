import React, {useState} from "react";

const ControlledCounter = () =>
{

    const [inputValue, setInputValue] = useState('');

    const handleChange = (event) =>{
        setInputValue(event.target.value);
    };
    
    return(
        <div>
            <label htmlFor="inputField">Enter a value:</label>
            <input type ="text" id="inputField" value={inputValue} onChange={handleChange}/>
            <p>You entered: {inputValue}</p>
        </div>
    );
};

export default ControlledCounter;