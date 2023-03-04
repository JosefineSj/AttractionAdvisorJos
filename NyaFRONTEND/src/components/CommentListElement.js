import '../pages/attractions.css';



const CommentListElement = ({ id, user, comment }) => {
    return (
        <div className="flexItemComment" key={id}>
            <p id='CommentListElementUser'>{user}</p>
            <p id='CommentListElementComment'>{comment}</p>
        </div>
    )
}

export default CommentListElement;