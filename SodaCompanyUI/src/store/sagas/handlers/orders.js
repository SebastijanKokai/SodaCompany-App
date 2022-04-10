import { call, put } from "redux-saga/effects";
import { getOrders } from "../../orders/orders-slice";
import OrderServices from "../../../services/OrderServices";

export function* handleGetOrders(action) {
  try {
    const response = yield call(OrderServices.getAll);
    yield put(getOrders(response.data));
  } catch (error) {
    console.log(error);
  }
}
