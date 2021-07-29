import React, { useEffect, useState } from 'react';
import './BorrowedBookList.css';
import callApi from '../../API/callAPI';


const BorrowedBookPage = () => {

    const [requests, setRequests] = useState([]);

    useEffect(() => {

        callApi('Request','GET').then(response => {
            console.log('response', response);
            setRequests(response.data);
        })
    }, []);

    return (
        <div>
            <center>
                <table>
                    <thead>
                        <tr>
                            <th>Book Borroed ID </th>
                            <th>User Borroed ID</th>
                            <th>Date Request</th>
                            <th>Status </th>
                            <th>Admin Approved </th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {requests.map(book => (
                            <tr key={book.bookID}>
                                <td>{book.bookID}</td>
                                <td>{book.userID}</td>
                                <td>{book.dateRequest}</td>
                                <td>{book.status}</td>
                                <td>{book.adminApproved}</td>
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
export default BorrowedBookPage;