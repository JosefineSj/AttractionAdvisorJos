import React from 'react';
import { useContext } from 'react';
import { Link, useMatch } from 'react-router-dom';
import userData from "./userData";
import { UserContext } from './App';

function Navbar() {
  const { state: user, dispatch } = useContext(UserContext);

  const onClick = () => {
    dispatch({ type: 'USER', payload: false });
    userData.id = 0;
    userData.userName = null;
  }

  return (
    <nav className='navbar'>
      <Link to='/' className='site-title'>Attraction Advisor</Link>
      <ul>
        {
          user ?
            <>
              <div className="dropdown">
                <button className="drop-btn">My Page
                  <i className="fa fa-caret-down"></i></button>
                <div className="dropdown-content">
                  <NavbarItem to='/add-attraction'>Add Attraction</NavbarItem>
                  <NavbarItem to='/my-uploads'>My Uploads</NavbarItem>
                </div>
              </div>

              <NavbarItem to='/attractions'>Attractions</NavbarItem>
              <NavbarItem to='/log-out' onClick={onClick}>Sign Out</NavbarItem>
            </> :
            <>
              <NavbarItem to='/attractions'>Attractions</NavbarItem>
              <NavbarItem to='/signup'>Sign Up</NavbarItem>
              <NavbarItem to='/login'>Sign In</NavbarItem>
            </>
        }
      </ul>
    </nav>
  );
}


export default Navbar;

// move NavbarItem to seperate file.
function NavbarItem({ pathname, children, ...props }) {

  // const resolvedPath = useResolvedPath(pathname)
  // TODO test if useMatch({ path: pathname, end: true }) works
  const isActive = useMatch({ path: pathname, end: true })

  return (
    <li className={isActive === pathname ? "active" : ""}>
      <Link to={pathname} {...props}>
        {children}
      </Link>
    </li>
  )
}




