import { useState } from "react";
import { useSelector, useDispatch } from "react-redux";

import PlanProductsTable from "../components/Plans/PlanProductsTable/PlanProductsTable";

import Button from "react-bootstrap/Button";

const usePlanTable = () => {
  const plans = useSelector((state) => state.plans.plans);
  const pageInfo = useSelector((state) => state.plans.pageInfo);
  const [planId, setPlanId] = useState("");
  const [addModalShow, setAddModalShow] = useState(false);
  const [deleteModalShow, setDeleteModalShow] = useState(false);

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
      dataField: "planName",
      text: "Plan Name",
      sort: true,
    },
    {
      dataField: "orderId",
      text: "Order Id",
      sort: true,
    },
    {
      dataField: "startDate",
      text: "Start Date",
      sort: true,
    },
    {
      dataField: "endDate",
      text: "End Date",
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
                setPlanId(row.id);
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
      console.log(row.planWorkProcedures);
      return <PlanProductsTable workProcedures={row.planWorkProcedures} />;
    },
    showExpandColumn: true,
    expandByColumnOnly: true,
  };

  return {
    plans,
    planId,
    columns,
    pageInfo,
    addModalShow,
    setAddModalShow,
    deleteModalShow,
    setDeleteModalShow,
    expandRow,
  };
};

export default usePlanTable;
