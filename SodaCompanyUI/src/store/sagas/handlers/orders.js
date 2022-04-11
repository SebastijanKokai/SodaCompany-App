import { call, put } from "redux-saga/effects";
import { getOrdersSuccess, getOrdersError } from "../../orders/orders-slice";
import OrderServices from "../../../services/OrderServices";

export function* handleGetOrders(action) {
  try {
    const response = yield call(OrderServices.getAll);
    yield put(getOrdersSuccess(response.data));
  } catch (error) {
    yield put(getOrdersError(error.message));
    console.log(error);
  }
}
