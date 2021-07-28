import axios from 'axios';
import * as Config from './../Constant/Config';

export default function callApi(endpoint, method = 'GET'){
    return axios({
        method: method,
        url: `${Config.API_URL}/${endpoint}`,

    }).catch(err => {
        console.log(err);
    });
};