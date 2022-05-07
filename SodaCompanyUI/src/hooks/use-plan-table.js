import { useState } from "react";
import { useSelector, useDispatch } from "react-redux";

import { getPlans } from "../store/plans/plans-slice";

import PlanProductsTable from "../components/Plans/PlanProductsTable/PlanProductsTable";

import Button from "react-bootstrap/Button";

const usePlanTable = () => {
  const dispatch = useDispatch();

  const plans = useSelector((state) => state.plans.plans);
  const pageInfo = useSelector((state) => state.plans.pageInfo);
  const [planId, setPlanId] = useState("");
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
            <Button
              variant="warning"
              onClick={() => {
                setPlanId(row.id);
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
      return <PlanProductsTable workProcedures={row.planWorkProcedures} />;
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

    dispatch(getPlans(pageNumber));
  };

  return {
    plans,
    planId,
    columns,
    expandRow,
    pageInfo,
    addModalShow,
    setAddModalShow,
    deleteModalShow,
    setDeleteModalShow,
    editModalShow,
    setEditModalShow,
    changePageHandler,
  };
};

export default usePlanTable;
