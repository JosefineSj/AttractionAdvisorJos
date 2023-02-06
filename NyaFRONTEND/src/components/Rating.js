import ApiFetch from "../webService/WebApi";
import userData from "../userData";
import { useState, useEffect } from "react";

export default function Rating({attractionId, likes, dislikes}) {
    const [numberOfthumbsDown, SetNumberOfthumbsDown] = useState(0);
    const [numberOfthumbsUp, SetNumberOfthumbsUp] = useState(0);

    useEffect(() => {
        SetNumberOfthumbsUp(likes)
      }, [likes]);
    
    useEffect(() => {
        SetNumberOfthumbsDown(dislikes)
      }, [dislikes]);







    const thumbsUp = async () => {
        await ApiFetch('/Rating', 'POST', {attractionId:  attractionId, userId: `${userData.id}`, value: 1 });
        SetNumberOfthumbsUp(numberOfthumbsUp + 1);
    }

    const thumbsDown = async () => {
        await ApiFetch('/Rating', 'POST', {attractionId:  attractionId, userId: `${userData.id}`, value: 2 });
        SetNumberOfthumbsDown(numberOfthumbsDown + 1);
    }

    return (
    
    <div className="buttons">
        <div>
            <a href="#" onClick={thumbsUp}><img className="ratingImg"  src="like.png"  alt=""/></a>
            <p id="likeCount">{numberOfthumbsUp}</p>
        </div>

        <div>
            <a href="#" onClick={thumbsDown}><img className="ratingImg" src="dislike.png" alt=""/></a>
            <p id="dislikeCount">{numberOfthumbsDown}</p>
        </div>
        
    </div>
    
    
);
}