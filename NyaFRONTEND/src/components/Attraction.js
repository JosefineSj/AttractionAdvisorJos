import { useState, useEffect } from 'react';
import ListOfAttractions from './ListOfAttractions';
import SearchBox from './search-box';
import ApiFetch from '../webService/WebApi';

const Attraction = ({apiUrl, header}) => {
  
  const [searchField, setSearchField] = useState('');
  const [places, setPlaces] = useState([]);

  const onSearchChange = (event) => { 
    const searchFieldString = event.target.value.toLowerCase()
    setSearchField(searchFieldString);  
    }

  const filteredPlaces = places.filter((place) => {
      return place.city.toLowerCase().includes(searchField)})

  useEffect(   () => {    
      console.log("Kallar på metod")  
      async function fetchData() {
        const data = await ApiFetch(apiUrl);  
        if(data) setPlaces(data);
        }
        fetchData()
      }, [apiUrl]);
 
      
  return(
      <div> 
        <div className='boxAroundSearchBox'>
          <SearchBox header = {header} className='SearchBox' placeholder='Search for a city...' onChangeHandler={onSearchChange} />
        </div>  

        <div className="attractionList">
          <ListOfAttractions places = {filteredPlaces} />

        </div>
      </div>
  )
}

export default Attraction;