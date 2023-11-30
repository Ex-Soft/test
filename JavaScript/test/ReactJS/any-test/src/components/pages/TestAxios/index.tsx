// https://devtrium.com/posts/async-functions-useeffect
// https://www.robinwieruch.de/react-hooks-fetch-data/

import { useEffect, useState, useCallback } from 'react';
import axios from 'axios';
import './index.css';

const TestAxios: React.FC = () => {
    const baseCoOpUrl = `${process.env.REACT_APP_REST_BASE_URL}/coop`;
    const [dataCoOp, setDataCoOp] = useState();

    const fetchCoOpData = useCallback(async () => {
        const response = await axios.get(baseCoOpUrl);
        setDataCoOp(response.data);
    }, []);

    useEffect(() => {
        // const fetchCoOpData = async () => {
        //     const response = await axios.get(baseCoOpUrl);
        //     setDataCoOp(response.data);
        // }

        fetchCoOpData()
            .catch(console.error);
    }, []);

    const handle200 = async () => {
        try {
            const response = await axios.get(baseCoOpUrl);
            console.log("status: %i, statusText: \"%s\", data: %o", response.status, response.statusText, response.data);
        } catch (error) {
            console.log(error);
        }
    }
    
    const handle500 = async () => {
        axios.get(`${baseCoOpUrl}/get500`)
            .then(response => {
                console.log("status: %i, statusText: \"%s\", data: %o", response.status, response.statusText, response.data);
            })
            .catch(error => {
                console.log("code: \"%s\", response.status: %i, response.statusText: \"%s\", response.data: \"%s\"", error.code, error.response.status, error.response.statusText, error.response.data);
            })
            .then(() => {
                console.log("axios.then() aka Promise.finally");
            })
            .finally(() => {
                console.log("Promise.finally()");
            })
    }

    const handle500Async = async () => {
        try {
            const response = await axios.get(`${baseCoOpUrl}/get500`);
            console.log("status: %i, statusText: \"%s\", data: %o", response.status, response.statusText, response.data);
        } catch (error: any) {
            console.log("code: \"%s\", response.status: %i, response.statusText: \"%s\", response.data: \"%s\"", error.code, error.response.status, error.response.statusText, error.response.data);
        }
    }

    return (
        <div>
            <h1>Axios</h1>
            <div className='table'>
                <input type="button" value="200" onClick={handle200} /><input type="button" value="500" onClick={handle500} /><input type="button" value="async 500" onClick={handle500Async} />
            </div>
        </div>
    );
};

export default TestAxios;