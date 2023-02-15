import AttractionListElement from "./AttractionListElement";

const ListOfAttractions = ({places}) => (
  places.map((place) => {
    return (
      <AttractionListElement likes={place.likes} dislikes={place.dislikes} key={place.id}  id={place.id} name={place.name} pictureLink={place.imageSource} city={place.city} description={place.description}  />   
    )
    })
  )
    
export default ListOfAttractions;