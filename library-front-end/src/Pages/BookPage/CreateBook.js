import React, { useState } from 'react';
import './BookList.css';
import { POST_ADD } from '../../API/callAPI';
import { Redirect } from 'react-router-dom';

const CreateBook = () => {

    const [checkAdd, setCheckAdd] = useState(false);
    const [bookName, setBookName] = useState(null);


    const handleChangeBookName = (event) => {
        setBookName(event.target.value)
    }

    const handleCreate = (event) => {
        event.preventDefault();

        if (bookName !== "") {
            let newBook = {
                bookName: bookName,
            }
            POST_ADD(`Book`, newBook).then(item => {
                setBookName(item.data);
                setCheckAdd(true);
                alert("Create success");
            })
        }
        else {
            alert("Wrong information");
        }
    }
    if(checkAdd){
        return <Redirect to="/book" />
    }

    return (
        <div>
            <center>
                <h3>Create</h3>
                <br />
                <table>
                    <tr>
                        <th>Book name </th>
                        <th><input type="text" onChange={handleChangeBookName} name="bookName" /></th>
                    </tr>
                </table>
                <br />
                <input type="button" onClick={handleCreate} value="Create" />
            </center>
        </div>
    );
}

export default CreateBook;