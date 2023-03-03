import { useParams, useNavigate } from 'react-router-dom';
import './index.css';

const ProductDetails: React.FC = () => {
    const { id } = useParams();
    const navigate = useNavigate();

    return (
        <div>
            <h1>Product Details {id}</h1>
            <div>
                <button onClick={() => navigate("/products")}>&lt;-</button>
            </div>
        </div>
    );
};

export default ProductDetails;