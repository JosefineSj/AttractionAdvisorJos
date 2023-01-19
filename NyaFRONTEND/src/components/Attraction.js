import { Component } from 'react';
import ListOfAttractions from './ListOfAttractions';
import SearchBox from './search-box';

class Attraction extends Component {

  constructor() {
    super();

    this.state = {
      places: [],
      searchField: ''
    };
  }

  componentDidMount() {
    fetch('https://jsonplaceholder.typicode.com/users')
      .then((respons) => respons.json())
      .then((places) => 
        this.setState(() => {
          return {places: places}
        }))
  }

  onSearchChange = (event) => { 
    const searchField = event.target.value.toLowerCase()
    
    this.setState(() => {
      return {searchField}
    });
    }

  render() {
    const {places, searchField} = this.state;
    const {onSearchChange} = this;
    const filteredPlaces = places.filter((place) => {
      return place.name.toLowerCase().includes(searchField)})

    return (
      <div>
        <h1>Sök sevärdhet</h1>    
        <SearchBox className='SearchBox' placeholder='Sök plats' onChangeHandler={onSearchChange} />
        <ListOfAttractions places = {filteredPlaces} />
      </div>
    );

  }
  
}

export default Attraction;