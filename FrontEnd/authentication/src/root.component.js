import App from "./App";
import { BrowserRouter } from "react-router-dom";

const Root = (props) => {
  return (
    <BrowserRouter>
      <App emitMulticastMessage = {props.emitMulticastMessage}/>
    </BrowserRouter>
  )
}

export default Root;