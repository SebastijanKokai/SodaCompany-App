import api from "../api/api";

const ProductServices = {
  getAll: () => {
    try {
      const response = api.get("Products");
      return response;
    } catch (error) {
      console.log(error.message);
    }
  },
};

export default ProductServices;
