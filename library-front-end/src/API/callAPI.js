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

export function GET_BY_ID(endpoint,id){
    return callApi(endpoint+"/"+id,"GET");
}

export function POST_ADD(endpoint,data){
    return callApi(endpoint,"POST",data);
}
export function PUT_EDIT(endpoint,data){
    return callApi(endpoint,"PUT",data);
}
export function DELETE_BY_ID(endpoint,data){
    return callApi(endpoint,"DELETE",data);
}
