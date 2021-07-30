import React, { useState } from 'react';
import './categoryList.css';
import { POST_ADD } from '../../API/callAPI';
import { Redirect } from 'react-router-dom';

const CreateCategory = () => {

    const [checkAdd, setCheckAdd] = useState(false);
    const [categoryName, setCategoryName] = useState(null);


    const handleChangeCategoryName = (event) => {
        setCategoryName(event.target.value)
    }

    const handleCreate = (event) => {
        event.preventDefault();

        if (categoryName !== "") {
            let newCategory = {
                categoryName: categoryName,
            }
            POST_ADD(`category`, newCategory).then(item => {
                setCategoryName(item.data);
                setCheckAdd(true);
                alert("Create success");
            })
        }
        else {
            alert("Wrong information");
        }
    }
    if(checkAdd){
        return <Redirect to="/category" />
    }

    return (
        <div>
            <center>
                <h3>Create</h3>
                <br />
                <table>
                    <tr>
                        <th>Category name </th>
                        <th><input type="text" onChange={handleChangeCategoryName} name="categoryName" /></th>
                    </tr>
                </table>
                <br />
                <input type="button" onClick={handleCreate} value="Create" />
            </center>
        </div>
    );
}

export default CreateCategory;