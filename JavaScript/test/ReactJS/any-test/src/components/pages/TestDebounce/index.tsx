// https://dmitripavlutin.com/react-throttle-debounce/
import { useRef, useState, useCallback, useMemo, useEffect } from "react";
import { debounce } from "lodash";
import "./index.css";

interface InputState {
    value?: string;
    lastValue?: string;
}

const TestDebounce: React.FC = () => {
    console.log("TestDebounce() started");

    const counter = useRef(1);
    const clickHandler = debounce((count) => {console.log("click happened! count = %i", count)});

    const debouncedChangeHandler1 = debounce((value) => {console.log("onChange(\"%s\")", value)}, 500);

    const [state2, setState2] = useState<string | null | undefined>();
    const changeHandler2 = (value?: string) => {
        console.log("before setState2(\"%s\")", value);
        setState2(value);
        console.log("after setState2(\"%s\")", value);
    };
    const debouncedChangeHandler2 = useCallback(debounce(changeHandler2, 500), [state2]);

    const [state3, setState3] = useState<string | null | undefined>();
    const changeHandler3 = (value?: string) => {
        console.log("before setState3(\"%s\")", value);
        setState3(value);
        console.log("after setState3(\"%s\")", value);
    };
    const debouncedChangeHandler3 = useMemo(() => debounce(changeHandler3, 500), [state3]);

    const [inputState, setInputState] = useState<InputState | null | undefined>();
    const changeHandler4 = (value?: string) => {
        console.log("changeHandler4(\"%s\") started { value: \"%s\", lastValue: \"%s\" }", value, inputState?.value, inputState?.lastValue);
        setInputState({value});

        console.log("before delayCall(\"%s\") { value: \"%s\", lastValue: \"%s\" }", value, inputState?.value, inputState?.lastValue);
        delayCall(value);
        console.log("after delayCall(\"%s\") { value: \"%s\", lastValue: \"%s\" }", value, inputState?.value, inputState?.lastValue);

        console.log("changeHandler4(\"%s\") finished { value: \"%s\", lastValue: \"%s\" }", value, inputState?.value, inputState?.lastValue);
    };
    const delayCall = debounce((value?: string) => {
        console.log("delayCall(\"%s\") started { value: \"%s\", lastValue: \"%s\" }", value, inputState?.value, inputState?.lastValue);

        if (!!value && value.length - (inputState?.lastValue?.length || 0) === 13 && !/\D/.test(value.slice(-13))) {
            setInputState({ value: value.slice(-13), lastValue: value.slice(-13) });
            console.log("code - %s { value: \"%s\", lastValue: \"%s\" }", value?.slice(-13), inputState?.value, inputState?.lastValue);
        } else {
            setInputState({lastValue: value});
            console.log("search - %s { value: \"%s\", lastValue: \"%s\" }", value, inputState?.value, inputState?.lastValue);
        }

        console.log("delayCall(\"%s\") finished { value: \"%s\", lastValue: \"%s\" }", value, inputState?.value, inputState?.lastValue);
    }, 1000);

    const [victimValue, setVictimValue] = useState<string | null | undefined>();

    useEffect(() => {
        return () => {
            debouncedChangeHandler2.cancel();
            debouncedChangeHandler3.cancel();
            delayCall.cancel();
        };
    }, []);

    console.log("TestDebounce() finished");

    return (<div>
        <h1>Test Debonce</h1>
        <hr/>
        <button
            onClick={() => {
                counter.current += 1;
                clickHandler(counter.current);
                clickHandler(counter.current);
                clickHandler(counter.current);
            }}
        >
            Click me #1
        </button>
        <button
            onClick={() => {
                clickHandler(1);
                clickHandler(2);
                clickHandler(3);
            }}
        >
            Click me #2
        </button>
        <input type="text" onChange={(e) => debouncedChangeHandler1(e.target.value)} />
        <input type="text" onChange={(e) => debouncedChangeHandler2(e.target.value)} />
        <input type="text" onChange={(e) => debouncedChangeHandler3(e.target.value)} />
        <input type="text" value={inputState?.value} onChange={(e) => changeHandler4(e.target.value)} />
        <input type="button" value="inputState" onClick={() => console.log("{ value: \"%s\", lastValue: \"%s\" }", inputState?.value, inputState?.lastValue)} />
        <hr/>
        <input type="text" value={victimValue as string} />
        <input type="button" value="undefined" onClick={() => setVictimValue(undefined)} />
        <input type="button" value="null" onClick={() => setVictimValue(null)} />
        <input type="button" value="string value" onClick={() => setVictimValue("string value")} />
    </div>);
};

export default TestDebounce;
