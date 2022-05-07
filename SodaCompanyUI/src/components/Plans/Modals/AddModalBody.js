import usePlanModal from "../../../hooks/use-plan-modal";

import ModalForm from "./ModalForm";

import { addPlan } from "../../../store/plans/plans-slice";

const AddModalBody = () => {
  const {
    products,
    planName,
    planNameChangeHandler,
    orders,
    orderChangeHandler,
    planProducts,
    startDate,
    startDateChangeHandler,
    endDate,
    endDateChangeHandler,
    workProcedures,
    onChangeProcedures,
    submitHandler,
  } = usePlanModal(addPlan);

  return (
    <ModalForm
      products={products}
      planName={planName}
      planNameChangeHandler={planNameChangeHandler}
      orders={orders}
      orderChangeHandler={orderChangeHandler}
      planProducts={planProducts}
      startDate={startDate}
      startDateChangeHandler={startDateChangeHandler}
      endDate={endDate}
      endDateChangeHandler={endDateChangeHandler}
      workProcedures={workProcedures}
      onChangeProcedures={onChangeProcedures}
      submitHandler={submitHandler}
      buttonText={"Add plan"}
    />
  );
};

export default AddModalBody;
