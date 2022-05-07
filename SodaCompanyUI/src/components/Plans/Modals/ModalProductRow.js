import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

const ModalProductRow = ({
  product,
  products,
  procedure,
  procedures,
  onRemove,
  onChange,
}) => {
  let filteredProcedures = procedures.filter(
    (procedure) => procedure.productId === product.productId
  );

  procedure = procedure === undefined ? "" : procedure;

  return (
    <Row style={{ marginBottom: "2%" }}>
      <Col>
        <Form.Label htmlFor="product">Product</Form.Label>
        <Form.Select
          id="product"
          name="productId"
          defaultValue={product.productId}
          disabled
          required
        >
          {products.map((product, idx) => (
            <option key={`Product_${idx}`} value={product.id}>
              {product.name}
            </option>
          ))}
        </Form.Select>
      </Col>
      <Col>
        <Form.Label htmlFor="quantity">Quantity</Form.Label>
        <Form.Control
          id="quantity"
          name="quantity"
          type="text"
          maxLength="6"
          value={procedure.quantity}
          onChange={onChange}
          required
        />
      </Col>
      <Col>
        <Form.Label htmlFor="procedure">Procedure</Form.Label>
        <Form.Select
          id="procedure"
          name="workProcedureId"
          value={procedure.workProcedureId}
          onChange={onChange}
          required
        >
          <option value="" disabled>
            Select procedure
          </option>
          {filteredProcedures.map((procedure, idx) => (
            <option key={`Procedure_${idx}`} value={procedure.id}>
              {procedure.name}
            </option>
          ))}
        </Form.Select>
      </Col>
      {/* <Col xs="2" md="auto" style={{ margin: "30px 0" }}>
        <Button variant="danger" onClick={onRemove}>
          X
        </Button>
      </Col> */}
    </Row>
  );
};

export default ModalProductRow;
