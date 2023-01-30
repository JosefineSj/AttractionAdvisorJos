import SubmitAttraction from './SubmitAttraction';
import MyAttractions from "./MyAttractions";
import MyComments from "./MyComments";
import MyAccount from "./MyAccount";
import './myPageStyles.css'; 
import SecondNavbar from "./SecondNavbar";
import { Route, Routes } from 'react-router-dom';


export default function MyPage() {
    return (
    <>

    <SecondNavbar/>
    <div className='myPageContainer'>
      <Routes>
        <Route path="/add-attraction" element={<SubmitAttraction />}/>
        <Route path="/my-attractions" element={<MyAttractions />}/>
        <Route path="/my-comments" element={<MyComments />}/>
        <Route path="/my-comments" element={<MyAccount />}/>

      </Routes>
     
    
    </div>
    
    
    
    
    </>
   
);
}

