import Home from '../../Components/Home';
import React, {useState, useEffect} from 'react';
import axios from 'axios';

const HomePage = ({ currentUser }) => {
    const [user, setUser] = useState({
        userID: null,
        userEmail: null,
        userName: '',

    });
    useEffect(() => {
        let didCancel = false;
        axios.get(`https://localhost:5001/api/User/${currentUser.userID}`)
            .then((response) => {
                if (!didCancel) {
                    console.log("response", response)
                    setUser({
                        userEmail: response.data.userEmail,
                        userId: response.data.userId,
                        userName: response.data.userName,
                    })
                }
            });
        return () => didCancel = true;
    }, [currentUser.userID, currentUser.userEmail, currentUser.userName])
    return (
        <div style={{ backgroundColor: 'purple' }}>
            <center>
                <h1 style={{ color: 'white' }}> Assignment ReactJS </h1>
            </center>
            <center>
                <Home 
                    name= {user.userName}
                    email = {user.userEmail}
                    address = '1381 Giai Phong'
                />
            </center>
        </div>
    );
};
export default HomePage;