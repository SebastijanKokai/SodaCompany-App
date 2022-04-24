import { takeEvery, all } from "redux-saga/effects";

import { handleGetOrders, handleAddOrder } from "./handlers/orders";
import { handleGetProducts } from "./handlers/products";

export function* watcherSaga() {
  yield all([
    takeEvery("orders/getOrders", handleGetOrders),
    takeEvery("orders/addOrder", handleAddOrder),
    takeEvery("products/getProducts", handleGetProducts),
  ]);
}
