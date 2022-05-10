import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

const ModalProductRow = ({
  products,
  procedure,
  procedures,
  onRemove,
  onChange,
}) => {
  procedure = procedure === undefined ? "" : procedure;

  const filteredProcedures = procedures.filter(
    (pr) => pr.productId === procedure.productId
  );

  const isDisabledSelectAndDelete = procedure.isNew === undefined;

  return (
    <Row>
      <Col>
        <Form.Label htmlFor="product">Product</Form.Label>
        <Form.Select
          id="product"
          name="productId"
          value={procedure.productId}
          onChange={onChange}
          disabled={isDisabledSelectAndDelete}
          required
        >
          <option value="" disabled>
            Select product
          </option>
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
      <Col xs="2" md="auto" style={{ margin: "30px 0" }}>
        <Button
          variant="danger"
          onClick={onRemove}
          disabled={isDisabledSelectAndDelete}
        >
          X
        </Button>
      </Col>
    </Row>
  );
};

export default ModalProductRow;
