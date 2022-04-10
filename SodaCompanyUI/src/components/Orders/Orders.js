import { Fragment, useState } from "react";
import { useSelector } from "react-redux";

import BootstrapTable from "react-bootstrap-table-next";
import OrderProductsTable from "./OrderProductsTable/OrderProductsTable";

import Button from "react-bootstrap/Button";
import AddModal from "../Modal/AddModal";
import AddModalBody from "./AddModal/AddModalBody";

const columns = [
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

const Orders = () => {
  const orders = useSelector((state) => state.orders.orders);
  console.log(orders);

  const [modalShow, setModalShow] = useState(false);
  return (
    <Fragment>
      <BootstrapTable
        keyField="id"
        data={orders}
        columns={columns}
        expandRow={expandRow}
      />
      <div className="d-grid gap-2">
        <Button variant="primary" size="lg" onClick={() => setModalShow(true)}>
          +
        </Button>
      </div>
      <AddModal
        show={modalShow}
        onHide={() => setModalShow(false)}
        BodyComponent={AddModalBody}
        title={"Add Order"}
      />
    </Fragment>
  );
};

export default Orders;
