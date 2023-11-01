import { useState } from "react";
import { debounce } from "lodash";
import "./index.css";

interface BarcodeInputState {
    value?: string;
    lastValue?: string;
};

const BarcodeInput: React.FC = () => {
    const [state, setState] = useState<BarcodeInputState | null | undefined>({ value: "", lastValue: "" });

    const delayCall = debounce((value?: string) => {
        if (!!value && value.length - (state?.lastValue?.length || 0) === 13 && !/\D/.test(value.slice(-13))) {
            setState({ value: value.slice(-13), lastValue: value.slice(-13) });
            console.log("code - %s", value?.slice(-13));
        } else {
            setState({lastValue: value});
            console.log("search - %s", value);
        }
    }, 200);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const value = e.target.value;

        setState({ value });
        delayCall(value);
    };

    return (
        <input type="text"
            value={state?.value}
            onChange={(e) => handleChange(e)}
        />
    );
};

export default BarcodeInput;