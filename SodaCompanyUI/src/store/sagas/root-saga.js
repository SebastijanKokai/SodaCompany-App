import { takeLatest, all } from "redux-saga/effects";

import { handleGetOrders } from "./handlers/orders";
import { handleGetProducts } from "./handlers/products";

export function* watcherSaga() {
  yield all([
    takeLatest("orders/getOrders", handleGetOrders),
    takeLatest("products/getProducts", handleGetProducts),
  ]);
}
