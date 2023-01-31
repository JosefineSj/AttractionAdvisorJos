import { useState, useEffect } from "react";
import LoginApi from "../loginCheck";
import './login.css';

export default function SignIn() {
  const [userName, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [user, setUser] = useState(null);

  const logOut = () => {
    setUser(null);
  }

  const handleSubmit = (event) => {
    event.preventDefault();
    
    const headers = new Headers();
          headers.append('Content-Type', 'application/json'); 
          //headers.append('Access-Control-Allow-Origin', 'https://localhost:7216/api/Users'); 

            const requestOptions = {
              method: 'POST',
              headers: headers,
              Accept: 'application/json',
              mode: 'cors',
            body: JSON.stringify({username: `${userName}`, password: `${password}` })
          };
          fetch('https://localhost:7216/api/Users/login', requestOptions)
              .then(response => {
                console.log(response);
                if(response.status === 200) {
                  alert("You are now signed in!")
                  setUser(1)
                }
                else alert("Incorrect username or password");
                
                console.log(response.status)});
              //.then(data => this.setState({ postId: data.id }))
              //.then(data => console.log(data));
           


    // const data = LoginApi.CheckLogin(username, password);
    // setUser(data);

    // if (data === null) alert("Incorrect username or password");
    // else alert("You are now signed in!");
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
