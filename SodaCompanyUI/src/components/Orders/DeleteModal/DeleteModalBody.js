import Button from "react-bootstrap/Button";

import { useDispatch } from "react-redux";
import { deleteOrder } from "../../../store/orders/orders-slice";

const DeleteModalBody = ({ orderId, onHide }) => {
  const dispatch = useDispatch();
  const handleDelete = () => {
    dispatch(deleteOrder(orderId));
    onHide();
  };

  return (
    <div>
      <p>Are you sure?</p>
      <Button variant="primary" className="float-end" onClick={handleDelete}>
        Confirm
      </Button>
    </div>
  );
};

export default DeleteModalBody;
