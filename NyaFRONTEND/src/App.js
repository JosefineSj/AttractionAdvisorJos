import React from 'react';
import Navbar from './Navbar';
import Home from './pages/Home';
import SignUp from './pages/SignUp';
import LogIn from './pages/LogIn';
import { Route, Routes } from 'react-router-dom';
import SubmitAttraction from './components/SubmitAttraction';
import AddComment from './components/AddComment';
import Attraction from './components/Attraction'; 

function App() {
 
  return (
    <>
    <Navbar /> 
    <div className="container">
      <Routes>
        <Route path="/" element={<Home />}/>
        <Route path="/signup" element={<SignUp />}/>
        <Route path="/login" element={<LogIn />}/>
      </Routes>

      <SubmitAttraction />
      <AddComment attractionId={1} userId={1}  />
      <Attraction />
    </div>

     
      
    </>

  );
}

export default App;
