import { memo, useEffect } from "react";
import './index.css';

export type TodosProps = {
    todos: string[];
    addTodo: () => void
};
   
const Todos: React.FC<TodosProps> = ({ todos, addTodo }) => {
    useEffect(() => {
        console.log("Todos.useEffect() (re-)render!!!");
    });

    useEffect(() => {
        console.log("Todos.useEffect(, [])");
    }, []);

    useEffect(() => {
        console.log("Todos.useEffect(, [todos = %o])", todos);
    }, [todos]);

    return (
        <>
            <h2>Todos</h2>
            <button onClick={addTodo}>Add Todo</button>
            {todos.map((todo, index) => {
                return <p key={index}>{todo}</p>
            })}
        </>
    );
};

export default memo(Todos);
