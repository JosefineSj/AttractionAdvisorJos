import { Component } from "react";

class AttractionListElement extends Component {
    render() {
        const {id, name, email} = this.props
        return (
            <div key={id}>
                <img src={`https://robohash.org/${id}?set=set2&size=180x180`} alt="trt"  />
                <h1>{name}</h1> 
                <p>{email}</p>
              </div> 
        )
    }

}

export default AttractionListElement;