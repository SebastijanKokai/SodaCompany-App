import { useSelector } from "react-redux";

import useOrderModal from "../../../hooks/use-order-modal";

import { editOrder } from "../../../store/orders/orders-slice";
import ModalForm from "./ModalForm";

const EditModalBody = ({ id }) => {
  const products = useSelector((state) => state.products.products);
  const orders = useSelector((state) => state.orders.orders);
  const order = orders.find((order) => order.id === id);
  const initialOrderProducts = order.products;
  const initialOrderName = order.orderName;

  const {
    selectedProducts,
    isButtonDisabled,
    orderName,
    orderNameChangeHandler,
    addHandler,
    removeHandler,
    changeHandler,
    submitHandler,
  } = useOrderModal(editOrder, initialOrderProducts, initialOrderName, id);

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
      buttonText="Modify order"
    />
  );
};

export default EditModalBody;
