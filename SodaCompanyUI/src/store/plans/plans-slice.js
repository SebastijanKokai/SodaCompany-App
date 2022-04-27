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
  },
});

export const { getPlans, getPlansSuccess, getPlansError } = plansSlice.actions;

export default plansSlice.reducer;
