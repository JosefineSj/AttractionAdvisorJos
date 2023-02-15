import React from 'react';
import {useContext} from 'react';
import {Link, useMatch, useResolvedPath} from 'react-router-dom';
import userData from "./userData";
import {UserContext} from './App';

function Navbar() {

const {state, dispatch} = useContext(UserContext);
console.log(state);
const RenderMenu = () => {
  if(state){
    return(
      <>
         
     <div className="dropdown">
       <button className="drop-btn">My Page 
       <i className="fa fa-caret-down"></i></button>
      <div className="dropdown-content">
        <CustomLink to='/add-attraction'>Add Attraction</CustomLink>
        <CustomLink to='/my-uploads'>My Uploads</CustomLink>
      </div>
     </div> 

        <CustomLink to='/attractions'>Attractions</CustomLink>
        <CustomLink to='/log-out' onClick={() => {dispatch({type: 'USER', payload: false}); userData.id = 0; userData.userName = null}}>Sign Out</CustomLink>
    
      </>
    )
  }
  else{
    return(
      <>
        <CustomLink to='/attractions'>Attractions</CustomLink>
        <CustomLink to='/signup'>Sign Up</CustomLink>
        <CustomLink to='/login'>Sign In</CustomLink>
      </>
    )
  }

}

  return (   
    <nav className='navbar'>
      <Link to='/' className='site-title'>Attraction Advisor</Link>
      <ul>
        <RenderMenu/>
      </ul>
    </nav> 
  );
}


export default Navbar;

function CustomLink({to, children, ...props}){

  const {state, dispatch} = useContext(UserContext);

  const resolvedPath =useResolvedPath(to)
  const isActive = useMatch({path: resolvedPath.pathname, end: true})

 

  return(
    <li className={isActive === to ? "active" : ""}>
      <Link to={to} {...props}>
        {children}
        </Link>
    </li>
    
  )
}




