import './index.css';
import axios from 'axios';

const TestAxios: React.FC = () => {
    const handle200 = async () => {
        try {
            const response = await axios.get("http://localhost:5293/CoOp");
            console.log("status: %i, statusText: \"%s\", data: %o", response.status, response.statusText, response.data);
        } catch (error) {
            console.log(error);
        }
    }
    
    const handle500 = async () => {
        axios.get("http://localhost:5293/CoOp/get500")
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
            const response = await axios.get("http://localhost:5293/CoOp/get500");
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