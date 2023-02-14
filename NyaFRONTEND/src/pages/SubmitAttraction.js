import React, { useState } from 'react';
import userData from '../userData';
import ApiFetch from '../webService/WebApi';
import './submitAttraction.css';
import {useNavigate} from "react-router-dom";




function SubmitAttraction() {
  const navigate = useNavigate();

  const [name, setName] = useState('');
  const [city, setCity] = useState('');
  const [description, setDescription] = useState('');
  const [picture, setPicture] = useState('');

  const handleSubmit = async (event) => {event.preventDefault(); 
  // Perform sign-in logic here, such as sending a request to a server
  const data = await ApiFetch('/Attraction', 'POST', {name: name, city: city, description: description, imageSource: picture, userId: userData.id });
  if(data != null) {
    alert("Your attraction is uploaded!");
    navigate("/my-uploads");
  }

  console.log("Posted?")
};
  
  return (
    <>
    <div className="SubmitAttraction">

    <form className="formController" onSubmit={handleSubmit} action="action_page.php">
    <div className="submitAttractionForm">

     <div className="submitAttractionHeader">
            <h1>Register new attraction:</h1>
            <hr />
     </div>

     <div className="submitAttractionDiv">
            <label for="name">
              <b>Name: </b>{" "}
            </label>
            <input
              className="inputSubmitAttraction"
              type="text"
              placeholder="Name of the attraction..."
              value={name}
              onChange={(e) => setName(e.target.value)}
              required
            />
          </div>
          <br />
          <div className="submitAttractionDiv">
            <label for="city">
              <b>City: </b>{" "}
            </label>
            <input
              className="inputSubmitAttraction"
              type="text"
              placeholder="In which city..."
              value={city}
              onChange={(e) => setCity(e.target.value)}
              required
            />
          </div>
      <br />

      <div className="submitAttractionDiv">
            <label for="description">
              <b>Description: </b>{" "}
            </label>
            <input
              className="inputSubmitAttraction"
              type="text"
              placeholder="Describe this place..."
              value={description}
              onChange={(e) => setDescription(e.target.value)}
              required
            />
          </div>
      <br />

      <div className="submitAttractionDiv">
            <label for="picture">
              <b>Upload picture: </b>{" "}
            </label>
            <input
              className="inputSubmitAttraction"
              type="text"
              placeholder="Paste your picture address..."
              value={picture}
              onChange={(e) => setPicture(e.target.value)}
              required
            />
          </div>

          <div className="clearfix">
            <button className="signupbtn" type="submit">Publish</button>
          </div>
    </div>
    </form>
    </div>
    </>
  );
}

export default SubmitAttraction;