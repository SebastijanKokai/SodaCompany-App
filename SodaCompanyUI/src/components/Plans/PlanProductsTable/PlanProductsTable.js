import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";

import PlanProducts from "./PlanProducts";

const PlanProductsTable = ({ workProcedures }) => {
  return (
    <Container fluid="md">
      <Row>
        <Col>
          <b>#</b>
        </Col>
        <Col>
          <b>Product</b>
        </Col>
        <Col>
          <b>Procedure name</b>
        </Col>
        <Col>
          <b>Quantity</b>
        </Col>
      </Row>
      {workProcedures.map((wp, idx) => (
        <PlanProducts
          key={`PlanProcedure_${idx}`}
          number={idx + 1}
          workProcedure={wp}
        />
      ))}
    </Container>
  );
};

export default PlanProductsTable;
