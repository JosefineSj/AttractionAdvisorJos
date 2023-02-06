import React from 'react';
import Navbar from './Navbar';
import Home from './pages/Home';
import SignUp from './pages/SignUp';
import LogIn from './pages/LogIn';
import Attractions from './pages/Attractions';
import { Route, Routes } from 'react-router-dom';
import SubmitAttraction from './pages/SubmitAttraction';
import MyUploads from './pages/MyUploads';

/*import AddComment from './components/AddComment'; */


function App() {
 
  return (
    <>
    <Navbar /> 
    <div className='container'>
      <Routes>
        <Route path="/" element={<Home />}/>
        <Route path="/attractions" element={<Attractions />}/>
        <Route path="/signup" element={<SignUp />}/>
        <Route path="/login" element={<LogIn />}/>
        <Route path="/add-attraction" element={<SubmitAttraction />}/>
        <Route path="/my-uploads" element={<MyUploads />}/>

      </Routes>
     
    
    </div>     
      
    </>

    /*   <AddComment attractionId={1} userId={1}  />*/

  );
}

export default App;
