import React from 'react';
import Navbar from './Navbar';
import Home from './pages/Home';
import SignUp from './pages/SignUp';
import LogIn from './pages/LogIn';
import MyPage from './pages/MyPage';
import Attractions from './pages/Attractions';
import { Route, Routes } from 'react-router-dom';
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
        <Route path="/my-page" element={<MyPage />}/>
      </Routes>
     
    
    </div>     
      
    </>

    /*   <AddComment attractionId={1} userId={1}  />*/

  );
}

export default App;
