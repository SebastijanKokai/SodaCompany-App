import { Fragment, useState } from "react";
import { useSelector } from "react-redux";

import BootstrapTable from "react-bootstrap-table-next";
import OrderProductsTable from "./OrderProductsTable/OrderProductsTable";

import Button from "react-bootstrap/Button";
import GenericModal from "../Modal/GenericModal";
import AddModalBody from "./AddModal/AddModalBody";
import DeleteModalBody from "./DeleteModal/DeleteModalBody";

const Orders = () => {
  const orders = useSelector((state) => state.orders.orders);

  const [orderId, setOrderId] = useState("");
  const [addModalShow, setAddModalShow] = useState(false);
  const [deleteModalShow, setDeleteModalShow] = useState(false);

  const columns = [
    {
      dataField: "id",
      text: "Id",
    },
    {
      dataField: "manager",
      text: "Manager",
    },
    {
      dataField: "orderName",
      text: "Order Name",
    },
    {
      dataField: "totalProducts",
      text: "Total products",
    },
    {
      dataField: "dateCreated",
      text: "Date created",
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
            <Button variant="warning">Edit</Button>
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

  return (
    <Fragment>
      <BootstrapTable
        keyField="id"
        data={orders}
        columns={columns}
        expandRow={expandRow}
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
    </Fragment>
  );
};

export default Orders;
