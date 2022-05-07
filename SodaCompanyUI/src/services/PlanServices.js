import api from "../api/api";

const PlanServices = {
  getAll: () => {
    try {
      const response = api.get("ProductionPlans");
      return response;
    } catch (error) {
      console.log(error.message);
    }
  },
  getAllWithParams: (pageNumber) => {
    try {
      const response = api.get(
        `ProductionPlans?PageNumber=${pageNumber}&RecordsPerPage=4`
      );
      return response;
    } catch (error) {
      console.log(error.message);
    }
  },
  create: (newPlan) => {
    try {
      const response = api.post("ProductionPlans", newPlan);
      return response;
    } catch ({ response }) {
      return response;
    }
  },
  update: (newPlan) => {
    try {
      const response = api.put(`ProductionPlans/${newPlan.id}`, newPlan);
      return response;
    } catch (error) {
      console.log(error.message);
    }
  },
  delete: (id) => {
    try {
      const response = api.delete(`ProductionPlans/${id}`);
      return response;
    } catch (error) {
      console.log(error.message);
    }
  },
};

export default PlanServices;
