import { useState } from "react";

import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

import ModalProductRow from "./ModalProductRow";

const ModalForm = ({
  products,
  planName,
  planNameChangeHandler,
  orders,
  orderChangeHandler,
  orderId,
  planProducts,
  startDate,
  startDateChangeHandler,
  endDate,
  endDateChangeHandler,
  workProcedures,
  onChangeProcedures,
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
          <Form.Label htmlFor="planNameId">Plan Name</Form.Label>
          <Form.Control
            id="planNameId"
            type="text"
            value={planName}
            onChange={planNameChangeHandler}
            required
          />
        </Col>
      </Row>
      <hr />
      <Row>
        <Col>
          <Form.Label htmlFor="startDate">Start date</Form.Label>
          <Form.Control
            type="date"
            value={startDate}
            onChange={startDateChangeHandler}
            required
            disabled
          />
        </Col>
        <Col>
          <Form.Label htmlFor="endDate">End date</Form.Label>
          <Form.Control
            type="date"
            value={endDate}
            onChange={endDateChangeHandler}
            required
          />
        </Col>
      </Row>
      <hr />
      <Row>
        <Col>
          <Form.Label htmlFor="select">Order</Form.Label>
          <Form.Select
            id="select"
            name="orderId"
            defaultValue={orderId === undefined ? "" : orderId}
            onChange={orderChangeHandler}
            required
          >
            <option value="" disabled>
              Select Order
            </option>
            {orders.map((order, idx) => (
              <option key={`Option_${idx}`} value={order.id}>
                {order.orderName}
              </option>
            ))}
          </Form.Select>
        </Col>
      </Row>
      <hr />
      {planProducts.map((planProduct, idx) => (
        <ModalProductRow
          key={`ProductRow_${idx}`}
          products={products}
          product={planProduct}
          onRemove={() => {}}
          onChange={(e) => onChangeProcedures(idx, e)}
          procedures={workProcedures}
          idx={idx}
        />
      ))}
      {/* <Row>
    <Col>
      <Button
        variant="primary"
        size="lg"
        onClick={() => {}}
        disabled={false}
      >
        +
      </Button>
    </Col>
  </Row> */}
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
