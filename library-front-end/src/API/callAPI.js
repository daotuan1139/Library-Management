import axios from 'axios';

let API_URL = 'https://localhost:5001/api';

export default function callApi(endpoint, method , body){
    return axios({
        method: method,
        url: `${API_URL}/${endpoint}`,
        data: body,

    }).catch(error => {
        console.log(error);
    });
};