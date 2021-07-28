import axios from 'axios';
import React, { useEffect, useState } from 'react';
import './CategoryList.css';
import callApi from '../../API/callAPI';

const CategoryPage = () => {

    const [categories, setCategories] = useState([]);

    useEffect(() => {

        callApi('Category','GET').then(response => {
            console.log('response', response);
            setCategories(response.data);
        })
    }, []);


    return (
        <div>
            <center>
                <table>
                    <thead>
                        <tr>
                            <th>Category ID </th>
                            <th>Category Name</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {categories.map(category => (
                            <tr key={category.categoryID}>
                                <td>{category.categoryID}</td>
                                <td>{category.categoryName}</td>
                                <th>Update</th>
                                <th>Delet</th>

                            </tr>
                        ))}
                    </tbody>

                </table>
            </center>
        </div>
    );
};
export default CategoryPage;