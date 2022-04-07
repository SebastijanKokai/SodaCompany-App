import api from "../api/api";

export const getAll = () => {
  const response = api.get("ProductionOrders");
  return response;
};

export const create = (newOrder) => {
  const response = api.post("ProductionOrders", newOrder);
  return response;
};

export const update = (id) => {
  const response = api.put(`ProductionOrders/${id}`);
  return response;
};

export const remove = (id) => {
  const response = api.delete(`ProductionOrders/${id}`);
  return response;
};
