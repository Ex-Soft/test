import { useNavigate } from 'react-router-dom';
import './index.css';

const Products: React.FC = () => {
    const navigate = useNavigate();

    return (
        <div>
            <h1>Products</h1>
            <div>
            <button onClick={() => navigate("/products/12345")}>Product Details</button>
            </div>
        </div>
    );
};

export default Products;