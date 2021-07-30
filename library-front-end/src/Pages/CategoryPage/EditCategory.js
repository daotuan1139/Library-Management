import React, { useEffect, useState } from 'react';
import './categoryList.css';
import { PUT_EDIT, GET_BY_ID } from '../../API/callAPI';
import { Redirect, useParams } from 'react-router-dom';

const EditCategory = () => {

    const [checkEdit, setCheckEdit] = useState(false);
    const { ID } = useParams();
    const [categoryID, setCategoryID] = useState(0);
    const [categoryName, setCategoryName] = useState(null);

    const handleChangeCategoryName = (event) => {

        setCategoryName(event.target.value)
    }

    useEffect(() => {

        GET_BY_ID(`category`, ID).then(item => {

            setCategoryID(item.data.categoryID)
            setCategoryName(item.data.categoryName)

        })
    }, [])

    const handleEdit = (event) => {
        event.preventDefault();

        if (categoryName !== "") {
            let editCategory = {
                categoryID: ID,
                categoryName: categoryName,
            }
            PUT_EDIT(`category`, editCategory).then(item => {
                setCheckEdit(true);
                alert("Edit success");
            })
        }
        else {
            alert("Wrong information");
        }
    }
    if (checkEdit) {
        return <Redirect to="/category" />
    }

    return (
        <div>
            <center>
                <h3>Edit</h3>
                <br />
                <table>
                    <tr>
                        <th>category name </th>
                        <th><input type="text" onChange={handleChangeCategoryName} value={categoryName} /></th>
                    </tr>
                </table>
                <br />
                <input type="button" onClick={handleEdit} value="Edit" />
            </center>
        </div>
    );
}

export default EditCategory;