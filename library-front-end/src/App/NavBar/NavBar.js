import React from 'react';
import { Link, Redirect } from "react-router-dom";
import axios from 'axios';
import { Button } from 'react-bootstrap';

const style = {
    color: 'white',
}
const listyle = {
    margin: 45,
    display: 'inline-block'
}
const Navbar = ({ isUserLoggedIn, logout }) => {
    return (
        <div>
            <center>
                <ul style={style} >
                    <li style={listyle}>
                        <Link to="/">Home page</Link>
                    </li>
                    <li style={listyle}>
                        <Link to="/book">Books page</Link>
                    </li>
                    <li style={listyle}>
                        <Link to="/category">Category page</Link>
                    </li>
                    <li style={listyle}>
                        <Link to="/borrowed">Borrowed book page</Link>
                    </li>
                    <li style={listyle}>
                        {!isUserLoggedIn && (
                            <Link to="/login">Login page</Link>
                        )}
                        {isUserLoggedIn && (
                            <div>
                                <Button style={{ paddingBottom: 0, paddingTop: 0 }} className="btn-primary" onClick={() => {
                                    logout();
                                    axios.defaults.headers.common['Authorization'] = '';
                                }}
                                >
                                    Logout
                                </Button>
                                <Redirect to='/' />
                            </div>
                        )}
                    </li>
                </ul>
            </center>
        </div>
    );
};

export default Navbar;