import { NavLink } from 'react-router-dom';
import './index.css';

const NavBar: React.FC = () => {
    return (
        <nav>
            <ul>
                <li>
                    <NavLink to="/">Home</NavLink>
                </li>
                <li>
                    <NavLink to="/testaxios">Axios</NavLink>
                </li>
                <li>
                    <NavLink to="/testuseeffect">useEffect</NavLink>
                </li>
                <li>
                    <NavLink to="/testusecallback">useCallback</NavLink>
                </li>
                <li>
                    <NavLink to="/testfromchildtoparent">From Child To Parent</NavLink>
                </li>
                <li>
                    <NavLink to="/products">Products</NavLink>
                </li>
            </ul>
        </nav>
    );
};

export default NavBar;