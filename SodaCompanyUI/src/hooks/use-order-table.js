import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";

import Button from "react-bootstrap/Button";

import OrderProductsTable from "../components/Orders/OrderProductsTable/OrderProductsTable";

import { getOrders } from "../store/orders/orders-slice";

const useOrderTable = () => {
  const dispatch = useDispatch();

  const orders = useSelector((state) => state.orders.orders);
  const pageInfo = useSelector((state) => state.orders.pageInfo);
  const [orderId, setOrderId] = useState("");
  const [addModalShow, setAddModalShow] = useState(false);
  const [deleteModalShow, setDeleteModalShow] = useState(false);
  const [editModalShow, setEditModalShow] = useState(false);

  const columns = [
    {
      dataField: "id",
      text: "Id",
      sort: true,
    },
    {
      dataField: "manager",
      text: "Manager",
      sort: true,
    },
    {
      dataField: "orderName",
      text: "Order Name",
      sort: true,
    },
    {
      dataField: "totalProducts",
      text: "Total products",
      sort: true,
    },
    {
      dataField: "dateCreated",
      text: "Date created",
      sort: true,
    },
    {
      dataField: "actions",
      text: "Actions",
      formatter: (cellContent, row) => {
        return (
          <div>
            <Button
              className="btn btn-danger btn-xs"
              style={{ marginRight: "12px" }}
              onClick={() => {
                setOrderId(row.id);
                setDeleteModalShow(true);
              }}
            >
              Delete
            </Button>
            <Button
              variant="warning"
              onClick={() => {
                setOrderId(row.id);
                setEditModalShow(true);
              }}
            >
              Edit
            </Button>
          </div>
        );
      },
    },
  ];

  const expandRow = {
    renderer: (row) => {
      return <OrderProductsTable products={row.products} />;
    },
    showExpandColumn: true,
    expandByColumnOnly: true,
  };

  const changePageHandler = (pageItemText) => {
    let pageNumber = pageInfo.pageNumber;

    switch (pageItemText) {
      case "Next":
        pageNumber =
          pageNumber === pageInfo.totalPages ? pageNumber : pageNumber + 1;
        break;
      case "Prev":
        pageNumber = pageNumber === 1 ? pageNumber : pageNumber - 1;
        break;
      case "First":
        pageNumber = 1;
        break;
      case "Last":
        pageNumber = pageInfo.totalPages;
        break;
      default:
        pageNumber = !isNaN(pageItemText) ? parseInt(pageItemText) : 1;
        break;
    }

    dispatch(getOrders(pageNumber));
  };

  return {
    orders,
    pageInfo,
    orderId,
    addModalShow,
    setAddModalShow,
    deleteModalShow,
    setDeleteModalShow,
    editModalShow,
    setEditModalShow,
    columns,
    expandRow,
    changePageHandler,
  };
};

export default useOrderTable;
