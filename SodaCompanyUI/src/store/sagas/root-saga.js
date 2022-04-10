import { takeLatest } from "redux-saga/effects";
import { handleGetOrders } from "./handlers/orders";
import { GET_ORDERS } from "./saga-actions";

export function* watcherSaga() {
  yield takeLatest(GET_ORDERS, handleGetOrders);
}
