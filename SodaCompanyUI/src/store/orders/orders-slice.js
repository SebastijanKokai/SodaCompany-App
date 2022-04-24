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
    addOrder(state) {
      state.isLoading = true;
    },
    addOrderSuccess(state, action) {
      const data = action.payload;

      const date = moment(data.creationDate, "DD-MM-YYYY").format("DD-MM-YYYY");

      state.orders.push({
        manager: data.createdBy,
        orderName: data.name,
        dateCreated: date,
        totalProducts: data.orderProducts.length,
        products: data.orderProducts,
      });
    },
    addOrderError(state, action) {
      state.isLoading = false;
      state.error = action.payload;
    },
  },
});

export const {
  getOrders,
  getOrdersSuccess,
  getOrdersError,
  addOrder,
  addOrderSuccess,
  addOrderError,
} = ordersSlice.actions;

export default ordersSlice.reducer;
