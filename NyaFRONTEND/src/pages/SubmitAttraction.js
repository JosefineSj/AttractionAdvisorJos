import React, { useState } from 'react';


function SubmitAttraction() {
  const [name, setName] = useState('');
  const [city, setCity] = useState('');
  const [description, setDescription] = useState('');
  const [picture, setPicture] = useState('');


  const handleSubmit = (event) => {
    event.preventDefault();
    // Perform sign-in logic here, such as sending a request to a server
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Name: {name}, City: {city}, Description: {description}, Picture: {picture} })
    };
    fetch('https://reqres.in/api/posts', requestOptions)
        .then(response => response.json())
        //.then(data => this.setState({ postId: data.id }))
        //.then(data => console.log(data));
        //console.log(formData);


    //console.log(username, password);
  };

  return (
    <>
    <form onSubmit={handleSubmit}>
      <h2>Register new attraction:</h2>
      <label>
        Name:
        <input type="text" value={name} onChange={(e) => setName(e.target.value)} />
      </label>
      <br />
      <label>
        City:
        <input type="text" value={city} onChange={(e) => setCity(e.target.value)} />
      </label>
      <br />
      <label>
        Description:
        <input type="text" value={description} onChange={(e) => setDescription(e.target.value)} />
      </label>
      <br />
      <label>
        Picture:
        <input type="text" value={picture} onChange={(e) => setPicture(e.target.value)} />
      </label>
      <br />
      <button type="submit">Publish</button>
    </form>
    
    </>
  );
}

export default SubmitAttraction;