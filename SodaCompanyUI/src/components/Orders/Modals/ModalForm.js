import { useState } from "react";

import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

import ModalProductRow from "./ModalProductRow";

const ModalForm = ({
  orderName,
  orderNameChangeHandler,
  selectedProducts,
  products,
  removeHandler,
  changeHandler,
  addHandler,
  isButtonDisabled,
  submitHandler,
  buttonText,
}) => {
  const [validated, setValidated] = useState(false);

  const handleSubmit = (event) => {
    event.preventDefault();
    const form = event.currentTarget;
    if (form.checkValidity() === false) {
      event.stopPropagation();
    } else {
      submitHandler();
    }

    setValidated(true);
  };

  return (
    <Form noValidate validated={validated} onSubmit={handleSubmit}>
      <Row>
        <Col>
          <Form.Label htmlFor="orderNameId">Order Name</Form.Label>
          <Form.Control
            id="orderNameId"
            type="text"
            value={orderName}
            onChange={orderNameChangeHandler}
            required
          />
        </Col>
      </Row>
      {selectedProducts.map((selected, idx) => {
        return (
          <ModalProductRow
            key={`ProductRow_${idx}`}
            products={products}
            product={selected}
            onRemove={() => {
              removeHandler(idx);
            }}
            onChange={(e) => changeHandler(idx, e)}
          />
        );
      })}
      <hr />
      <Row>
        <Col>
          <Button
            variant="primary"
            size="lg"
            onClick={addHandler}
            disabled={isButtonDisabled}
          >
            +
          </Button>
        </Col>
      </Row>
      <Row>
        <Col>
          <Button
            className="float-end"
            variant="primary"
            size="md"
            type="submit"
          >
            {buttonText}
          </Button>
        </Col>
      </Row>
    </Form>
  );
};

export default ModalForm;
