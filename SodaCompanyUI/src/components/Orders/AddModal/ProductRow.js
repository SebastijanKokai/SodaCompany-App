import { useState } from "react";

import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

const ProductRow = ({
  products,
  usedProducts,
  product,
  onRemove,
  onChange,
}) => {
  // const [dropdownArray, setDropdownArray] = useState(products);
  // const [selectedDropdownArray, setSelectedDropdownArray] = useState(usedProducts);
  // const selectedDropdownArray = usedProducts;
  // const dropdownArray = products.filter(
  //   (product) =>
  //     !selectedDropdownArray.includes(product.id) ||
  //     product === selectedDropdownArray[0]
  // );

  // console.log(selectedDropdownArray);
  // console.log(dropdownArray);

  return (
    <Row>
      <Col>
        <Form.Label htmlFor="select">Product</Form.Label>
        {/* <Form.Select
          id="select"
          name="productId"
          // defaultValue={product.productId}
          value={selectedDropdownArray[0] || ""}
          onChange={onChange}
        >
          <option value="" disabled>
            Select product
          </option>
          {dropdownArray.map((product, idx) => (
            <option key={`Option_${idx}`} value={product.id}>
              {product.name}
            </option>
          ))}
        </Form.Select> */}
        <Form.Select
          id="select"
          name="productId"
          defaultValue={product.productId}
          onChange={onChange}
        >
          <option value="" disabled>
            Select product
          </option>
          {products.map((product, idx) => (
            <option key={`Option_${idx}`} value={product.id}>
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
          type="number"
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
