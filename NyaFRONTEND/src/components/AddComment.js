import React, { useState, useRef } from 'react';
import userData from "../userData";
import ApiFetch from '../webService/WebApi';

function AddComment({attractionId, commentList, setCommentList}) {
  const [comment, setComment] = useState('');
  const [commentListAddComment, setCommentListAddComment] = useState([]);


  const handleSubmit = async (event) => {
    event.preventDefault();
    
    if(userData.userName === null) {
      alert("Du måste vara inlogad för att kommentera");
    }
     else {
      await ApiFetch('/Comment', 'POST', {AttractionId:  attractionId, UserId: userData.id, Commentary: `${comment}` });
      const newComment = {user: userData.userName, comment: comment  }
      setCommentListAddComment(commentListAddComment.push(newComment));
      setComment('')
    } 
  };


  return (
    <form onSubmit={handleSubmit}>
      <div id='addCommentBox'>
        <textarea id='addCommentInput' type="textarea" placeholder='Your comment...' value={comment} onChange={(e) => setComment(e.target.value)} />
        <button id='addCommentBtn' type="submit">Publish comment</button>
      </div>
    </form>
  );
}

export default AddComment;