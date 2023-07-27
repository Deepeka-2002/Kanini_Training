import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';

const root = ReactDOM.createRoot(document.getElementById('root'));
const head2 = <div><h1>React</h1>
  <h6>React h6</h6></div>
root.render(
  // <h1>React APP</h1>
  // <React.StrictMode>
    <App />
//  </React.StrictMode> 
  // head2
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
