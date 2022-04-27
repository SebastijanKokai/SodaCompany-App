import { call, put } from "redux-saga/effects";
import {
  getProductsSuccess,
  getProductsError,
} from "../../products/products-slice";
import ProductServices from "../../../services/ProductServices";

export function* handleGetProducts(action) {
  let { data, statusCode } = yield call(ProductServices.getAll);

  if (statusCode >= 400 && statusCode < 600) {
    yield put(getProductsError(data.message));
    console.log(data.message);
  } else {
    yield put(getProductsSuccess(data));
  }
}
