import api from "../api/api";

const OrderServices = {
  getAll: async () => {
    try {
      const response = await api.get("ProductionOrders");
      return response;
    } catch (error) {
      console.log(error.message);
    }
  },
  create: async (newOrder) => {
    try {
      const response = await api.post("ProductionOrders", newOrder);
      return response;
    } catch (error) {
      console.log(error.message);
    }
  },
  update: async (id) => {
    try {
      const response = await api.put(`ProductionOrders/${id}`);
      return response;
    } catch (error) {
      console.log(error.message);
    }
  },
  delete: async (id) => {
    try {
      const response = await api.delete(`ProductionOrders/${id}`);
      return response;
    } catch (error) {
      console.log(error.message);
    }
  },
};

export default OrderServices;
