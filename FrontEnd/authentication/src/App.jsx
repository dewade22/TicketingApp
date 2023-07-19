import { Route, Routes } from "react-router-dom";
import Login from "./component/Login";
import Logout from "./component/Logout";

const App = (props) => {
    return (
        <Routes>
            <Route path="/logout" element={<Logout />} />
            <Route
                path={window.location.pathname}
                element={
                    <Login 
                        emitMulticastMessage = {props.emitMulticastMessage}
                        path = {window.location.pathname}
                    />
                }
            />
        </Routes>
    );
};

export default App;