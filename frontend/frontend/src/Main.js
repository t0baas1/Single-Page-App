import React, { Component } from "react";
import "../node_modules/bootstrap/dist/css/bootstrap.min.css";
import {
  Route, Routes,
  NavLink,
  HashRouter,
} from "react-router-dom";
import Home from "./Home";
import Listaus from "./Listaus";

class Main extends Component {
    render() {
      return (
        <HashRouter>
          <div>
            <h1>Asiakaslistaus</h1>
            <ul className="header">
              <li><NavLink to="./">Home</NavLink></li>
              <li><NavLink to="./Listaus">Listaus</NavLink></li>
            </ul>
            <div className="content">
              <Routes>
                <Route exact path="/" element={<Home/>}/>
                <Route path="/Listaus" element={<Listaus/>}/>
              </Routes>
            </div>
          </div>
        </HashRouter>
      );
    }
  }
   
  export default Main;