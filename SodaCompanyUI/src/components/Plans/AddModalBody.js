import { useSelector } from "react-redux";

import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

import ModalProductRow from "./ModalProductRow";

import usePlanModal from "../../hooks/use-plan-modal";

const AddModalBody = () => {
  const {
    products,
    planName,
    planNameChangeHandler,
    orders,
    orderId,
    orderChangeHandler,
    orderProducts,
    startDate,
    startDateChangeHandler,
    endDate,
    endDateChangeHandler,
    workProcedures,
    onChangeProcedures,
    submitHandler,
  } = usePlanModal();

  return (
    <Form>
      <Row>
        <Col>
          <Form.Label htmlFor="planNameId">Plan Name</Form.Label>
          <Form.Control
            id="planNameId"
            type="text"
            value={planName}
            onChange={planNameChangeHandler}
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
          />
        </Col>
        <Col>
          <Form.Label htmlFor="endDate">End date</Form.Label>
          <Form.Control
            type="date"
            value={endDate}
            onChange={endDateChangeHandler}
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
            defaultValue={""}
            onChange={orderChangeHandler}
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
      {orderProducts.map((orderProduct, idx) => (
        <ModalProductRow
          key={`ProductRow_${idx}`}
          products={products}
          product={orderProduct}
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
            onClick={submitHandler}
          >
            Add Plan
          </Button>
        </Col>
      </Row>
    </Form>
  );
};

export default AddModalBody;
