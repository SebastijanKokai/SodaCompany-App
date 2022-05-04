import { call, put } from "redux-saga/effects";
import {
  getPlansSuccess,
  getPlansError,
  addPlanError,
  addPlanSuccess,
  deletePlanSuccess,
  deletePlanError,
} from "../../plans/plans-slice";
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

export function* handleAddPlan(action) {
  const newPlan = action.payload;

  let { data, statusCode } = yield call(PlanServices.create, newPlan);

  if (statusCode >= 400 && statusCode < 600) {
    yield put(addPlanError(data.message));
  } else {
    yield put(addPlanSuccess(data));
  }
}

export function* handleDeletePlan(action) {
  const id = action.payload;

  let { data, statusCode } = yield call(PlanServices.delete, id);

  if (statusCode >= 400 && statusCode < 600) {
    yield put(deletePlanError(data.message));
  } else {
    yield put(deletePlanSuccess(id));
  }
}
