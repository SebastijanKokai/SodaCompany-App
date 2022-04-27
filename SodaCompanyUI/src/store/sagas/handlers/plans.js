import { call, put } from "redux-saga/effects";
import { getPlansSuccess, getPlansError } from "../../plans/plans-slice";
import PlanServices from "../../../services/PlanServices";

export function* handleGetPlans(action) {
  const pageNumber = action.payload;
  let { data, statusCode } = yield call(
    PlanServices.getAllWithParams,
    pageNumber
  );

  if (statusCode >= 400 && statusCode < 600) {
    yield put(getPlansError(data.message));
    console.log(data.message);
  } else {
    yield put(getPlansSuccess(data));
  }
}
