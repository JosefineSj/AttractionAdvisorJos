import React, { useReducer, createContext } from 'react';
import Navbar from './Navbar';
import Home from './pages/Home';
import SignUp from './pages/SignUp';
import LogIn from './pages/LogIn';
import Attractions from './pages/Attractions';
import { Route, Routes } from 'react-router-dom';
import SubmitAttraction from './pages/SubmitAttraction';
import MyUploads from './pages/MyUploads';

import {initialState, reducer} from '../src/reducer/UseReducer';

/*import AddComment from './components/AddComment'; */

export const UserContext = createContext(); 

const Routing = () =>{
  return(
    <div className='container'>
    <Routes>
      <Route path="/" element={<Home />}/>
      <Route path="/attractions" element={<Attractions />}/>
      <Route path="/signup" element={<SignUp />}/>
      <Route path="/login" element={<LogIn />}/>
      <Route path="/add-attraction" element={<SubmitAttraction />}/>
      <Route path="/my-uploads" element={<MyUploads />}/>
      <Route path="/log-out" element={<Home />}/>


    </Routes>
    </div> 

  )
}

function App() {

  const [state, dispatch] = useReducer(reducer, initialState);
 
   return(
      <>
      <UserContext.Provider value={{state, dispatch}}>
    
      <Navbar /> 
      <Routing />  
      
    </UserContext.Provider>   
        
      </>

   )

};

export default App;
