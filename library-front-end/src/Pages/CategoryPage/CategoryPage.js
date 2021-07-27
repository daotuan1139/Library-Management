import axios from 'axios';
import React, { useEffect, useState } from 'react';
import CategoryApi from '../../API/CategoryApi';

const PostPage = () => {

    const [categories, setCategories] = useState([]);

    useEffect(() => {
        const fetchCategories = () =>{
            try{
                const response = CategoryApi.getAll();
                console.log("response",response);
                setCategories(response.data);
            }catch(error){
                console.log('Failed to to fetch categories ', error);
            }
        }
        fetchCategories();
    }, []);

    return (
        <div>
            <center>
                <table>
                    <thead>
                        <tr>
                            <th>Book ID </th>
                            <th>Book Name</th>
                        </tr>
                    </thead>
                   
                </table>
            </center>
        </div>
    );
};
export default PostPage;