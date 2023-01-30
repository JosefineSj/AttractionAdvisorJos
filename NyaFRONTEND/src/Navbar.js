import React from 'react';
import {Link, useMatch, useResolvedPath} from 'react-router-dom';

function Navbar() {
  return (   
    <nav className='navbar'>
      <Link to='/' className='site-title'>Attraction Advisor</Link>
      <ul>
        <CustomLink to='/attractions'>Attractions</CustomLink>
        <CustomLink to='/signup'>Sign Up</CustomLink>
        <CustomLink to='/login'>Sign In</CustomLink>

     <div className="dropdown">
       <button className="dropbtn">My Page<i class="fa fa-caret-down"></i></button>
      <div class="dropdown-content">
        <CustomLink to='/my-account'>My Account</CustomLink>
        <CustomLink to='/add-attraction'>Add Attraction</CustomLink>
        <CustomLink to='/my-uploads'>My Uploads</CustomLink>
        <CustomLink to='/my-comments'>My Comments</CustomLink>
      </div>
     </div> 

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




