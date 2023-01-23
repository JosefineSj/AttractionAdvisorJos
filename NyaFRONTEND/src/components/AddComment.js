import React, { useState } from 'react';

function AddComment({attractionId, userId}) {
  const [comment, setComment] = useState('');


  const handleSubmit = (event) => {
    event.preventDefault();
    // Perform sign-in logic here, such as sending a request to a server
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ AttractionId: {attractionId}, UserId: {userId}, Commentary: {comment} })
    };
    fetch('https://reqres.in/api/posts', requestOptions)
        .then(response => response.json())
        //.then(data => this.setState({ postId: data.id }))
        //.then(data => console.log(data));
        //console.log(formData);


    //console.log(username, password);
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Kommentera sevärdhet:</h2>
      <p>AttractionId:{attractionId}, UserId: {userId}</p>
      <label>
        Comment:
        <input type="textarea" value={comment} onChange={(e) => setComment(e.target.value)} />
      </label>
      <br />
      <button type="submit">Publish</button>
    </form>
  );
}

export default AddComment;