import { createSlice } from "@reduxjs/toolkit";

const productsSlice = createSlice({
  name: "products",
  initialState: {
    products: [],
    isLoading: false,
    error: {},
  },
  reducers: {
    getProducts(state) {
      state.isLoading = true;
    },
    getProductsSuccess(state, action) {
      const { data } = action.payload;
      const productArray = [];
      for (const key in data) {
        productArray.push({
          id: data[key].id,
          name: data[key].name,
          productModelId: data[key].productModelId,
          productModelUnit: data[key].productModelUnit,
          productModelValue: data[key].productModelValue,
          productModelType: data[key].productModelType,
          productModelWidth: data[key].productModelWidth,
          productModelHeight: data[key].productModelHeight,
          workProcedure: data[key].workProcedure,
        });
      }
      state.products = productArray;
      state.isLoading = false;
    },
    getProductsError(state, action) {
      state.isLoading = false;
      state.error = action.payload;
    },
  },
});

export const { getProducts, getProductsSuccess, getProductsError } =
  productsSlice.actions;

export default productsSlice.reducer;
