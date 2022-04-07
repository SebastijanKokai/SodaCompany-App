import { Fragment, useState } from "react";

import BootstrapTable from "react-bootstrap-table-next";
import OrderProductsTable from "./OrderRow/OrderProductsTable/OrderProductsTable";

import Button from "react-bootstrap/Button";
import AddModal from "../Modal/AddModal";
import AddModalBody from "./AddModalBody";

const DUMMY_DATA = [
  {
    id: "1",
    manager: "John Taylor",
    orderName: "Nalog1",
    totalProducts: "4",
    dateCreated: "03-08-2021",
    products: [
      {
        name: "Coca cola 0.33",
        quantity: "100",
      },
    ],
  },
  {
    id: "2",
    manager: "Mary Williams",
    orderName: "Nalog2",
    totalProducts: "1",
    dateCreated: "03-09-2021",
    products: [
      {
        name: "Coca cola 0.33",
        quantity: "100",
      },
      {
        name: "Coca cola 0.5",
        quantity: "200",
      },
    ],
  },
  {
    id: "3",
    manager: "Petar Petrovic",
    orderName: "Nalog3",
    totalProducts: "2",
    dateCreated: "04-05-2021",
    products: [
      {
        name: "Coca cola 0.33",
        quantity: "100",
      },
      {
        name: "Fanta 0.33",
        quantity: "600",
      },
    ],
  },
];

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
          <Button className="btn btn-danger btn-xs">Delete</Button>
          <Button variant="warning">Edit</Button>
        </div>
      );
    },
  },
];

const expandRow = {
  renderer: (row) => {
    return <OrderProductsTable products={DUMMY_DATA[0].products} />;
  },
  showExpandColumn: true,
  expandByColumnOnly: true,
};

const Orders = () => {
  const [modalShow, setModalShow] = useState(false);
  return (
    <Fragment>
      <BootstrapTable
        keyField="id"
        data={DUMMY_DATA}
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
        bodycomponent={AddModalBody}
      />
    </Fragment>
  );
};

export default Orders;
