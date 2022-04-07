import { Table } from "react-bootstrap";

import OrderProducts from "./OrderProducts";

const OrderProductsTable = ({ products }) => {
  return (
    <Table>
      <thead>
        <tr>
          <th colSpan={2}>#</th>
          <th colSpan={2}>Product</th>
          <th colSpan={2}>Quantity</th>
        </tr>
      </thead>
      <tbody>
        {products.map((product, idx) => (
          <OrderProducts
            key={`Product_${idx}`}
            number={idx + 1}
            product={product}
          />
        ))}
      </tbody>
    </Table>
  );
};

export default OrderProductsTable;
