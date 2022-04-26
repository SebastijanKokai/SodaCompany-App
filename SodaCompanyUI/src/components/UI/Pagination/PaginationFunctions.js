import Pagination from "react-bootstrap/Pagination";

const PaginationFunctions = {
  returnPaginationItems: (totalPages, pageNumber, changePageHandler) => {
    const paginationListItems = !isNaN(totalPages) ? (
      [...Array(totalPages)].map((e, idx) => (
        <Pagination.Item
          key={`PaginationItem_${idx}`}
          active={idx + 1 === pageNumber}
          onClick={() => changePageHandler(idx + 1)}
        >
          {idx + 1}
        </Pagination.Item>
      ))
    ) : (
      <Pagination.Item>{1}</Pagination.Item>
    );
    return paginationListItems;
  },
};

export default PaginationFunctions;
