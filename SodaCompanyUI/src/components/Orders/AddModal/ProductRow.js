import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

const ProductRow = ({ product, onRemove, onChange }) => {
  return (
    <Row>
      <Col>
        <Form.Label htmlFor="select">Product</Form.Label>
        <Form.Select
          id="select"
          name="name"
          value={product.name}
          onChange={onChange}
        >
          <option>Select</option>
          <option>Hello</option>
          <option>Hello2</option>
        </Form.Select>
      </Col>
      <Col>
        <Form.Label htmlFor="quantity">Quantity</Form.Label>
        <Form.Control
          id="quantity"
          name="quantity"
          type="text"
          value={product.quantity}
          onChange={onChange}
        />
      </Col>
      <Col xs="2" md="auto" style={{ margin: "30px 0" }}>
        <Button variant="danger" onClick={onRemove}>
          X
        </Button>
      </Col>
    </Row>
  );
};

export default ProductRow;
