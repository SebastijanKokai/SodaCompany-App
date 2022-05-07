import { Fragment } from "react";
import { Routes, Route } from "react-router-dom";
import { useDispatch } from "react-redux";

import { getOrders } from "./store/orders/orders-slice";
import { getProducts } from "./store/products/products-slice";
import { getPlans } from "./store/plans/plans-slice";

import "./App.css";

import Navigation from "./components/Navigation/Navigation";
import Orders from "./components/Orders/Orders";
import Plans from "./components/Plans/Plans";

const App = () => {
  const dispatch = useDispatch();
  dispatch({ type: "REQUEST_ALL", payload: 1 });

  return (
    <Fragment>
      <Navigation />
      <Routes>
        <Route
          path="/"
          element={
            <div className="center">
              <h1>Welcome to the Home page!</h1>
            </div>
          }
        />
        <Route path="/orders" element={<Orders />} />
        <Route path="/plans" element={<Plans />} />
      </Routes>
    </Fragment>
  );
};

export default App;
