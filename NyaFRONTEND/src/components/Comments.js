import { useState, useEffect } from 'react';
import CommentList from './CommentList';
import '../pages/attractions.css';


const Comments = () => {
  
    const [comments, setComments] = useState([]);

    useEffect(() => {
        fetch('dataComment.json'
            ,{
               headers : { 
                 'Content-Type': 'application/json',
                 'Accept': 'application/json'
                }
             }
             )
             .then((response) => response.json())
             .then((commentsResponse) => setComments(commentsResponse))
      }, []);
 
      
  return(
      <div> 
        <div className='commentHeader'>
            <p id='commentHeaderHeadline'>Comments</p>
            <p id='commentHeaderParagraf'>{comments.length} comments</p>
        </div>

        <CommentList comments = {comments} />
      </div>
  )
}

export default Comments;