import AttractionListElement from "./AttractionListElement";

const ListOfAttractions = ({places, updatePlaces}) => (
  places.map((place) => {
    return (
      <AttractionListElement likes={place.likes} dislikes={place.dislikes} key={place.id}  id={place.id} name={place.name} pictureLink={place.imageSource} city={place.city} description={place.description} updatePlaces={updatePlaces}  />   
    )
    })
  )
    
export default ListOfAttractions;