import { useState, useEffect } from 'react';
import CommentList from './CommentList';
import '../pages/attractions.css';


const Comments = ({commentslist}) => {
    
  return(
      <div> 
        <div className='commentHeader'>
            <p id='commentHeaderHeadline'>Comments</p>
            <p id='commentHeaderParagraf'>{commentslist.length} comments</p>
        </div>

        <CommentList comments = {commentslist} />
      </div>
  )
}

export default Comments;