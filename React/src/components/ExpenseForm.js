import React,{useState} from 'react'

const ExpenseForm = () => {
    
    // const [data, setData] = useState(
    //     {
    //         date:'',type:'', amount:''
    //     }
    // );

    const [type, setType] = useState('');
    const [date, setDate] = useState('');
    const [amount, setAmount] = useState('');

    const addNewDate = (val) =>
    {
       // setData({...data, date: event.target.value })
    //    setData((prevState) =>
    //    {
    //        return {...prevState, date:event.target.value};
    //    }

    //    );
    console.log(val);
    setDate(val);
    }

    
    const addNewType = (val) =>
    {
       // setData({...data, type: event.target.value })
    //    setData((prevState) =>
    //    {
    //        return {...prevState, type:event.target.value};
    //    }

    //    );

       console.log(val);
    setType(val);
    }

    
    const addNewAmount = (val) =>
    {
        //setData({...data, amount: event.target.value })

        // setData((prevState) =>
        // {
        //     return {...prevState, amount:event.target.value};
        // }

        // );

        console.log(val);
    setAmount(val);
    }
    

    const newDataAdd =(str,val) =>{
        if(str === 'date')
        addNewDate(val);
        else  if(str === 'type')
        addNewType(val);
        else if(str === 'amount')
        addNewAmount(val);
    }


    const addnewExpense =(event) => {
        event.preventDefault();

        const newExpense={
            newType:type,
            newAmount:amount,
            newDate:date
       
        }
    }
    return(
        <form onSubmit={addnewExpense}>
            <div>
                <label>Date : </label>
                <input type="text" onChange={
                    (event) =>
                    newDataAdd ('date', event.target.value)}></input>
            </div>
            <div>
                <label>Expense : </label>
                <input type="text" onChange={
                    (event) =>
                    newDataAdd ('type', event.target.value)}></input>
            </div>
            <div>
                <label>Amount : </label>
                <input type="number" onChange={
                    (event) =>
                    newDataAdd ('amount', event.target.value)}></input>
            </div>
            <button type="submit">ADD NEW</button>
        </form>
    );
}
export default ExpenseForm;