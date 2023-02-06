import { useState } from "react";
import './login.css';
import ApiFetch from "../webService/WebApi";
import userData from "../userData";

export default function SignIn() {
  const [userName, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [user, setUser] = useState(null);

  const logOut = () => {
    setUser(null);
    userData.userName = null;
  }

  const handleSubmit = async (event) => {
    event.preventDefault();
    const data = await ApiFetch('/Users/login', 'POST', {username:  `${userName}`, password: `${password}` });
      console.log(data.id)
      if (data === null || data === undefined) alert("Incorrect username or password");
        else {
          console.log(data);
          alert("You are now signed in!");
          setUser(data.userName);
          userData.userName = data.username;
          userData.id = data.id;
          window.location.href = "https://localhost:3000/add-attraction";
        }
  };

  if (user === null) {
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
  } else {
    return (
      <div className="LogIn">
        <h1>You are in!</h1>
        <button className="logout" onClick={logOut}>Logga ut</button>
      </div>
    );
  }
}
