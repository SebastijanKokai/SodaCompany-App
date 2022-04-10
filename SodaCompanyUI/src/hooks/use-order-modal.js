import { useState } from "react";

const useOrderModal = () => {
  const [selectedProducts, setSelectedProducts] = useState([
    {
      name: "",
      quantity: 0,
    },
  ]);

  const [isButtonDisabled, setIsButtonDisabled] = useState(false);

  const addHandler = () => {
    if (selectedProducts.length === 5) {
      return;
    }

    setSelectedProducts((prevState) => {
      return [
        ...prevState,
        {
          name: "",
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

    console.log(selectedProducts);
    setSelectedProducts((prevState) => {
      const newState = [...prevState];
      newState.splice(idx, 1);
      return newState;
    });
  };

  const changeHandler = (i, e) => {
    console.log(selectedProducts);
    const newState = [...selectedProducts];
    newState[i][e.target.name] = e.target.value;
    setSelectedProducts(newState);
  };

  const submitHandler = (e) => {
    e.preventDefault();
    console.log(JSON.stringify(selectedProducts));
  };
  return {
    selectedProducts,
    isButtonDisabled,
    addHandler,
    removeHandler,
    changeHandler,
    submitHandler,
  };
};

export default useOrderModal;
