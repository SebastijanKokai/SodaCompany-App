import { combineReducers } from "redux";
import createSagaMiddleware from "@redux-saga/core";
import ordersReducer from "./orders/orders-slice";
import productsReducer from "./products/products-slice";
import plansReducer from "./plans/plans-slice";
import { watcherSaga } from "./sagas/root-saga";
import { configureStore, getDefaultMiddleware } from "@reduxjs/toolkit";

const reducer = combineReducers({
  orders: ordersReducer,
  products: productsReducer,
  plans: plansReducer,
});

const sagaMiddleware = createSagaMiddleware();

const store = configureStore({
  reducer,
  middleware: [
    ...getDefaultMiddleware({ thunk: false, serializableCheck: false }),
    sagaMiddleware,
  ],
});

sagaMiddleware.run(watcherSaga);

export default store;
