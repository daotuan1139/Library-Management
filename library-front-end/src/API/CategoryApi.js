import axiosClient from "./axiosClient";

const CategoryApi = {
    getAll: () => {
        const url = '/Category';
        return axiosClient.get(url);
    },
}
export default CategoryApi;