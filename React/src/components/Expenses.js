import React,{useState} from 'react';
import ExpenseDateLoad from './ExpenseDateLoad';
import Card from './Card'
import './Expenses.css'
 import NewExpense from './NewExpense';

const Expenses= (props) =>
{
    // let exptype=props.exptype;

    const[exptype,setType] = useState(props.exptype);
    const changeExpType =() => {
        setType ('Grocery');
        console.log(exptype);
    }

    return(
        <div>
      
           <Card>
           <ExpenseDateLoad edate ={props.expdate} ></ExpenseDateLoad>
              {props.exptype}  {props.expamt}
           <button onClick={changeExpType}>Change Expense Type</button>
           
            </Card>
        </div>
    );
}
export default Expenses;