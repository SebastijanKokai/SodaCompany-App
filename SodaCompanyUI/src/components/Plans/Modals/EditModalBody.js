import { useSelector } from "react-redux";

import ModalForm from "./ModalForm";
import usePlanModal from "../../../hooks/use-plan-modal";

import { editPlan } from "../../../store/plans/plans-slice";

const EditModalBody = ({ id, onHide }) => {
  const plans = useSelector((state) => state.plans.plans);
  const plan = plans.find((plan) => plan.id === id);
  const initialPlanName = plan.planName;
  const initialStartDate = plan.startDate;
  const initialEndDate = plan.endDate;
  const initialOrderId = plan.orderId;
  const initialProcedures = plan.planWorkProcedures;

  const {
    products,
    planName,
    planNameChangeHandler,
    orders,
    orderId,
    orderChangeHandler,
    planProducts,
    planProcedures,
    startDate,
    startDateChangeHandler,
    endDate,
    endDateChangeHandler,
    workProcedures,
    onChangeProcedures,
    submitHandler,
  } = usePlanModal(
    editPlan,
    plan,
    initialPlanName,
    initialOrderId,
    initialStartDate,
    initialEndDate,
    initialProcedures,
    onHide
  );

  return (
    <ModalForm
      products={products}
      planName={planName}
      planNameChangeHandler={planNameChangeHandler}
      orders={orders}
      orderId={orderId}
      orderChangeHandler={orderChangeHandler}
      planProducts={planProducts}
      planProcedures={planProcedures}
      startDate={startDate}
      startDateChangeHandler={startDateChangeHandler}
      endDate={endDate}
      endDateChangeHandler={endDateChangeHandler}
      workProcedures={workProcedures}
      onChangeProcedures={onChangeProcedures}
      submitHandler={submitHandler}
      buttonText={"Modify plan"}
    />
  );
};

export default EditModalBody;
