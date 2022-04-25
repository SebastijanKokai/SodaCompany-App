import { takeEvery, all } from "redux-saga/effects";

import {
  handleGetOrders,
  handleAddOrder,
  handleDeleteOrder,
} from "./handlers/orders";
import { handleGetProducts } from "./handlers/products";

export function* watcherSaga() {
  yield all([
    takeEvery("orders/getOrders", handleGetOrders),
    takeEvery("orders/addOrder", handleAddOrder),
    takeEvery("orders/deleteOrder", handleDeleteOrder),
    takeEvery("products/getProducts", handleGetProducts),
  ]);
}
