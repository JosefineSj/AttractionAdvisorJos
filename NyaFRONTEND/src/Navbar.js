import React from 'react';
import {Link, useMatch, useResolvedPath} from 'react-router-dom';

function Navbar() {
  return (   
    <nav className='navbar'>
      <Link to='/' className='site-title'>Attraction Advisor</Link>
      <ul>

     <div className="dropdown">
       <button className="drop-btn">My Page 
       <i className="fa fa-caret-down"></i></button>
      <div className="dropdown-content">
        <CustomLink to='/add-attraction'>Add Attraction</CustomLink>
        <CustomLink to='/my-uploads'>My Uploads</CustomLink>
      </div>
     </div> 

        <CustomLink to='/attractions'>Attractions</CustomLink>
        <CustomLink to='/signup'>Sign Up</CustomLink>
        <CustomLink to='/login'>Sign In</CustomLink>
      </ul>
    </nav> 
  );
}



export default Navbar;

function CustomLink({to, children, ...props}){
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




