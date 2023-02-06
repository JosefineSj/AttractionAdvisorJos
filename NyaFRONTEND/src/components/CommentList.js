import React, { useState, useEffect } from 'react';
import CommentListElement from './CommentListElement';


const CommentList = ({comments}) => {

          return (
            

            comments.map((comment) => {
                return (
                  <CommentListElement key={comment.id} id={comment.id}  user={comment.username} comment={comment.comment}/>
                )
                })
    );
}

export default CommentList;