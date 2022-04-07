import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

const AddModalBody = () => {
  return (
    <Form>
      <Row>
        <Col>
          <Form.Label htmlFor="orderNameId">Order Name</Form.Label>
          <Form.Control id="orderNameId" type="text" />
        </Col>
      </Row>
      <Row>
        <Col>
          <Form.Label htmlFor="select1">Product</Form.Label>
          <Form.Select id="select1" aria-label="Default select example">
            <option>Select</option>
            <option>Hello</option>
            <option>Hello2</option>
          </Form.Select>
        </Col>
        <Col>
          <Form.Label htmlFor="quantity1">Quantity</Form.Label>
          <Form.Control type="text" />
        </Col>
      </Row>
      <Row>
        <Col>
          <Button variant="primary" size="lg">
            +
          </Button>
        </Col>
      </Row>
    </Form>
  );
};

export default AddModalBody;
