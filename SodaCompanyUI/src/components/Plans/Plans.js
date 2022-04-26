import BootstrapTable from "react-bootstrap-table-next";
import Button from "react-bootstrap/Button";

import { useSelector } from "react-redux";

import usePlanTable from "../../hooks/use-plan-table";

const Plans = () => {
  const { plans, columns } = usePlanTable();

  return (
    <BootstrapTable
      bootstrap4
      keyField="id"
      data={plans}
      columns={columns}
      // expandRow={expandRow}
    />
  );
};

export default Plans;
