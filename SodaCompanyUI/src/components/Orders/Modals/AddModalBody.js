import { useSelector } from "react-redux";

import useOrderModal from "../../../hooks/use-order-modal";

import { addOrder } from "../../../store/orders/orders-slice";

import ModalForm from "./ModalForm";

const AddModalBody = () => {
  const {
    selectedProducts,
    isButtonDisabled,
    orderName,
    orderNameChangeHandler,
    addHandler,
    removeHandler,
    changeHandler,
    submitHandler,
  } = useOrderModal(addOrder);

  const products = useSelector((state) => state.products.products);

  return (
    <ModalForm
      orderName={orderName}
      orderNameChangeHandler={orderNameChangeHandler}
      selectedProducts={selectedProducts}
      products={products}
      removeHandler={removeHandler}
      changeHandler={changeHandler}
      addHandler={addHandler}
      isButtonDisabled={isButtonDisabled}
      submitHandler={submitHandler}
      buttonText="Add order"
    />
  );
};

export default AddModalBody;
