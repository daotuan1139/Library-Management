import React from 'react';

const Home = (props) => {

    const { name, email, address } = props;

    return (
        <div style={{color: 'white'}} >
            <h1>Hi {name}</h1>

            <h2>Email: {email} </h2>

            <h2>Address: {address} </h2>
        </div>
    )
}

export default Home;