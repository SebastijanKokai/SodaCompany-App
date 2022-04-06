import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { Fragment } from "react";

import "./App.css";

import Navigation from "./components/Navigation/Navigation";
import Orders from "./components/Orders/Orders";

function App() {
  return (
    <Fragment>
      <Navigation />
      <Routes>
        <Route path="/" element={<div></div>} />
        <Route path="/orders" element={<Orders />} />
        <Route path="/plans" element={<div></div>} />
      </Routes>
    </Fragment>
  );
}

export default App;
