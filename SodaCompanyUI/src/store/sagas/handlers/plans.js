import { call, put } from "redux-saga/effects";
import { getPlansSuccess, getPlansError } from "../../plans/plans-slice";
import PlanServices from "../../../services/PlanServices";

export function* handleGetPlans(action) {
  try {
    const pageNumber = action.payload;
    let response = yield call(PlanServices.getAllWithParams, pageNumber);
    yield put(getPlansSuccess(response.data));
  } catch (error) {
    yield put(getPlansError(error.message));
    console.log(error.message);
  }
}
