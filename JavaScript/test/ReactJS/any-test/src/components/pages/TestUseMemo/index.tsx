import { useState, useMemo } from 'react';

import './index.css';

const TestUseMemo: React.FC = () => {
    const [count, setCount] = useState<number>(0);
    const [todos, setTodos] = useState<string[]>([]);
    //const calculation = expensiveCalculation(count);
    const calculation = useMemo(() => expensiveCalculation(count), [count]);

    const increment = () => {
        setCount((c) => c + 1);
    };

    const addTodo = () => {
        setTodos((t) => [...t, "New Todo"]);
    };
    
    return (
        <div>
            <h1>useMemo</h1>
            <div>
                <div>
                    <h2>My Todos</h2>
                    <button onClick={addTodo}>Add Todo</button>
                    {todos.map((todo, index) => {
                        return <p key={index}>{todo}</p>;
                    })}
                </div>
                <hr />
                <div>
                    Count: {count}
                    <button onClick={increment}>+</button>
                    <h2>Expensive Calculation</h2>
                    {calculation}
                </div>
            </div>
        </div>
    );
};

export default TestUseMemo;

const expensiveCalculation = (num: number) => {
    console.log("Calculating...");
    for (let i = 0; i < 1000000000; i++) {
        num += 1;
    }
    return num;
};