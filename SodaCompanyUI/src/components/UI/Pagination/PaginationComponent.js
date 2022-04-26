import { useState } from "react";
import Pagination from "react-bootstrap/Pagination";
import PaginationFunctions from "./PaginationFunctions";

const PaginationComponent = ({ pageInfo, changePageHandler }) => {
  return (
    <Pagination size="md" className="center">
      <Pagination.First onClick={() => changePageHandler("First")} />
      <Pagination.Prev onClick={() => changePageHandler("Prev")} />
      {PaginationFunctions.returnPaginationItems(
        pageInfo.totalPages,
        pageInfo.pageNumber,
        changePageHandler
      )}
      <Pagination.Next onClick={() => changePageHandler("Next")} />
      <Pagination.Last onClick={() => changePageHandler("Last")} />
    </Pagination>
  );
};

export default PaginationComponent;
