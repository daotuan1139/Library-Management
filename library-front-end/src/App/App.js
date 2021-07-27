import Navbar from "./NavBar/NavBar";
import HomePage from "../Pages/HomePage/HomePage";
import BookPage from "../Pages/BookPage/BookPage.js";
import CategoryPage from "../Pages/CategoryPage/CategoryPage.js";

import React from "react";
import { Switch, Route } from "react-router-dom";

function App() {
  return (
    <div className="app container">
      <Navbar />
      <Switch>
        <Route path="/login">
          
        </Route>
       
        <Route path="/category" exact>
          <CategoryPage />
        </Route>

        <Route path="/book" exact>
          <BookPage />
        </Route>

        <Route path="/" exact>
          <HomePage />
        </Route>

      </Switch>
    </div>
  );
}

export default App;
