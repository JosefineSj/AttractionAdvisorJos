import '../pages/attractions.css'; 
import "./modal.css";
import Modal from "./Modal";
import React, { useState } from "react";


const AttractionListElement = ({id, name, pictureLink, city, description, likes, dislikes, updatePlaces}) => { 
  
    const [showModal, setShowModal] = useState(false);
    return(  
             
    <>
     <div className="flexItemAttraction" key={id} onClick={() => setShowModal(true)}>
        <p>{`${city}, ${name}`}</p>
        <img src={`${pictureLink}`}
             alt=''
             onError={event => {
          event.target.src = "Bakelser.jpg"
          event.onerror = null
        }}/>
         <div className="buttonsRating">
        <div>
            <img className="ratingImg"  src="https://em-content.zobj.net/source/microsoft-teams/337/thumbs-up_1f44d.png"  alt=""/>
            <p id="likeCount">{likes}</p>
        </div>

        <div>
            <img className="ratingImg" src="https://em-content.zobj.net/source/microsoft-teams/337/thumbs-down_1f44e.png" alt=""/>
            <p id="dislikeCount">{dislikes}</p>
        </div>
        
    </div>
     </div> 
        {showModal && <Modal hideModal = {() => setShowModal(false)}  pictureLink = {pictureLink} name = {name} city = {city} description = {description} id= {id} updatePlaces={updatePlaces}/>}
    
    </>
)}

export default AttractionListElement;


  


