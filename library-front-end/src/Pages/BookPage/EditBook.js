import React, { useEffect, useState } from 'react';
import './BookList.css';
import { PUT_EDIT, GET_BY_ID } from '../../API/callAPI';
import { Redirect, useParams } from 'react-router-dom';

const EditBook = () => {

    const [checkEdit, setCheckEdit] = useState(false);
    const { ID } = useParams();
    const [bookID, setBookID] = useState(0);
    const [bookName, setBookName] = useState(null);

    const handleChangeBookName = (event) => {

        setBookName(event.target.value)
    }

    useEffect(() => {

        GET_BY_ID(`Book`, ID).then(item => {

            setBookID(item.data.bookID)
            setBookName(item.data.bookName)

        })
    }, [])

    const handleEdit = (event) => {
        event.preventDefault();

        if (bookName !== "") {
            let editBook = {
                bookID: ID,
                bookName: bookName,
            }
            PUT_EDIT(`Book`, editBook).then(item => {
                setCheckEdit(true);
                alert("Edit success");
            })
        }
        else {
            alert("Wrong information");
        }
    }
    if (checkEdit) {
        return <Redirect to="/book" />
    }

    return (
        <div>
            <center>
                <h3>Edit</h3>
                <br />
                <table>
                    <tr>
                        <th>Book name </th>
                        <th><input type="text" onChange={handleChangeBookName} value={bookName} /></th>
                    </tr>
                </table>
                <br />
                <input type="button" onClick={handleEdit} value="Edit" />
            </center>
        </div>
    );
}

export default EditBook;