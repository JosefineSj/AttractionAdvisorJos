const AttractionListElement = ({id, name, pictureLink, city, description}) => (       
    <div key={id}>
        <h1>{name}</h1> 
        <img src={`${pictureLink}`} alt="trt"  />
        <p>{city}</p>
        <p>{description}</p>
    </div> 
)

export default AttractionListElement;