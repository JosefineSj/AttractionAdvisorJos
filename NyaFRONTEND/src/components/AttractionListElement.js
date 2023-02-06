import '../pages/attractions.css'; 
import "./modal.css";
import Modal from "./Modal";
import React, { useState } from "react";


const AttractionListElement = ({id, name, pictureLink, city, description}) => { 
    const [showModal, setShowModal] = useState(false);
    return(  
             
    <>
     <div className="flexItemAttraction" key={id} onClick={() => setShowModal(true)}>
        <p>{`${city}, ${name}`}</p>
        <img src={`${pictureLink}`} alt="trt" />
     </div> 
        {showModal && <Modal hideModal = {() => setShowModal(false)} pictureLink = {pictureLink} name = {name} city = {city} description = {description} id= {id}/>}
    
    </>
)}

export default AttractionListElement;


  


