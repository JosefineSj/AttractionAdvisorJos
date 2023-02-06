import userData from '../userData';
import Attraction from '../components/Attraction';


export default function MyUploads() { 
    return (
    <>

    <div className="myAttractionContainer">
      <Attraction apiUrl = {`/Attraction/User/${userData.id}`} header = {'My Uploads'}/>
    </div>

    </>
    
);
}