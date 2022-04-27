import { useState } from "react";
import { useSelector, useDispatch } from "react-redux";

import Button from "react-bootstrap/Button";

const usePlanTable = () => {
  const plans = useSelector((state) => state.plans.plans);
  const pageInfo = useSelector((state) => state.plans.pageInfo);
  const [addModalShow, setAddModalShow] = useState(false);

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
            >
              Delete
            </Button>
            <Button variant="warning">Edit</Button>
          </div>
        );
      },
    },
  ];

  return {
    plans,
    columns,
    pageInfo,
    addModalShow,
    setAddModalShow,
  };
};

export default usePlanTable;
