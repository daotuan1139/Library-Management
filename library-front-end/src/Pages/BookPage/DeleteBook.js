import React, { useEffect, useState } from 'react';
import './BookList.css';
import { DELETE_BY_ID, GET_BY_ID } from '../../API/callAPI';
import { Redirect, useParams } from 'react-router-dom';

const DeleteBook = () => {

    const [checkDelete, setCheckDelete] = useState(false);
    const { ID } = useParams();
    const [bookID, setBookID] = useState(0);
    const [bookName, setBookName] = useState(null);

    useEffect(() => {

        GET_BY_ID(`Book`, ID).then(item => {

            setBookID(item.data.bookID)
            setBookName(item.data.bookName)

        })
    }, [])

    const handleDelete = () => {

        if (bookName !== "") {
            let Book = {

                bookID: ID,
            }
            DELETE_BY_ID(`Book`, Book).then(item => {
                setCheckDelete(true)
                alert("Delete success")
            })
        }
        else {
            alert("Wrong information");
        }
    }
    if (checkDelete) {
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
                        <th><input type="text" value={bookName} /></th>
                    </tr>
                </table>
                <br />
                <input
                    type="button"
                    onClick={() => {
                        const confirmBox = window.confirm(
                          "Do you really want to delete this ?"
                        )
                        if (confirmBox === true) {
                            handleDelete()
                        }
                      }}
                    value="Delete"
                />
            </center>
        </div>
    );
}

export default DeleteBook;