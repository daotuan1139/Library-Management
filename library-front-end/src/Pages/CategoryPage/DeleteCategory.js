import React, { useEffect, useState } from 'react';
import './categoryList.css';
import { DELETE_BY_ID, GET_BY_ID } from '../../API/callAPI';
import { Redirect, useParams } from 'react-router-dom';

const DeleteCategory = () => {

    const [checkDelete, setCheckDelete] = useState(false);
    const { ID } = useParams();
    const [categoryID, setCategoryID] = useState(0);
    const [categoryName, setCategoryName] = useState(null);

    useEffect(() => {

        GET_BY_ID(`category`, ID).then(item => {

            setCategoryID(item.data.categoryID)
            setCategoryName(item.data.categoryName)

        })
    }, [])

    const handleDelete = () => {

        if (categoryName !== "") {
            let category = {

                categoryID: ID,
            }
            DELETE_BY_ID(`category`, category).then(item => {
                setCheckDelete(true)
                alert("Delete success")
            })
        }
        else {
            alert("Wrong information");
        }
    }
    if (checkDelete) {
        return <Redirect to="/category" />
    }


    return (
        <div>
            <center>
                <h3>Edit</h3>
                <br />
                <table>
                    <tr>
                        <th>Category name </th>
                        <th><input type="text" value={categoryName} /></th>
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

export default DeleteCategory;