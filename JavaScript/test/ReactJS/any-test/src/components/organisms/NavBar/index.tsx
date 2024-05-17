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
                    <NavLink to="/testusestate">useState</NavLink>
                </li>
                <li>
                    <NavLink to="/testuseeffect">useEffect</NavLink>
                </li>
                <li>
                    <NavLink to="/testusecallback">useCallback</NavLink>
                </li>
                <li>
                    <NavLink to="/testusememo">useMemo</NavLink>
                </li>
                <li>
                    <NavLink to="/testuseref">useRef</NavLink>
                </li>
                <li>
                    <NavLink to="/testusecontext">useContext</NavLink>
                </li>
                <li>
                    <NavLink to="/testfromchildtoparent">From Child To Parent</NavLink>
                </li>
                <li>
                    <NavLink to="/products">Products</NavLink>
                </li>
                <li>
                    <NavLink to="/testmui">MUI</NavLink>
                </li>
                <li>
                    <NavLink to="/customdropdown">CustomDropdown</NavLink>
                </li>
                <li>
                    <NavLink to="/testformik">Formik</NavLink>
                </li>
                <li>
                    <NavLink to="/customcontrols">CustomControls</NavLink>
                </li>
                <li>
                    <NavLink to="/testcustomdatafetchinghook">TestCustomDataFetchingHook</NavLink>
                </li>
                <li>
                    <NavLink to="/testdebonce">TestDebonce</NavLink>
                </li>
                <li>
                    <NavLink to="/testconditionalrendering">TestConditionalRendering</NavLink>
                </li>
                <li>
                    <NavLink to="/testlocalstorage">TestLocalStorage</NavLink>
                </li>
            </ul>
        </nav>
    );
};

export default NavBar;