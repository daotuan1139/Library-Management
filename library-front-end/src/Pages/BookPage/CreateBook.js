import axios from 'axios';
import React, { useEffect, useState } from 'react';
import './BookList.css';
import callApi from '../../API/callAPI';


const CreateBook = () => {
    const [bookName, setBookName] = useState("");
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const handleCreate = () => {
        setError(null);
        setLoading(true);

        callApi(`Book`, 'POST', { bookName: bookName.value })
            .then(response => {
                setLoading(false);

                console.log(response.data.bookName);
                setBookName(response.data.bookName);

            }).catch(error => {
                setLoading(false);
            });
    }
    return (
        <div>
            <center>
                <h3>Create</h3>
                <br />
                <table>
                    <tr>
                        <th>Book name </th>
                        <th><input type="text" {...bookName} /></th>
                    </tr>
                </table>
                <br />
                <input type="submit" onClick={handleCreate} value="Create"/>

            </center>
        </div>
    );
}

export default CreateBook;