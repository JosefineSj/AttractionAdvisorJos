import React, { useState, useEffect, useCallback } from "react";
import "./modal.css";
import AddComment from "./AddComment";
import Comments from "./Comments";
import Rating from "./Rating";
import ApiFetch from "../webService/WebApi";
import userData from "../userData";

export default function Modal({hideModal, id,}) {
  const [modal, setModal] = useState(false);
  const [attraktionData, setAttraktionData] = useState([]);
  const [likes, setLikes] = useState(0);
  const [dislikes, setDislikes] = useState(0);
  const [commentlist, setCommentlist] = useState([]);
  console.log(id);

  useEffect(   () => {      
    async function fetchData() {
      const data = await ApiFetch(`/Attraction/${id}`);
      //await data.json();  
      setAttraktionData(data);
      setDislikes(data.dislikes);
      setLikes(data.likes);
      setCommentlist(data.comments);
      console.log(commentlist);     
      }
      fetchData();
    }, [])

    const wrapperSetCommentlistState = useCallback(val => {
      setCommentlist(val);
    }, [setCommentlist]);

  
  const toggleModal = () => {
    setModal(!modal);
  };

  if (modal) {
    document.body.classList.add("active-modal");
  } else {
    document.body.classList.remove("active-modal");
  }

  return (
    <>
      {
        <div className="modal">
          <div onClick={toggleModal} className="overlay"></div>
          <div className="modal-content">
            <div
              className="modalBox">
              <h1>{attraktionData.name}</h1>
              <p>{attraktionData.city}</p>
              <div>{attraktionData.description}</div>
              <img src={`${attraktionData.imageSource}`} alt="trt"  id="modalImg"/>
            </div>
            <Rating attractionId={id} likes={likes} dislikes={dislikes} />
            <Comments commentslist={commentlist}/>
            <AddComment attractionId={id} commentList={commentlist} setCommentList={wrapperSetCommentlistState}/>
            <button className="close-modal" onClick={hideModal}>
              CLOSE
            </button>
          </div>
        </div>
      }
    </>
  );
}