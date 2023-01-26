import React, { useState, setState } from "react";
import "./modal.css";
import AddComment from "./AddComment";
import Comments from "./Comments";
import Rating from "./Rating";

export default function Modal({
  hideModal,
  pictureLink,
  id,
  name,
  city,
  description,
}) {
  const [modal, setModal] = useState(false);

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
              <h1>{name}</h1>
              <p>{city}</p>
              <div>{description}</div>
              <img src={`${pictureLink}`} alt="trt"  id="modalImg"/>
            </div>
            <Rating />
            <Comments />
            <AddComment />
            <button className="close-modal" onClick={hideModal}>
              CLOSE
            </button>
          </div>
        </div>
      }
    </>
  );
}
