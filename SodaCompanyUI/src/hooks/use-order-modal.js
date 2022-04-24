import { useState } from "react";
import { useDispatch } from "react-redux";

import { addOrder } from "../store/orders/orders-slice";

const useOrderModal = () => {
  const dispatch = useDispatch();

  const [selectedProducts, setSelectedProducts] = useState([
    {
      productId: "",
      quantity: 0,
    },
  ]);

  const [orderName, setOrderName] = useState("");

  const orderNameChangeHandler = (e) => {
    setOrderName(e.target.value);
  };

  const [isButtonDisabled, setIsButtonDisabled] = useState(false);

  const addHandler = () => {
    if (selectedProducts.length === 5) {
      return;
    }

    setSelectedProducts((prevState) => {
      return [
        ...prevState,
        {
          productId: "",
          quantity: 0,
        },
      ];
    });

    if (selectedProducts.length === 4) {
      setIsButtonDisabled(true);
    }
  };

  const removeHandler = (idx) => {
    if (selectedProducts.length === 1) {
      return;
    }
    if (selectedProducts.length === 5) {
      setIsButtonDisabled(false);
    }

    setSelectedProducts((prevState) => {
      const newState = [...prevState];
      newState.splice(idx, 1);
      return newState;
    });
  };

  const changeHandler = (i, e) => {
    if (e.target.name === "quantity" && e.target.value >= 1000000) {
      return;
    }

    const newState = [...selectedProducts];
    newState[i][e.target.name] = e.target.value;
    setSelectedProducts(newState);
  };

  const checkIfValid = () => {
    if (orderName === "") {
      return false;
    }

    for (let i = 0; i < selectedProducts.length; i++) {
      if (
        selectedProducts[i].productId === "" ||
        Number.isNaN(selectedProducts[i].quantity) ||
        selectedProducts[i].quantity < 1
      ) {
        return false;
      }
    }
    return true;
  };

  const submitHandler = (e) => {
    e.preventDefault();

    if (!checkIfValid()) {
      return;
    }

    const timeElapsed = Date.now();
    const today = new Date(timeElapsed);

    const newOrder = {
      Name: orderName,
      CreationDate: today,
      CreatedBy: "9d6f01e7-a53e-4c4a-a9ea-653732fe4af3",
      OrderProducts: selectedProducts,
    };

    dispatch(addOrder(newOrder));
  };
  return {
    selectedProducts,
    isButtonDisabled,
    orderName,
    orderNameChangeHandler,
    addHandler,
    removeHandler,
    changeHandler,
    submitHandler,
  };
};

export default useOrderModal;
