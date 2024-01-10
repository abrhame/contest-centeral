import Modal from "react-modal";

Modal.setAppElement("#__next");

interface CustomModalProps {
  isOpen: boolean;
  onRequestClose: () => void;
  children: React.ReactNode;
}

const CustomModal: React.FC<CustomModalProps> = ({
  isOpen,
  onRequestClose,
  children,
}) => {
  return (
    <Modal
      isOpen={isOpen}
      onRequestClose={onRequestClose}
      contentLabel="Example Modal"
      className="fixed inset-1/2 transform -translate-x-1/2 -translate-y-1/2 bg-white p-8 rounded-md"
      overlayClassName="fixed inset-0 bg-black opacity-50"
    >
      <div className="space-y-4">
        {children}
        <button
          className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"
          onClick={onRequestClose}
        >
          Close Modal
        </button>
      </div>
    </Modal>
  );
};

export default CustomModal;
