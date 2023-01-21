import { useState, useEffect } from 'react';
import ListOfAttractions from './ListOfAttractions';
import SearchBox from './search-box';




const Attraction = () => {
  
  const [searchField, setSearchField] = useState('');
  const [places, setPlaces] = useState([]);

  const onSearchChange = (event) => { 
    const searchFieldString = event.target.value.toLowerCase()
    setSearchField(searchFieldString);  
    }

    const filteredPlaces = places.filter((place) => {
      console.log(places)
      return place.city.toLowerCase().includes(searchField)})

      useEffect(() => {
        fetch('data.json'
            ,{
               headers : { 
                 'Content-Type': 'application/json',
                 'Accept': 'application/json'
                }
             }
             )
             .then((response) => response.json())
             .then((placesResponse) => setPlaces(placesResponse))
      }, []);

      
      
  return(
      <div>
        <h1>Search attraction:</h1>    
        <SearchBox className='SearchBox' placeholder='Sök plats' onChangeHandler={onSearchChange} />
        <ListOfAttractions places = {filteredPlaces} />
      </div>
  )
}

export default Attraction;