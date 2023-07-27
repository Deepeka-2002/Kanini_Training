import React from "react";

class BoundedComponent extends React.Component {

    constructor(props) {
        super(props);
        this.state = { count: 0 };
        // this.incrementCount = this.incrementCount.bind(this);
    }

    incrementCount = () => {
        this.setState((prevState) => ({
            
            count: prevState.count + 1
        }));

    };

    render() {
        return (
            <div>
                <p>Count:{this.state.count}</p>
                <button onClick={this.incrementCount}>Increment</button>
            </div>
        );
    }
};

export default BoundedComponent;