import { call, put } from "redux-saga/effects";
import {
  getProductsSuccess,
  getProductsError,
} from "../../products/products-slice";
import ProductServices from "../../../services/ProductServices";

export function* handleGetProducts(action) {
  try {
    const response = yield call(ProductServices.getAll);
    console.log(response);
    yield put(getProductsSuccess(response.data));
  } catch (error) {
    yield put(getProductsError(error.message));
    console.log(error.message);
  }
}
