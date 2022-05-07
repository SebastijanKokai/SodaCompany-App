import { takeLatest, all } from "redux-saga/effects";

import { handleGetAll } from "./handlers/common";

import {
  handleGetOrders,
  handleAddOrder,
  handleEditOrder,
  handleDeleteOrder,
} from "./handlers/orders";

import {
  handleGetPlans,
  handleAddPlan,
  handleEditPlan,
  handleDeletePlan,
} from "./handlers/plans";
import { handleGetProducts } from "./handlers/products";

export function* watcherSaga() {
  yield all([
    takeLatest("REQUEST_ALL", handleGetAll),
    takeLatest("orders/getOrders", handleGetOrders),
    takeLatest("orders/addOrder", handleAddOrder),
    takeLatest("orders/editOrder", handleEditOrder),
    takeLatest("orders/deleteOrder", handleDeleteOrder),
    takeLatest("products/getProducts", handleGetProducts),
    takeLatest("plans/getPlans", handleGetPlans),
    takeLatest("plans/addPlan", handleAddPlan),
    takeLatest("plans/editPlan", handleEditPlan),
    takeLatest("plans/deletePlan", handleDeletePlan),
  ]);
}
