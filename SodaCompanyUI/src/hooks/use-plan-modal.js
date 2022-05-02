import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";

import { addPlan } from "../store/plans/plans-slice";

const usePlanModal = () => {
  const dispatch = useDispatch();

  const products = useSelector((state) => state.products.products);
  const orders = useSelector((state) => state.orders.orders);
  const workProcedures = useSelector(
    (state) => state.workProcedures.workProcedures
  );

  const [planName, setPlanName] = useState("");
  const [orderId, setOrderId] = useState("");
  const [orderProducts, setOrderProducts] = useState([]);
  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");
  const [planProcedures, setPlanProcedures] = useState([]);

  const planNameChangeHandler = (e) => {
    setPlanName(e.target.value);
  };

  const orderChangeHandler = (e) => {
    setOrderId(e.target.value);

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

    setOrderProducts(orderProducts);
  };

  const startDateChangeHandler = (e) => {
    setStartDate(e.target.value);
  };

  const endDateChangeHandler = (e) => {
    setEndDate(e.target.value);
  };

  const onChangeProcedures = (i, e) => {
    if (e.target.name === "quantity" && e.target.value >= 1000000) {
      return;
    }

    const newState = [...planProcedures];
    newState[i][e.target.name] = e.target.value;
    setPlanProcedures(newState);
  };

  const checkFields = () => {
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
    if (!checkFields() || !checkDateValidity()) {
      return;
    }
    // check if product quantity in plan is equal to order quantity

    const newPlan = {
      name: planName,
      creationDate: startDate,
      productionDeadline: endDate,
      createdBy: "d29a42c5-8f94-4b2d-a96c-632ed7ca9f22", // no auth, so hardcode user which sends the req
      productionOrderId: orderId,
      planWorkProcedures: planProcedures,
    };

    dispatch(addPlan(newPlan));
  };

  return {
    planName,
    planNameChangeHandler,
    products,
    orders,
    orderId,
    orderChangeHandler,
    orderProducts,
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
