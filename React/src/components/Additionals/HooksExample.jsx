import React,{useState, useEffect} from 'react';

const HooksExample = () => {

    const[count, setCount] = useState(0);
    const[data, setData]= useState(null);

    const incrementCount = () =>{
        setCount(prevCount => prevCount + 1);
    };

    useEffect(() =>{
            fetchData();
    }, [count]);

    const fetchData = () =>{
        setTimeout( () => {
            const newData = `Data for Count ${count}`;
            setData(newData);
        },3000

        );
    };

    return(
        <div>
            <p>Count: {count}</p>
            <button onClick={incrementCount}>Click Here</button>
            <p>{data ? data: "Fetching...."}</p>
        </div>

    );
}

export default HooksExample;