import React, { useState } from 'react';
import './signup.css';


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
            <form className='formControl' onSubmit={handleSubmit} action="action_page.php">
              <div className='signUpHeader'>
               <h1 >Hi, User!</h1>
               <p >Enter a username and password of your choice:</p>
               <hr/>
              </div>
              <label for="username"><b>Username: </b></label>
                <input className='inputSignUp'
                  placeholder='Your name...'
                  type="text"
                  name="username"
                  value={formData.username}
                  onChange={handleChange}
                  required
                />
              
              <br />
              <label for="password"><b>Password: </b></label>
                <input className='inputSignUp'
                  placeholder='Your password...'
                  type="password"
                  name="password"
                  value={formData.password}
                  onChange={handleChange}
                  required
                />
              
              <br />
              <div className='clearfix'>
               <button className="signupbtn" type="submit">Sign Up</button>
              </div>
            </form>
    );
}
        
