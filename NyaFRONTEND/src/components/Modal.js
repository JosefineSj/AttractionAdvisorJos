import React, { useState, setState } from "react";
import "./modal.css";
import AddComment from "./AddComment";

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
      <button onClick={toggleModal} className="btn-modal">
        View attraction
      </button>

      {
        <div className="modal">
          <div onClick={toggleModal} className="overlay"></div>
          <div className="modal-content">
            <div
              className="flexItemAttraction">
              <p>{`${city}, ${name}`}</p>
              <div>{description}</div>
              <img src={`${pictureLink}`} alt="trt" />
            </div>
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
