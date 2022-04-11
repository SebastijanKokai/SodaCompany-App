import moment from "moment";

import { createSlice } from "@reduxjs/toolkit";

const ordersSlice = createSlice({
  name: "orders",
  initialState: {
    orders: [],
    isLoading: false,
    error: {},
  },
  reducers: {
    getOrders(state) {
      state.isLoading = true;
    },
    getOrdersSuccess(state, action) {
      const { data } = action.payload;
      const orderArray = [];
      for (const key in data) {
        const date = moment(data[key].creationDate, "DD-MM-YYYY").format(
          "DD-MM-YYYY"
        );
        console.log(date);
        orderArray.push({
          id: data[key].id,
          manager: data[key].createdBy,
          orderName: data[key].name,
          dateCreated: date,
          totalProducts: data[key].orderedProducts.length,
          products: data[key].orderedProducts,
        });
      }
      state.orders = orderArray;
      state.isLoading = false;
    },
    getOrdersError(state, action) {
      state.isLoading = false;
      state.error = action.payload;
    },
    addOrder(state, action) {
      const data = action.payload;
      console.log(data);
    },
  },
});

export const { getOrders, getOrdersSuccess, getOrdersError, addOrder } =
  ordersSlice.actions;

export default ordersSlice.reducer;
