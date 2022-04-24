import api from "../api/api";

const OrderServices = {
  getAll: () => {
    try {
      const response = api.get("ProductionOrders");
      return response;
    } catch (error) {
      console.log(error.message);
    }
  },
  create: async (newOrder) => {
    try {
      const response = await api.post("ProductionOrders", newOrder);
      return response;
    } catch ({ response }) {
      return response;
    }
  },
  update: (id) => {
    try {
      const response = api.put(`ProductionOrders/${id}`);
      return response;
    } catch (error) {
      console.log(error.message);
    }
  },
  delete: (id) => {
    try {
      const response = api.delete(`ProductionOrders/${id}`);
      return response;
    } catch (error) {
      console.log(error.message);
    }
  },
};

export default OrderServices;
