// import { createRoot } from "react-dom/client";
import ReactDOM from "react-dom";
import { StrictMode } from "react";
import { BrowserRouter as Router } from "react-router-dom";

import React from "react";
import App from "./App";

import "bootstrap/dist/css/bootstrap.min.css";
import "react-bootstrap-table-next/dist/react-bootstrap-table2.min.css";

// const rootElement = document.getElementById("root");
// const root = createRoot(rootElement);

// root.render(
//   <Router>
//     <App />
//   </Router>
// );

ReactDOM.render(
  <Router>
    <App />
  </Router>,
  document.getElementById("root")
);
