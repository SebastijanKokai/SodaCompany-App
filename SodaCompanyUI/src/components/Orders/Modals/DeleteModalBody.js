import Button from "react-bootstrap/Button";

import { useDispatch } from "react-redux";
import { deleteOrder } from "../../../store/orders/orders-slice";

const DeleteModalBody = ({ id, onHide }) => {
  const dispatch = useDispatch();
  const handleDelete = () => {
    dispatch(deleteOrder(id));
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
