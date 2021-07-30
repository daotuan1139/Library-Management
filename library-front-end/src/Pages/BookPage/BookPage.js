import React, { useEffect, useState } from 'react';
import { Link } from "react-router-dom";
import './BookList.css';
import callApi from '../../API/callAPI';


const BookPage = () => {

    const [books, setBooks] = useState([]);

    useEffect(() => {

        callApi('Book', 'GET').then(response => {
            console.log('response', response);
            setBooks(response.data);
        })
    }, []);

    return (
        <div>
            <center>
                <button style={{ marginBottom: 20 }}>
                    <Link to={`/createBook`}> Create </Link>
                </button>
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
                                <th><Link to={`/editBook/${book.bookID}`}> Update </Link></th>
                                <th><Link to={`/deleteBook/${book.bookID}`}> Delete </Link></th>
                            </tr>
                        ))}
                    </tbody>

                </table>
            </center>
        </div>
    );
};
export default BookPage;