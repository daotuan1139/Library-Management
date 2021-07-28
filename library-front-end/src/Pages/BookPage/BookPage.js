import axios from 'axios';
import React, { useEffect, useState } from 'react';
import './BookList.css';
import callApi from '../../API/callAPI';


const BookPage = () => {

    const [books, setBooks] = useState([]);

    useEffect(() => {

        callApi('Book','GET').then(response => {
            console.log('response', response);
            setBooks(response.data);
        })
    }, []);

    return (
        <div>
            <center>
                <table>
                    <thead>
                        <tr>
                            <th>Book ID </th>
                            <th>Book Name</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {books.map(book => (
                            <tr key={book.bookID}>
                                <td>{book.bookID}</td>
                                <td>{book.bookName}</td>
                                <th>Update</th>
                                <th>Delete</th>
                            </tr>
                        ))}
                    </tbody>

                </table>
            </center>
        </div>
    );
};
export default BookPage;