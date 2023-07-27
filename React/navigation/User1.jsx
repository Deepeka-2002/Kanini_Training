import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const User1 = () => {
    const [inputValue, setInputValue] = useState('');
    const navigate = useNavigate();
  
    const handleInputChange = (event) => {
        
      setInputValue(event.target.value);
      console.log(inputValue);
    };
  
    const handleSubmit = (event) => {
      event.preventDefault();
      navigate(`/user/${inputValue}`);
    };
  
    return (
      <div>
        <form onSubmit={handleSubmit}>
          <input type="text"  value={inputValue} onChange={handleInputChange} />
          <button type="submit">Go to Next Page</button>
        </form>
      </div>
    );
  };
  
  export default User1;
  