import { useState, useCallback, useEffect } from "react";
import { Todos, ChildClickableButton } from "../../organisms";
import "./index.css";

const TestUseCallback: React.FC = () => {
  const [count, setCount] = useState<number>(0);
  const [todos, setTodos] = useState<string[]>([]);
  const [victim, setVictim] = useState<number>();

  useEffect(() => {
    console.log("TestUseCallback.useEffect(() => {}) (re-)render!!!");
  });

  useEffect(() => {
    console.log("TestUseCallback.useEffect(() => {}, [])");
  }, []);

  useEffect(() => {
    const timeout = setTimeout(() => {
      console.log("TestUseCallback.useEffect(() => {}, []) -> setVictim()");
      setVictim(13);
    }, 5000);

    return () => clearTimeout(timeout);
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

  const handleChildClickableButtonClick1 = () => {
    console.log("ChildClickableButton click victim=%o", victim);
  };

  const handleChildClickableButtonClick2 = useCallback(() => {
    console.log("ChildClickableButton click victim=%o", victim);
  }, []);

  const handleChildClickableButtonClick3 = useCallback(() => {
    console.log("ChildClickableButton click victim=%o", victim);
  }, [victim]);

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
        <div className="test-use-callback-container">
          <ChildClickableButton onClick={handleChildClickableButtonClick1} />
          <ChildClickableButton onClick={handleChildClickableButtonClick2} />
          <ChildClickableButton onClick={handleChildClickableButtonClick3} />
        </div>
      </div>
    </div>
  );
};

export default TestUseCallback;
