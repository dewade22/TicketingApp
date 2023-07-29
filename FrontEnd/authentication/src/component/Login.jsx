import "./Login.css";
import { useEffect, useState, useMemo, useRef } from "react";
import { useNavigate } from "react-router-dom";
import Cookies from "js-cookie";
import { AuthenticationService } from "@tapp/shared-api";
import SimpleReactValidator from 'simple-react-validator';

const _authenticationService = new AuthenticationService();

const Login = (props) => {
    const initialData = useMemo(() => ({
        email: "",
        password: "",
    }));

    const cookies = {
        accessToken: "_tapp_accessToken",
        refreshToken: "_tapp_refreshToken",
    };

    const [data, setData] = useState(initialData);
    const [, forceUpdate] = useState();
    const simpleValidator = useRef(new SimpleReactValidator());
    const [isSubmitting, setIsSubmitting] = useState(false);
    const [errorMessage, setErrorMessage] = useState();

    const isValid = () => {
        return simpleValidator.current.allValid()
        
    };

    const onNetworkCallError = (err) => {
        setIsSubmitting(false);

        if (err.response.data && err.response.data.errorMessages){
            setErrorMessage(err.response.data.errorMessages[0]);
            return;
        }
        setErrorMessage(err.response.statusText);
    }

    const storeToken = (token) => {
        Cookies.set(cookies.accessToken, token.data.accessToken);
        Cookies.set(cookies.refreshToken, token.data.refreshToken);
    }

    const onSubmit = (e) => {
        e.preventDefault();
        if (!isValid()){
            simpleValidator.current.showMessages();
            forceUpdate(1)
            return;
        }

        setIsSubmitting(true);

        _authenticationService
            .SignIn({...data})
            .then((result) => {
                storeToken(result.data)
                // navigate to dashboard
            })
            .catch(onNetworkCallError);
    }

    return (
        <>
        <section>
            <aside>
                <h1>Login</h1>
                <h2>Please enter your credentials</h2>
                <form className="login-form">
                    {
                        errorMessage !== "" ?
                        (
                        <span className="text-danger">
                            {errorMessage}
                        </span>
                        ) : <></>
                    }
                    
                    <input
                        type="email"
                        placeholder="Email Address"
                        onChange={(e) => {
                            setData({...data, email: e.target.value});
                            setErrorMessage("");
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
                            setErrorMessage("");
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