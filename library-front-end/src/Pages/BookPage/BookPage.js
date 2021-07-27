import axios from 'axios';
import React, { useEffect, useState } from 'react';
import BookApi from '../../API/BookApi';

const PostPage = () => {

    const [books, setBooks] = useState([]);

    useEffect(() => {
        const fetchBooks = () =>{
            try{
                const response = BookApi.getAll();
                console.log('response', response);
                setBooks(response.data);
            }catch(error){
                console.log('Failed to to fetch books ', error);
            }
        }
        fetchBooks();
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