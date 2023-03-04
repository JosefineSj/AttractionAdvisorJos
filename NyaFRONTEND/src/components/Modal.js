import React, { useState, useEffect } from "react";
import "./modal.css";
import Comments from "./Comments";
import Rating from "./Rating";
import ApiFetch from "../webService/WebApi";
import userData from "../userData";
import { useNavigate } from "react-router-dom";


export default function Modal({ hideModal, id, updatePlaces }) {

  const navigate = useNavigate();
  const [showModal, setShowModal] = useState(false);
  const [attractionData, setAttractionData] = useState([]);
  const [comment, setComment] = useState('');

  async function fetchData() {
    const data = await ApiFetch(`/Attraction/${id}`);
    setAttractionData(data);
  }

  useEffect(() => {
    fetchData();
  }, [])


  const toggleModal = () => {
    setShowModal(!showModal);
  };

  useEffect(() => {
    if (showModal) {
      document.body.classList.add("active-modal");
      return
    }
    document.body.classList.remove("active-modal");
  }, [showModal])

  const handleSubmitAddComment = async (event) => {
    event.preventDefault();

    if (userData.userName === null) {
      alert("You need to be signed in to be able to add a comment");
      navigate('/login');
      return
    }

    await ApiFetch('/Comment', 'POST', { AttractionId: attractionData.id, UserId: userData.id, Commentary: `${comment}` });
    fetchData();
  };


  return (
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
            }} />
        </div>
        <Rating attractionId={id} likes={attractionData.likes} dislikes={attractionData.dislikes} updatePlaces={updatePlaces} />
        <Comments commentslist={attractionData.commentlist} />
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
  );
}