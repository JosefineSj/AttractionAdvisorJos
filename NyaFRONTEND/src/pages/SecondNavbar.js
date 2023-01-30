import React from 'react';
import {Link, useMatch, useResolvedPath} from 'react-router-dom';

function SecondNavbar() {
  return (   
    <nav className='secondNavbar'>
      <ul>
        <CustomLink to='/add-attraction'>Add Attraction</CustomLink>
        <CustomLink to='/my-attractions'>My Uploads</CustomLink>
        <CustomLink to='/my-comments'>My Comments</CustomLink>
        <CustomLink to='/my-account'>My Account</CustomLink>

      </ul>
    </nav> 
  );
}



export default SecondNavbar;

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
