import React, { useState } from 'react';
import './signup.css';
import ApiFetch from '../webService/WebApi';

export default function SignUp() {

        const [formData, setFormData] = useState({
            username: '',
            password: ''
          });
        
          const handleSubmit = async event => {
            event.preventDefault();
            // Send form data to server for registration

            const data = await ApiFetch('/Users', 'POST', {username:  `${formData.username}`, password: `${formData.password}` });
            console.log(data);
            if(data != null) {
              window.location.href = "https://localhost:3000/login";
              
            } else {
              alert("Something went wrong");
            }
            

          };
        
          const handleChange = event => {
            const { name, value } = event.target;
            setFormData(prevData => ({
              ...prevData,
              [name]: value
            }));
          };
        
          return (
            <div className='SignUp'> 
            <form className='formControl' onSubmit={handleSubmit} action="action_page.php">
              <div className='containerForm'>
              <div className='signUpHeader'>
               <h1 >Hi, User!</h1>
               <p className='signUpParagraph'>Enter a username and password of your choice:</p>
               <hr/>
              </div>
              <div className='signUpUserNamePassWordDiv'>
              <label for="username"><b>Username: </b></label>
                <input className='inputSignUp'
                  placeholder='Your name...'
                  type="text"
                  name="username"
                  value={formData.username}
                  onChange={handleChange}
                  required
                />
              </div>

              <div className='signUpUserNamePassWordDiv'>
              <label for="password"><b>Password: </b></label>
                <input className='inputSignUp'
                  placeholder='Your password...'
                  type="password"
                  name="password"
                  value={formData.password}
                  onChange={handleChange}
                  required
                />
              </div>

              <div className='clearfix'>
               <button className="signupbtn" type="submit">Sign Up</button>
              </div>
              </div>
            </form>
          </div>
    );
}
 
        
