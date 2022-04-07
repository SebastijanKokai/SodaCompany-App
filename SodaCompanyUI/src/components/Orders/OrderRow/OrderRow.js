import { Fragment } from "react";

import OrderProductsTable from "./OrderProductsTable/OrderProductsTable";

const OrderRow = ({
  order: { manager, orderName, totalProducts, dateCreated, products },
}) => {
  return (
    <Fragment>
      <tr>
        <td>{manager}</td>
        <td>{orderName}</td>
        <td>{totalProducts}</td>
        <td>{dateCreated}</td>
        <td>Edit</td>
        <td>Delete</td>
      </tr>
      <OrderProductsTable products={products} />
    </Fragment>
  );
};

export default OrderRow;
