import { call, put } from "redux-saga/effects";
import {
  getOrdersSuccess,
  getOrdersError,
  addOrderSuccess,
  addOrderError,
  deleteOrderSuccess,
  deleteOrderError,
} from "../../orders/orders-slice";

import { getProductsSuccess } from "../../products/products-slice";

import OrderServices from "../../../services/OrderServices";
import ProductServices from "../../../services/ProductServices";

export function* handleGetOrders(action) {
  try {
    let response = yield call(OrderServices.getAll);
    yield put(getOrdersSuccess(response.data));

    response = yield call(ProductServices.getAll);
    yield put(getProductsSuccess(response.data));
  } catch (error) {
    yield put(getOrdersError(error.message));
    console.log(error.message);
  }
}

export function* handleAddOrder(action) {
  const newOrder = action.payload;
  const { data, statusCode } = yield call(OrderServices.create, newOrder);

  if (statusCode >= 400 && statusCode < 600) {
    yield put(addOrderError(data.message));
    console.log(data.message);
  } else {
    yield put(addOrderSuccess(data));
  }
}

export function* handleDeleteOrder(action) {
  const id = action.payload;
  const { data, statusCode } = yield call(OrderServices.delete, id);

  if (statusCode >= 400 && statusCode < 600) {
    yield put(deleteOrderError(data.message));
    console.log(data.message);
  } else {
    yield put(deleteOrderSuccess(id));
  }
}
