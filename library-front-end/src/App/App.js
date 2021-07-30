import Navbar from "./NavBar/NavBar";
import HomePage from "../Pages/HomePage/HomePage";
import BookPage from "../Pages/BookPage/BookPage.js";
import CategoryPage from "../Pages/CategoryPage/CategoryPage.js";
import LoginPage from "../Pages/LoginPage/LoginPage";
import BorrowedBookPage from "../Pages/BorrowedBookPage/BorrowedBookPage";
import CreateBook from "../Pages/BookPage/CreateBook";
import EditBook from "../Pages/BookPage/EditBook";
import DeleteBook from "../Pages/BookPage/DeleteBook";
import CreateCategory from "../Pages/CategoryPage/CreateCategory";
import EditCategory from "../Pages/CategoryPage/EditCategory";
import DeleteCategory from "../Pages/CategoryPage/DeleteCategory";

import React,{ useState } from "react";
import { Switch, Route } from "react-router-dom";

function App() {
  const initialValues = {
    userID: null,
    userEmail: null,
  }

  const [currentUser, setCurrentUser] = useState({ initialValues })
  const logout = () => setCurrentUser(initialValues);
  const isUserLoggedIn = Boolean(currentUser.userID);
  return (
    <div className="app container">
      <Navbar 
        logout={logout}
        isUserLoggedIn={isUserLoggedIn}
      />
      <Switch>
        <Route path="/login">
          <LoginPage 
            setCurrentUser={setCurrentUser}
            currentUser={currentUser}
          />
        </Route>
        <Route path="/borrowed">
          <BorrowedBookPage />
        </Route>
       
        <Route path="/category" exact>
          <CategoryPage />
        </Route>
        <Route path="/createCategory" exact>
          <CreateCategory />
        </Route>

        <Route path="/editCategory/:ID" exact>
          <EditCategory />
        </Route>

        <Route path="/deleteCategory/:ID" exact>
          <DeleteCategory />
        </Route>

        <Route path="/book" exact>
          <BookPage />
        </Route>

        <Route path="/createBook" exact>
          <CreateBook />
        </Route>

        <Route path="/editBook/:ID" exact>
          <EditBook />
        </Route>

        <Route path="/deleteBook/:ID" exact>
          <DeleteBook />
        </Route>

        <Route
          path="/"
          render={() => {
            if (!isUserLoggedIn)
              return (
                <LoginPage
                  setCurrentUser={setCurrentUser}
                  currentUser={currentUser}
                />
              );
            else return <HomePage currentUser={currentUser} />;
          }}
        ></Route>

      </Switch>
    </div>
  );
}

export default App;
