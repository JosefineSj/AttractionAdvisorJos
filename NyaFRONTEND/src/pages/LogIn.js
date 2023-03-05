import { useState, useContext, } from "react";
import './login.css';
import ApiFetch from "../webService/WebApi";
import userData from "../userData";
import { UserContext } from '../App';
import { useNavigate } from "react-router-dom";



export default function SignIn() {
  const navigate = useNavigate();
  const { dispatch } = useContext(UserContext);
  // can rewrite the input fields using useRef as they will trigger a rerender everytime they change
  // @see https://www.developerway.com/posts/react-re-renders-guide
  const [userName, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [user, setUser] = useState(null);

  const handleSubmit = async (event) => {
    event.preventDefault();
    const data = await ApiFetch('/Users/login', 'POST', { username: `${userName}`, password: `${password}` })
    // IF return, its a nice pattern

    if (isNaN(data) || data === undefined) {
      alert("Incorrect input or user does not exist");
      console.log(data, "data");
      return
    }

    console.log("data", data, "username", userName);

    alert("You are now signed in!");
    dispatch({ type: 'USER', payload: true })

    setUser(userName);
    userData.userName = userName;
    userData.id = data;
    navigate("/add-attraction");

  };


  if (user) {
    return null
  }


  return (
    <div className="LogIn">
      <form
        className="formControl"
        onSubmit={handleSubmit}
        action="action_page.php"
      >
        <div className="containerForm">
          <div className="signUpHeader">
            <h1>Welcome back!</h1>
            <p>Enter your chosen username and password: </p>
            <hr />
          </div>
          <div className="signUpUserNamePassWordDiv">
            <label for="username">
              <b>Username: </b>{" "}
            </label>
            <input
              className="inputSignUp"
              type="text"
              placeholder="Your name..."
              value={userName}
              onChange={(e) => setUsername(e.target.value)}
              required
            />
          </div>

          <div className="signUpUserNamePassWordDiv">
            <label for="password">
              <b>Password: </b>{" "}
            </label>
            <input
              className="inputSignUp"
              type="text"
              placeholder="Your password..."
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />
          </div>

          <div className="clearfix">
            <button className="signupbtn" type="submit">
              Sign In
            </button>
          </div>
        </div>
      </form>
    </div>
  );


}
