import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";

const GenericModal = (props) => {
  return (
    <Modal
      show={props.show}
      onHide={props.onHide}
      size="lg"
      aria-labelledby="contained-modal-title-vcenter"
      centered
    >
      <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">
          {props.title}
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <props.BodyComponent id={props.id} onHide={props.onHide} />
      </Modal.Body>
    </Modal>
  );
};

export default GenericModal;
