import { Fragment } from "react";

import BootstrapTable from "react-bootstrap-table-next";
import Button from "react-bootstrap/Button";
import { useSelector } from "react-redux";

import usePlanTable from "../../hooks/use-plan-table";

import GenericModal from "../Modal/GenericModal";
import AddModalBody from "./AddModalBody";
import PaginationComponent from "../UI/Pagination/PaginationComponent";

const Plans = () => {
  const { plans, columns, pageInfo, addModalShow, setAddModalShow } =
    usePlanTable();

  return (
    <Fragment>
      <BootstrapTable
        bootstrap4
        keyField="id"
        data={plans}
        columns={columns}
        // expandRow={expandRow}
      />
      <PaginationComponent pageInfo={pageInfo} changePageHandler={() => {}} />
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
        title={"Add Plan"}
      />
    </Fragment>
  );
};

export default Plans;
