import { Component } from "react";
import AttractionListElement from "./AttractionListElement";

class ListOfAttractions extends Component {

    render() {
        const {places } = this.props;

        return (
            places.map((place) => {
              return (
              <AttractionListElement  id={place.id} name={place.name} email={place.email} /> 
              )
            })
          )
    }
}

export default ListOfAttractions