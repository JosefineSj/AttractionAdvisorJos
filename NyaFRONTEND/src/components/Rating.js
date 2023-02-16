import ApiFetch from "../webService/WebApi";
import userData from "../userData";
import { useState, useEffect } from "react";

export default function Rating({attractionId, likes, dislikes, updatePlaces=async ()=>{}}) {
    const [numberOfThumbsDown, SetNumberOfThumbsDown] = useState(0);
    const [numberOfThumbsUp, SetNumberOfThumbsUp] = useState(0);

    useEffect(() => {
        SetNumberOfThumbsUp(likes)
      }, [likes]);
    
    useEffect(() => {
        SetNumberOfThumbsDown(dislikes)
      }, [dislikes]);


    const thumbsUp = async () => {
        await ApiFetch('/Rating', 'POST', {attractionId:  attractionId, userId: `${userData.id}`, value: 1 });
        await updatePlaces();
        const data = await ApiFetch(`/Attraction/${attractionId}`);
        SetNumberOfThumbsUp(data.likes);
    }

    const thumbsDown = async () => {
        await ApiFetch('/Rating', 'POST', {attractionId:  attractionId, userId: `${userData.id}`, value: 2 });
        await updatePlaces();
        const data = await ApiFetch(`/Attraction/${attractionId}`);
        SetNumberOfThumbsDown(data.dislikes);
    }

    return (
    
    <div className="buttonsRating">
        <div>
            <a href="#" onClick={thumbsUp}><img className="ratingImg"  src="https://em-content.zobj.net/source/microsoft-teams/337/thumbs-up_1f44d.png"  alt=""/></a>
            <p id="likeCount">{numberOfThumbsUp}</p>
        </div>

        <div>
            <a href="#" onClick={thumbsDown}><img className="ratingImg" src="https://em-content.zobj.net/source/microsoft-teams/337/thumbs-down_1f44e.png" alt=""/></a>
            <p id="dislikeCount">{numberOfThumbsDown}</p>
        </div>
        
    </div>
    
    
);
}