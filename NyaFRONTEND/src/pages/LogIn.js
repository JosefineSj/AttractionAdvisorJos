import { useState, useEffect } from 'react';
import LoginApi from '../loginCheck';

export default function SignIn() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
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

        if(data === null) alert("Felaktigt användarnamn eller lösenord"); 
        else alert("Du är nu inloggad");

    };
    console.log(user);
    if (user === null) {
      return (
        
        <form onSubmit={handleSubmit}>
            <h2>Welcome back!</h2>
            <h3>Enter your chosen username and password:</h3>

          <label>
            Username:
            <input type="text" value={username} onChange={(e) => setUsername(e.target.value)} />
          </label>
          <br />
          <label>
            Password:
            <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
          </label>
          <br />
          <button type="submit">Sign In</button>
        </form>
      );
    } else {
      return (
        <div>
          <h1>You are in!</h1>
        </div>
      )
    }
  
}



