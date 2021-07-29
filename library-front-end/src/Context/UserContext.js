import React, { createContext } from 'react';

const UserContext = createContext({
    email: null,
    password: null,
});

export default UserContext;