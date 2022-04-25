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
        const date = moment(data.creationDate).format("DD-MM-YYYY");

        orderArray.push({
          id: data[key].id,
          manager: `${data[key].createdByNavigationName} ${data[key].createdByNavigationSurname}`,
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

      const date = moment(data.creationDate).format("DD-MM-YYYY");

      state.orders.push({
        id: data.id,
        manager: `${data.createdByNavigationName} ${data.createdByNavigationSurname}`,
        orderName: data.name,
        dateCreated: date,
        totalProducts: data.orderedProducts.length,
        products: data.orderedProducts,
      });
    },
    addOrderError(state, action) {
      state.isLoading = false;
      state.error = action.payload;
    },
    deleteOrder(state) {
      state.isLoading = true;
    },
    deleteOrderSuccess(state, action) {
      const id = action.payload;
      state.orders = state.orders.filter((order) => order.id !== id);
    },
    deleteOrderError(state, action) {
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
  deleteOrder,
  deleteOrderSuccess,
  deleteOrderError,
} = ordersSlice.actions;

export default ordersSlice.reducer;
