import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";

import { getPlans } from "../store/plans/plans-slice";

const usePlanModal = (
  request,
  plan,
  initialPlanName,
  initialOrderId,
  initialStartDate,
  initialEndDate,
  initialProcedures,
  hideModal
) => {
  const dispatch = useDispatch();

  const products = useSelector((state) => state.products.products);
  const orders = useSelector((state) => state.orders.orders);
  const workProcedures = useSelector((state) => state.products.workProcedures);
  const pageInfo = useSelector((state) => state.plans.pageInfo);

  initialPlanName = initialPlanName === undefined ? "" : initialPlanName;

  initialOrderId = initialOrderId === undefined ? "" : initialOrderId;

  const initialOrder =
    initialOrderId === undefined
      ? {}
      : orders.find((order) => order.id === initialOrderId);

  initialStartDate =
    initialStartDate === undefined
      ? ""
      : `${initialStartDate.split("-")[2]}-${initialStartDate.split("-")[1]}-${
          initialStartDate.split("-")[0]
        }`;

  initialEndDate =
    initialEndDate === undefined
      ? ""
      : `${initialEndDate.split("-")[2]}-${initialEndDate.split("-")[1]}-${
          initialEndDate.split("-")[0]
        }`;

  const initialPlanProducts =
    initialProcedures === undefined
      ? []
      : initialProcedures.map((procedure) => {
          return {
            productId: procedure.workProcedureProductId,
            productName: procedure.workProcedureProductName,
            quantity: procedure.quantity,
          };
        });

  initialProcedures =
    initialProcedures === undefined
      ? []
      : initialProcedures.map((procedure) => {
          return {
            quantity: procedure.quantity,
            workProcedureId: procedure.workProcedureId,
          };
        });

  const [planName, setPlanName] = useState(initialPlanName);
  const [orderId, setOrderId] = useState(initialOrderId);
  const [order, setOrder] = useState(initialOrder);
  const [startDate, setStartDate] = useState(initialStartDate);
  const [endDate, setEndDate] = useState(initialEndDate);
  const [planProducts, setPlanProducts] = useState(initialPlanProducts);
  const [planProcedures, setPlanProcedures] = useState(initialProcedures);

  const planNameChangeHandler = (e) => {
    setPlanName(e.target.value);
  };

  const orderChangeHandler = (e) => {
    const order = orders.find((order) => order.id === e.target.value);
    const orderProducts = order.products;

    setPlanProcedures((prevState) => {
      let arr = [];

      for (const key in orderProducts) {
        arr.push({
          quantity: orderProducts[key].quantity,
          workProcedureId: "",
        });
      }
      return arr;
    });
    setOrderId(e.target.value);
    setOrder(order);
    const splitDate = order.dateCreated.split("-");
    const startDate = `${splitDate[2]}-${splitDate[1]}-${splitDate[0]}`;
    setStartDate(startDate);
    setPlanProducts(orderProducts);
  };

  const startDateChangeHandler = (e) => {
    setStartDate(e.target.value);
  };

  const endDateChangeHandler = (e) => {
    setEndDate(e.target.value);
  };

  const onChangeProcedures = (i, e) => {
    if (
      e.target.name === "quantity" &&
      e.target.value >= 1000000 &&
      e.target.value <= 0
    ) {
      return;
    }

    const newState = [...planProcedures];
    newState[i][e.target.name] = e.target.value;
    setPlanProcedures(newState);
  };

  const resetFields = () => {
    setPlanName("");
    setStartDate("");
    setEndDate("");
    setOrderId("");
    setOrder({});
    setPlanProcedures([]);
    setPlanProducts([]);
  };

  /******  Will be implemented after edit ******/

  // const checkPlanProductsQuantity = () => {
  //   let copyOrderProducts = JSON.parse(JSON.stringify(order.products));

  //   for (const key in planProducts) {
  //     const idx = copyOrderProducts.findIndex(
  //       (product) => product.productId === planProducts[key].productId
  //     );
  //     copyOrderProducts[idx].quantity -= planProducts[key].quantity;
  //   }

  //   for (const key in copyOrderProducts) {
  //     if (copyOrderProducts[key].quantity !== 0) {
  //       console.log("false");
  //       return false;
  //     }
  //   }

  //   console.log("true");
  //   return true;
  // };

  const checkPlanProcedures = () => {
    for (const key in planProcedures) {
      if (
        planProcedures[key].quantity <= 0 ||
        planProcedures.workProcedureId === ""
      ) {
        return false;
      }
    }

    return true;
  };

  const checkEmptyFields = () => {
    if (
      planName === "" ||
      startDate === "" ||
      endDate === "" ||
      orderId === "" ||
      planProcedures.length === 0
    ) {
      return false;
    }
    return true;
  };

  const checkDateValidity = () => {
    let start = new Date(startDate);
    let end = new Date(endDate);

    if (start < end) {
      return true;
    }
    return false;
  };

  const submitHandler = () => {
    if (!checkEmptyFields() || !checkPlanProcedures() || !checkDateValidity()) {
      return;
    }

    const newPlan = {
      id: plan === undefined ? "" : plan.id,
      name: planName,
      creationDate: startDate,
      productionDeadline: endDate,
      createdBy: "d29a42c5-8f94-4b2d-a96c-632ed7ca9f22", // no auth, so hardcode user which sends the req
      productionOrderId: orderId,
      planWorkProcedures: planProcedures,
    };
    dispatch(request(newPlan));
    if (!plan) {
      dispatch(getPlans(pageInfo.pageNumber));
      resetFields(); // if in add mode, reset fields
    } else {
      hideModal(); // if in edit mode, hide modal
    }
  };

  return {
    planName,
    planNameChangeHandler,
    products,
    orders,
    orderId,
    orderChangeHandler,
    planProducts,
    planProcedures,
    startDate,
    endDate,
    startDateChangeHandler,
    endDateChangeHandler,
    workProcedures,
    onChangeProcedures,
    submitHandler,
  };
};

export default usePlanModal;
