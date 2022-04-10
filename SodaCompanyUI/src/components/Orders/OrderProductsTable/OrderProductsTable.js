import { Container, Row, Col } from "react-bootstrap";

import OrderProducts from "./OrderProducts";

const OrderProductsTable = ({ products }) => {
  return (
    <Container fluid={"md"}>
      <Row>
        <Col>
          <b>#</b>
        </Col>
        <Col>
          <b>Product</b>
        </Col>
        <Col>
          <b>Quantity</b>
        </Col>
      </Row>
      {products.map((product, idx) => (
        <OrderProducts
          key={`Product_${idx}`}
          number={idx + 1}
          product={product}
        />
      ))}
    </Container>
  );
};

export default OrderProductsTable;
