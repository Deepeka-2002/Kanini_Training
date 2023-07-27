import React from 'react'
import {useSelector, useDispatch} from 'react-redux'
import { increment,decrement } from './counterSlice';

const CounterComponent = () => {
    const ccc = useSelector((state) => state.counter);
    const dispatch = useDispatch();
    
    const incrementCounter = () => {
        dispatch(increment());

    };

    const decrementCounter = () => {
        dispatch(decrement());
        
    };

    return(
        <div>
            <p>Counter: {ccc}</p>
            <button onClick={incrementCounter}>Increment</button>
            <button onClick={decrementCounter}>Decrement</button>
        </div>
    )
}
export default CounterComponent;