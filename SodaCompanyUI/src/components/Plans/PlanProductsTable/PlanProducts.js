import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";

const PlanProducts = ({
  number,
  workProcedure: {
    workProcedureProductName: productName,
    workProcedureName: procedureName,
    quantity,
  },
}) => {
  return (
    <Row>
      <Col>{number}</Col>
      <Col>{productName}</Col>
      <Col xs={4}>{procedureName}</Col>
      <Col>{quantity}</Col>
    </Row>
  );
};

export default PlanProducts;
