import { Fragment } from "react";

import BootstrapTable from "react-bootstrap-table-next";
import Button from "react-bootstrap/Button";

import GenericModal from "../Modal/GenericModal";
import AddModalBody from "./AddModal/AddModalBody";
import DeleteModalBody from "./DeleteModal/DeleteModalBody";
import EditModalBody from "./EditModal/EditModalBody";
import PaginationComponent from "../UI/Pagination/PaginationComponent";

import useOrderTable from "../../hooks/use-order-table";

const Orders = () => {
  const {
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
  } = useOrderTable();

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
        id={orderId}
      />
      <GenericModal
        show={editModalShow}
        onHide={() => setEditModalShow(false)}
        BodyComponent={EditModalBody}
        title={"Edit order"}
        id={orderId}
      />
    </Fragment>
  );
};

export default Orders;
