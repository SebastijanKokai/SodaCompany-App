import { Row, Col } from "react-bootstrap";

const OrderProducts = ({ number, product: { productName, quantity } }) => {
  return (
    <Row>
      <Col>{number}</Col>
      <Col>{productName}</Col>
      <Col>{quantity}</Col>
    </Row>
  );
};

export default OrderProducts;
