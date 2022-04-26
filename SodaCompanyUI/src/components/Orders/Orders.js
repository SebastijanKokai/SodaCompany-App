import { Fragment, useState } from "react";
import { useSelector, useDispatch } from "react-redux";

import BootstrapTable from "react-bootstrap-table-next";
import OrderProductsTable from "./OrderProductsTable/OrderProductsTable";

import Button from "react-bootstrap/Button";

import GenericModal from "../Modal/GenericModal";
import AddModalBody from "./AddModal/AddModalBody";
import DeleteModalBody from "./DeleteModal/DeleteModalBody";
import PaginationComponent from "../UI/Pagination/PaginationComponent";

import { getOrders } from "../../store/orders/orders-slice";
import EditModalBody from "./EditModal/EditModalBody";

const Orders = () => {
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

  return (
    <Fragment>
      <BootstrapTable
        bootstrap4
        keyField="id"
        data={orders}
        columns={columns}
        expandRow={expandRow}
      />
      <PaginationComponent
        pageInfo={pageInfo}
        changePageHandler={changePageHandler}
      />
      <div className="d-grid gap-2">
        <Button
          variant="primary"
          size="lg"
          onClick={() => setAddModalShow(true)}
        >
          +
        </Button>
      </div>
      <GenericModal
        show={addModalShow}
        onHide={() => setAddModalShow(false)}
        BodyComponent={AddModalBody}
        title={"Add Order"}
      />
      <GenericModal
        show={deleteModalShow}
        onHide={() => setDeleteModalShow(false)}
        BodyComponent={DeleteModalBody}
        title={"Delete order"}
        orderId={orderId}
      />
      <GenericModal
        show={editModalShow}
        onHide={() => setEditModalShow(false)}
        BodyComponent={EditModalBody}
        title={"Edit order"}
        orderId={orderId}
      />
    </Fragment>
  );
};

export default Orders;
