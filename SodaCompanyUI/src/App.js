import { Fragment } from "react";
import { Routes, Route } from "react-router-dom";
import { useDispatch } from "react-redux";

import { getOrders } from "./store/orders/orders-slice";
import { getProducts } from "./store/products/products-slice";

import "./App.css";

import Navigation from "./components/Navigation/Navigation";
import Orders from "./components/Orders/Orders";

const App = () => {
  const dispatch = useDispatch();
  dispatch(getOrders());
  // dispatch(getProducts());

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
