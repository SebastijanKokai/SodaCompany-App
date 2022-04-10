import moment from "moment";

import { createSlice } from "@reduxjs/toolkit";

const ordersSlice = createSlice({
  name: "orders",
  initialState: {
    orders: [],
  },
  reducers: {
    getOrders(state, action) {
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
    },
    addOrder(state, action) {
      const data = action.payload;
      console.log(data);
    },
  },
});

export const { getOrders, addOrder } = ordersSlice.actions;

export default ordersSlice.reducer;
