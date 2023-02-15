import React, { useState, useEffect, useCallback } from "react";
import "./modal.css";
import Comments from "./Comments";
import Rating from "./Rating";
import ApiFetch from "../webService/WebApi";
import userData from "../userData";
import {useNavigate} from "react-router-dom";


export default function Modal({hideModal, id}) {

  const navigate = useNavigate();

  const [modal, setModal] = useState(false);
  const [attractionData, setAttractionData] = useState([]);
  const [likes, setLikes] = useState(0);
  const [dislikes, setDislikes] = useState(0);
  const [commentlist, setCommentlist] = useState([]);
  const [comment, setComment] = useState('');
  console.log(id);

  useEffect(   () => {      
    async function fetchData() {
      const data = await ApiFetch(`/Attraction/${id}`);
      //await data.json();  
      setAttractionData(data);
      setDislikes(data.dislikes);
      setLikes(data.likes);
      setCommentlist(data.comments);
      console.log(commentlist);     
      }
      fetchData();
    }, [])

  
  const toggleModal = () => {
    setModal(!modal);
  };

  if (modal) {
    document.body.classList.add("active-modal");
  } else {
    document.body.classList.remove("active-modal");
  }

   const handleSubmitAddComment = async (event) => {
    event.preventDefault();
    if(userData.userName === null) {
       alert("You need to be signed in to be able to add a comment");
       navigate('/login');
      }
       else {
         await ApiFetch('/Comment', 'POST', {AttractionId: attractionData.id, UserId: userData.id, Commentary: `${comment}` });
         async function fetchData() {
          const data = await ApiFetch(`/Attraction/${id}`);
          setAttractionData(data);
          setDislikes(data.dislikes);
          setLikes(data.likes);
          setCommentlist(data.comments);
          console.log(commentlist);
   }      await fetchData();
 }
};

  return (
    <>
      {
        <div className="modal">
          <div onClick={toggleModal} className="overlay"></div>
          <div className="modal-content">
            <div
              className="modalBox">
              <h1>{attractionData.name}</h1>
              <p>{attractionData.city}</p>
              <div>{attractionData.description}</div>
              <img src={`${attractionData.imageSource}`}
              alt="trt"
              id="modalImg"
              onError={event => {
                event.target.src = "Bakelser.jpg"
                event.onerror = null
              }}/>
            </div>
            <Rating attractionId={id} likes={likes} dislikes={dislikes} />
            <Comments commentslist={commentlist}/>
            <form onSubmit={handleSubmitAddComment}>
              <div id='addCommentBox'>
                <textarea id='addCommentInput'
                          type="textarea"
                          placeholder='Your comment...'
                          value={comment} onChange={(e) => setComment(e.target.value)} />
                          <button id='addCommentBtn'
                                  type="submit">Publish comment
                          </button>
               </div>
            </form>
            <button className="close-modal" onClick={hideModal}>
              CLOSE
            </button>
          </div>
        </div>
      }
    </>
  );
}