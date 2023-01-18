import React, { useState } from 'react';


export default function SignUp() {

        const [formData, setFormData] = useState({
            username: '',
            password: ''
          });
        
          const handleSubmit = event => {
            event.preventDefault();
            // Send form data to server for registration
            const requestOptions = {
              method: 'POST',
              headers: { 'Content-Type': 'application/json' },
              body: JSON.stringify({ UserName: 'Adsdsd dfsd dfsff', Password: 'fdsfsd' })
          };
          fetch('https://reqres.in/api/posts', requestOptions)
              .then(response => response.json())
              //.then(data => this.setState({ postId: data.id }))
              .then(data => console.log(data));
            console.log(formData);
          };
        
          const handleChange = event => {
            const { name, value } = event.target;
            setFormData(prevData => ({
              ...prevData,
              [name]: value
            }));
          };
        
          return (
            <form onSubmit={handleSubmit}>
              <h2>Register new user:</h2>
              <label>
                Username:
                <input
                  type="text"
                  name="username"
                  value={formData.username}
                  onChange={handleChange}
                />
              </label>
              <br />
              <label>
                Password:
                <input
                  type="password"
                  name="password"
                  value={formData.password}
                  onChange={handleChange}
                />
              </label>
              <br />
              <button type="submit">Register</button>
            </form>
    );
}
        
