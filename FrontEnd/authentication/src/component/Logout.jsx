import { useNavigate } from 'react-router-dom';
import Cookies from "js-cookie"

const clearAllCookies = () =>{
    const cookieNames = Object.keys(Cookies.get());

    cookieNames.forEach((cookieName) => {
        Cookies.remove(cookieName);
      });
}

const Logout = () => {
    const navigate = useNavigate();

    localStorage.clear();
    clearAllCookies();

    navigate("/login");
}

export default Logout;