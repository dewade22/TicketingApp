import "./Login.css";
import { useEffect, useState, useMemo, useRef } from "react";
import { useNavigate } from "react-router-dom";
import Cookies from "js-cookie";
import SimpleReactValidator from 'simple-react-validator';

const Login = (props) => {
    const initialData = useMemo(() => ({
        email: "",
        password: "",
    }));

    const [data, setData] = useState(initialData);
    const [, forceUpdate] = useState();
    const simpleValidator = useRef(new SimpleReactValidator());
    const [isSubmitting, setIsSubmitting] = useState(false);

    const isValid = () => {
        return simpleValidator.current.allValid()
        
    };

    const onSubmit = (e) => {
        e.preventDefault();
        if (!isValid()){
            simpleValidator.current.showMessages();
            forceUpdate(1)
            return;
        }

        setIsSubmitting(true);
    }

    return (
        <>
        <section>
            <aside>
                <h1>Login</h1>
                <h2>Please enter your credentials</h2>
                <form className="login-form">
                    <input
                        type="email"
                        placeholder="Email Address"
                        onChange={(e) => {
                            setData({...data, email: e.target.value});
                        }}
                    />
                    <span className="text-danger">
                        {simpleValidator.current.message('email', data.email, 'required|email')}
                    </span>

                    <input
                        type="password"
                        placeholder="Password"
                        onChange={(e) => {
                            setData({...data, password: e.target.value});
                        }}
                    />
                    <span className="text-danger">
                        {simpleValidator.current.message('password', data.password, 'required')}
                    </span>
                    { isSubmitting ? (
                        <div className="loading-indicator">
                            <div className="spinner"></div>
                        </div>
                    )
                    :
                    (
                        <button type="button" onClick={onSubmit}>Login</button>
                    )}
                    
                </form>
            </aside>
        </section>
        </>
    )
};

export default Login;