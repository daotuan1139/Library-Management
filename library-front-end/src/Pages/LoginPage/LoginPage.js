import React, { useState } from 'react';
import axios from 'axios';
import { setUserSession } from '../../API/common';
import callApi from '../../API/callAPI';

const useFormInput = (initialValue) => {
  const [value, setValue] = useState(initialValue);

  const handleChange = e => {
    setValue(e.target.value);
  }
  return {
    value,
    onChange: handleChange
  }
}

const LoginPage = ({setCurrentUser}) => {
  const [loading, setLoading] = useState(false);
  const email = useFormInput('');
  const password = useFormInput('');
  const [error, setError] = useState(null);

  const handleLogin = () => {
    setError(null);
    setLoading(true);

    callApi(`Login`,'POST',{ userEmail: email.value, userPassword: password.value } )
    .then(response => {
      setLoading(false);
      setUserSession(response.data.userID, response.data.userEmail);

      setCurrentUser({
        userID: response.data.userID,
        userEmail: response.data.userEmail,
      })
      axios.defaults.headers.common["Authorization"] = response.data.userID;
      sessionStorage.setItem('token', JSON.stringify(response.data));

      console.log(response.data);

      alert(JSON.stringify(response.data, null, 2));

    }).catch(error => {
      setLoading(false);
    });
  }

  return (
    <div>
      <center>
        <h3>Login</h3>
        <br />
        <table>
          <tr>
            <th>Email </th>
            <th><input type="text" {...email} autoComplete="new-password" /></th>
          </tr>
          <tr style={{ marginTop: 10 }}>
            <th>Password </th>
            <th><input type="password" {...password} autoComplete="new-password" /></th>
          </tr>

        </table>
        {error && <><small style={{ color: 'red' }}>{error}</small><br /></>}<br />
        <input type="submit" value={loading ? 'Loading...' : 'Login'} onClick={handleLogin} disabled={loading} /><br />

      </center>
    </div>
  );
}

export default LoginPage;