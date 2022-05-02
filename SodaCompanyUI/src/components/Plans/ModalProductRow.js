import { useState } from "react";

import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

const ModalProductRow = ({
  products,
  product,
  onRemove,
  onChange,
  procedures,
}) => {
  let filteredProcedures = procedures.filter(
    (procedure) => procedure.productId === product.productId
  );

  return (
    <Row>
      <Col>
        <Form.Label htmlFor="product">Product</Form.Label>
        <Form.Select
          id="product"
          name="productId"
          defaultValue={product.productId}
          disabled
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
          defaultValue={product.quantity}
          onChange={onChange}
        />
      </Col>
      <Col>
        <Form.Label htmlFor="procedure">Procedure</Form.Label>
        <Form.Select
          id="procedure"
          name="workProcedureId"
          defaultValue={""}
          onChange={onChange}
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
        <Button variant="danger" onClick={onRemove}>
          X
        </Button>
      </Col>
    </Row>
  );
};

export default ModalProductRow;
