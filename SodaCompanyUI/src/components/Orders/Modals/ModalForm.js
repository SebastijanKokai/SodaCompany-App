import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

import ProductRow from "./ProductRow";

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
            {buttonText}
          </Button>
        </Col>
      </Row>
    </Form>
  );
};

export default ModalForm;
