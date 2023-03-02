import { useParams } from 'react-router-dom';
import './index.css';

const ProductDetails: React.FC = () => {
    const { id } = useParams();

    return (
        <div>
            <h1>Product Details {id}</h1>
            <div>
            </div>
        </div>
    );
};

export default ProductDetails;