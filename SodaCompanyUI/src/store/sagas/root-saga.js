import { takeEvery, all } from "redux-saga/effects";

import {
  handleGetOrders,
  handleAddOrder,
  handleEditOrder,
  handleDeleteOrder,
} from "./handlers/orders";

import { handleGetPlans } from "./handlers/plans";
import { handleGetProducts } from "./handlers/products";

export function* watcherSaga() {
  yield all([
    takeEvery("orders/getOrders", handleGetOrders),
    takeEvery("orders/addOrder", handleAddOrder),
    takeEvery("orders/editOrder", handleEditOrder),
    takeEvery("orders/deleteOrder", handleDeleteOrder),
    takeEvery("products/getProducts", handleGetProducts),
    takeEvery("plans/getPlans", handleGetPlans),
  ]);
}
