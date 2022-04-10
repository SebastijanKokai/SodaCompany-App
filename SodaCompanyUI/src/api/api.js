import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:44331/api/",
});

export default api;
