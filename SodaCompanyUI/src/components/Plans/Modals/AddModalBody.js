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
    planProcedures,
    startDate,
    startDateChangeHandler,
    endDate,
    endDateChangeHandler,
    workProcedures,
    onChangeProcedures,
    submitHandler,
    addHandler,
    removeHandler,
  } = usePlanModal(addPlan);

  return (
    <ModalForm
      products={products}
      planName={planName}
      planNameChangeHandler={planNameChangeHandler}
      orders={orders}
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
      buttonText={"Add plan"}
      addHandler={addHandler}
      removeHandler={removeHandler}
    />
  );
};

export default AddModalBody;
