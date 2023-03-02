import { useState, useCallback, useEffect } from "react";
import './index.css';
import { Todos, ChildClickableButton } from "../../organisms";

const TestUseCallback: React.FC = () => {
    const [count, setCount] = useState<number>(0);
    const [todos, setTodos] = useState<string[]>([]);

    useEffect(() => {
        console.log("TestUseCallback.useEffect() (re-)render!!!");
    });

    useEffect(() => {
        console.log("TestUseCallback.useEffect(, [])");
    }, []);

    const increment = () => {
        setCount((c) => c + 1);
    };

    /* const addTodo = () => {
        setTodos((t) => [...t, "New Todo"]);
    }; */

    const addTodo = useCallback(() => {
        setTodos((t) => [...t, "New Todo"]);
    }, [todos]);
    
    const handleChildClickableButtonClick = useCallback(() => {
        console.log("ChildClickableButton click");
    }, []);

    return (
        <div>
            <h1>useCallback</h1>
            <div>
                <Todos todos={todos} addTodo={addTodo} />
                <hr />
                <div>
                    Count: {count}
                    <button onClick={increment}>+</button>
                </div>
                <hr />
                <ChildClickableButton onClick={handleChildClickableButtonClick} />
            </div>
        </div>
    );
};

export default TestUseCallback;