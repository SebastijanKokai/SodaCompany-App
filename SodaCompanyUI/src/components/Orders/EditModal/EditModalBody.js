import { useSelector } from "react-redux";

import useOrderModal from "../../../hooks/use-order-modal";

import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

import ProductRow from "../AddModal/ProductRow";

import { editOrder } from "../../../store/orders/orders-slice";

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
            Modify Changes
          </Button>
        </Col>
      </Row>
    </Form>
  );
};

export default EditModalBody;
