import { useNavigate } from 'react-router-dom';
import './index.css';

const Home: React.FC = () => {
    const navigate = useNavigate();

    return (
        <div>
            <h1>Home</h1>
            <div>
                <button onClick={() => navigate("/testuseeffect")}>useEffect</button>
            </div>
        </div>
    );
};

export default Home;