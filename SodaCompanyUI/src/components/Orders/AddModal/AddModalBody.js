import { useSelector } from "react-redux";

import useOrderModal from "../../../hooks/use-order-modal";

import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

import ProductRow from "./ProductRow";

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
  } = useOrderModal();

  const products = useSelector((state) => state.products.products);

  return (
    <Form>
      <Row>
        <Col>
          <Form.Label htmlFor="orderNameId">Order Name</Form.Label>
          <Form.Control
            id="orderNameId"
            type="text"
            value={orderName}
            onChange={orderNameChangeHandler}
          />
        </Col>
      </Row>
      {selectedProducts.map((selected, idx) => {
        return (
          <ProductRow
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
            onClick={submitHandler}
          >
            Add Order
          </Button>
        </Col>
      </Row>
    </Form>
  );
};

export default AddModalBody;
