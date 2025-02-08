// https://devtrium.com/posts/async-functions-useeffect
// https://www.robinwieruch.de/react-hooks-fetch-data/

import { useEffect, useState, useCallback } from 'react';
import axios from 'axios';
import { Cart, CartProduct } from '../../../classes/cart';
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
                console.log("code: \"%s\", message: \"%s\", response: %o, response.status: %i, response.statusText: \"%s\", response.data: \"%s\"", error.code, error.message, error.response, error.response?.status, error.response?.statusText, error.response?.data);
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
            console.log("code: \"%s\", message: \"%s\", response: %o, response.status: %i, response.statusText: \"%s\", response.data: \"%s\"", error.code, error.message, error.response, error.response?.status, error.response?.statusText, error.response?.data);
        }
    }

    const handleTestClone = async () => {
        const data = new Cart([]);
        console.log(data);
        data.products?.push(new CartProduct(1, 10, 100));
        data.products?.push(new CartProduct(2, 20, 100));
        console.log(data.total);

        try {
            const response = await axios.post(`${baseCoOpUrl}/testclone`, data);
            console.log("status: %i, statusText: \"%s\", data: %o", response.status, response.statusText, response.data);
        } catch (error: any) {
            console.log("code: \"%s\", message: \"%s\", response: %o, response.status: %i, response.statusText: \"%s\", response.data: \"%s\"", error.code, error.message, error.response, error.response?.status, error.response?.statusText, error.response?.data);
        }
    }

    return (
        <div>
            <h1>Axios</h1>
            <div className="table">
                <input type="button" value="200" onClick={handle200} />
                <input type="button" value="500" onClick={handle500} />
                <input type="button" value="async 500" onClick={handle500Async} />
                <input type="button" value="Test Clone" onClick={handleTestClone} />
            </div>
        </div>
    );
};

export default TestAxios;