const OrderProducts = ({ number, product: { name, quantity } }) => {
  return (
    <tr>
      <td colSpan={2}>{number}</td>
      <td colSpan={2}>{name}</td>
      <td colSpan={2}>{quantity}</td>
    </tr>
  );
};

export default OrderProducts;
