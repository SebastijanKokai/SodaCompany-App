import { useDispatch } from "react-redux";
import { deletePlan } from "../../store/plans/plans-slice";

import Button from "react-bootstrap/Button";

const DeleteModalBody = ({ id, onHide }) => {
  const dispatch = useDispatch();
  const handleDelete = () => {
    dispatch(deletePlan(id));
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
