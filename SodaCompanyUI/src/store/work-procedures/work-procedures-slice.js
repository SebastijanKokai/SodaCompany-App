import { createSlice } from "@reduxjs/toolkit";

const workProceduresSlice = createSlice({
  name: "workProcedures",
  initialState: {
    workProcedures: [
      // Mocked objects
      {
        id: "9e18c8d2-5106-4b81-9187-5540ac0b66cc",
        name: "Standardna procedura coca-cola 0.33 staklo",
        description:
          "Punjenje, zatvaranje flase, dodavanje nalepnice, pakovanje",
        productionPrice: 50,
        productId: "af07e0c0-fb0a-46fc-9dbb-9ab4d9a0c839",
      },
      {
        id: "8f3e8330-f665-45dc-bb5b-0bf7275c654d",
        name: "Standardna procedura sprite plastika",
        description:
          "Punjenje, zatvaranje flase, dodavanje nalepnice, pakovanje",
        productionPrice: 50,
        productId: "f620e5eb-80c6-46f7-be3f-55c0fe633eac",
      },
      {
        id: "b38a6a37-7849-48b2-8023-895ee05c9a5f",
        name: "Standardna procedura fanta",
        description:
          "Punjenje, zatvaranje flase, dodavanje nalepnice, pakovanje",
        productionPrice: 50,
        productId: "89945a5d-3eb5-4c65-88d6-9f0864bdc376",
      },
    ],
    isLoading: false,
    error: {},
  },
  reducers: {
    getWorkProcedures(state) {
      state.isLoading = true;
    },
    getWorkProceduresSuccess(state, action) {
      const { data } = action.payload;

      for (const key in data) {
        state.workProcedures.push({
          id: data[key].id,
          name: data[key].name,
          description: data[key].description,
          productionPrice: data[key].productionPrice,
          productId: data[key].productId,
        });
      }

      state.isLoading = false;
    },
    getWorkProceduresError(state, action) {
      state.isLoading = false;
      state.error = action.payload;
    },
  },
});

export const {
  getWorkProcedures,
  getWorkProceduresSuccess,
  getWorkProceduresError,
} = workProceduresSlice.actions;

export default workProceduresSlice.reducer;
