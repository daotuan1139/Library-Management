import axiosClient from "./axiosClient";

const BookApi = {
    getAll: (params) => {
        const url = '/Book';
        return axiosClient.get(url, {params});
    },
}
export default BookApi;