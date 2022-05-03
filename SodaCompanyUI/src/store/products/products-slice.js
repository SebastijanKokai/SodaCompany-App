import { createSlice } from "@reduxjs/toolkit";

const productsSlice = createSlice({
  name: "products",
  initialState: {
    products: [],
    workProcedures: [],
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
        });

        const workProcedures = data[key].workProcedure;
        const productId = data[key].id;
        for (const key2 in workProcedures) {
          state.workProcedures.push({ ...workProcedures[key2], productId });
        }
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
