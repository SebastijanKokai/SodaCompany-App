import { useSelector } from "react-redux";

import useOrderModal from "../../../hooks/use-order-modal";

import { addOrder } from "../../../store/orders/orders-slice";

import ModalForm from "./ModalForm";

const AddModalBody = () => {
  const {
    selectedProducts,
    usedProducts,
    isButtonDisabled,
    orderName,
    orderNameChangeHandler,
    addHandler,
    removeHandler,
    changeHandler,
    submitHandler,
  } = useOrderModal(addOrder);

  const allProducts = useSelector((state) => state.products.products);
  const availableProducts = allProducts.filter(
    (product) =>
      !usedProducts.some((usedProduct) => product.id === usedProduct.productId)
  );

  return (
    <ModalForm
      orderName={orderName}
      orderNameChangeHandler={orderNameChangeHandler}
      selectedProducts={selectedProducts}
      products={allProducts}
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
