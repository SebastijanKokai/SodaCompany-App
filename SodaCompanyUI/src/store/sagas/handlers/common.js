import { call, put } from "redux-saga/effects";

import { getOrdersSuccess, getOrdersError } from "../../orders/orders-slice";
import { getPlansSuccess, getPlansError } from "../../plans/plans-slice";
import {
  getProductsSuccess,
  getProductsError,
} from "../../products/products-slice";

import OrderServices from "../../../services/OrderServices";
import ProductServices from "../../../services/ProductServices";
import PlanServices from "../../../services/PlanServices";

export function* handleGetAll(action) {
  const pageNumber = action.payload;
  let { data, statusCode } = yield call(
    OrderServices.getAllWithParams,
    pageNumber
  );

  if (statusCode >= 400 && statusCode < 600) {
    yield put(getOrdersError(data.message));
    console.log(data.message);
  } else {
    yield put(getOrdersSuccess(data));
  }

  ({ data, statusCode } = yield call(
    PlanServices.getAllWithParams,
    pageNumber
  ));

  if (statusCode >= 400 && statusCode < 600) {
    yield put(getPlansError(data.message));
    console.log(data.message);
  } else {
    yield put(getPlansSuccess(data));
  }

  ({ data, statusCode } = yield call(ProductServices.getAll));

  if (statusCode >= 400 && statusCode < 600) {
    yield put(getProductsError(data.message));
    console.log(data.message);
  } else {
    yield put(getProductsSuccess(data));
  }
}

export function* handleGetProducts(action) {
  let { data, statusCode } = yield call(ProductServices.getAll);

  if (statusCode >= 400 && statusCode < 600) {
    yield put(getProductsError(data.message));
    console.log(data.message);
  } else {
    yield put(getProductsSuccess(data));
  }
}
