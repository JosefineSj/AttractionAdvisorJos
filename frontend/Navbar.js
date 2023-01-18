import React from 'react';
import {Link, useMatch, useResolvedPath} from 'react-router-dom';

function Navbar() {
  return (   
    <nav className='navbar'>
      <Link to='/' className='site-title'>Attraction Advisor</Link>
      <ul>
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




