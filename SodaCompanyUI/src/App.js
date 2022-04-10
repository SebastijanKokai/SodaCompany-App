import { useEffect, Fragment } from "react";
import { Routes, Route } from "react-router-dom";
import { useDispatch } from "react-redux";

import { GET_ORDERS } from "./store/sagas/saga-actions";

import "./App.css";

import Navigation from "./components/Navigation/Navigation";
import Orders from "./components/Orders/Orders";

const App = () => {
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch({ type: GET_ORDERS });
  }, [dispatch]);

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
};

export default App;
