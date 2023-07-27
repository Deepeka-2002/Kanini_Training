import React from 'react';
import { useParams } from 'react-router-dom';


const User = () => {

   const {inputValue} = useParams();

  return (
  <h2>User Name: {inputValue}</h2>
  );

};


export default User;