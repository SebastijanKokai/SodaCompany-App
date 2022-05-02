import moment from "moment";

import { createSlice } from "@reduxjs/toolkit";

const plansSlice = createSlice({
  name: "plans",
  initialState: {
    plans: [],
    pageInfo: {
      pageNumber: 1,
      totalPages: 1,
      totalRecords: 0,
    },
    isLoading: false,
    error: {},
  },
  reducers: {
    getPlans(state) {
      state.isLoading = true;
    },
    getPlansSuccess(state, action) {
      const { pageNumber, totalPages, totalRecords, data } = action.payload;

      for (const key in data) {
        const startDate = moment(data[key].productionOrderCreationDate).format(
          "DD-MM-YYYY"
        );
        const endDate = moment(data[key].productionDeadline).format(
          "DD-MM-YYYY"
        );

        state.plans.push({
          id: data[key].id,
          manager: `${data[key].createdByNavigationName} ${data[key].createdByNavigationSurname}`,
          planName: data[key].name,
          orderId: data[key].productionOrderId,
          startDate,
          endDate,
          planWorkProcedures: data[key].productionPlanWorkProcedure,
        });
      }

      state.pageInfo = {
        pageNumber,
        totalPages,
        totalRecords,
      };

      state.isLoading = false;
    },
    getPlansError(state, action) {
      state.isLoading = false;
      state.error = action.payload;
    },
    addPlan(state) {
      state.isLoading = true;
    },
    addPlanSuccess(state, action) {
      const data = action.payload;

      const startDate = moment(data.creationDate).format("DD-MM-YYYY");
      const endDate = moment(data.productionDeadline).format("DD-MM-YYYY");

      state.plans.push({
        id: "Need Id",
        manager: "Need name",
        planName: data.name,
        orderId: data.productionOrderId,
        startDate,
        endDate,
        planWorkProcedures: data.planWorkProcedures,
      });

      state.isLoading = false;
    },
    addPlanError(state, action) {
      state.isLoading = false;
      state.error = action.payload;
    },
    deletePlan(state) {
      state.isLoading = true;
    },
    deletePlanSuccess(state, action) {
      const id = action.payload;
      state.plans = state.plans.filter((plan) => plan.id !== id);
      state.isLoading = false;
    },
    deletePlanError(state, action) {
      state.isLoading = false;
      state.error = action.payload;
    },
    editPlan(state) {
      state.isLoading = true;
    },
    editPlanSuccess(state, action) {
      const data = action.payload;

      const startDate = moment(data.creationDate).format("DD-MM-YYYY");
      const endDate = moment(data.productionDeadline).format("DD-MM-YYYY");

      const planIndex = state.plans.findIndex((plan) => plan.id === data.id);

      state.plans[planIndex].planName = data.name;
      state.plans[planIndex].startDate = startDate;
      state.plans[planIndex].endDate = endDate;
      state.plans[planIndex].orderId = data.orderId;
      state.plans[planIndex].planWorkProcedures = data.planWorkProcedures;

      state.isLoading = false;
    },
    editPlanError(state, action) {
      state.isLoading = false;
      state.error = action.payload;
    },
  },
});

export const {
  getPlans,
  getPlansSuccess,
  getPlansError,
  addPlan,
  addPlanSuccess,
  addPlanError,
  deletePlan,
  deletePlanSuccess,
  deletePlanError,
} = plansSlice.actions;

export default plansSlice.reducer;
