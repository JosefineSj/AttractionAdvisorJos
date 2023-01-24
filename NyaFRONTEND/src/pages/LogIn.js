import { useState, useEffect } from "react";
import LoginApi from "../loginCheck";
import './login.css';

export default function SignIn() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [user, setUser] = useState(null);

  const handleSubmit = (event) => {
    event.preventDefault();
    // Perform sign-in logic here, such as sending a request to a server
    /*       const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ UserName: username, Password: password })
    };
    fetch('https://reqres.in/api/posts', requestOptions)
        .then(response => response.json())
        .then(data => {
          setUser(data)   
        }); */

    const data = LoginApi.CheckLogin(username, password);
    setUser(data);

    if (data === null) alert("Incorrect username or password");
    else alert("You are now signed in!");
  };
  console.log(user);
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
              value={username}
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
      <div>
        <h1>You are in!</h1>
      </div>
    );
  }
}
