import Attraction from '../components/Attraction';
import './attractions.css'; 


export default function Attractions() {
    return (
    <>

    <div className="attractionContainer">
      <Attraction apiUrl = {'/Attraction/'} header = {'All available attractions'}/> 
    </div>


    </>
    
);
}