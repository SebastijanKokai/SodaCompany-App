import { useState } from "react";
import { useDispatch } from "react-redux";

const useOrderModal = (request, products, name, orderId) => {
  const dispatch = useDispatch();

  let initialProducts =
    products === undefined
      ? [
          {
            productId: "",
            quantity: 0,
          },
        ]
      : JSON.parse(JSON.stringify(products));
  const [selectedProducts, setSelectedProducts] = useState(initialProducts);

  let initialName = name === undefined ? "" : name;

  const [orderName, setOrderName] = useState(initialName);

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

  const resetFields = () => {
    setOrderName("");
    setSelectedProducts((prevState) => {
      const newState = [...prevState];
      while (newState.length > 1) {
        newState.pop();
      }
      newState[0].quantity = 0;
      return newState;
    });
  };

  const submitHandler = (e) => {
    e.preventDefault();

    if (!checkIfValid()) {
      return;
    }

    const timeElapsed = Date.now();
    const today = new Date(timeElapsed);

    const newOrder = {
      Id: orderId,
      Name: orderName,
      CreationDate: today.toISOString(),
      CreatedBy: "d29a42c5-8f94-4b2d-a96c-632ed7ca9f22",
      OrderProducts: selectedProducts,
    };

    dispatch(request(newOrder));
    // resetFields();
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
