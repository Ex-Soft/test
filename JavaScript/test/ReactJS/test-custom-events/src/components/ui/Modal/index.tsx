import { useState } from "react";
import ReactModal from "react-modal";
import { useEventListener } from "../../../hooks/useEventListener/useEventListener";
import "./index.css";

export const Modal = () => {
  const [isOpen, setIsOpen] = useState(false);

  useEventListener("modal-event", ({ action }) => {
    console.log(action);
    switch (action) {
      case "open":
        setIsOpen(true);
        break;
      case "close":
        setIsOpen(false);
        break;
    }
  });

  return (
    <div className="modal-container">
      <h1>Modal Container</h1>
      <button onClick={() => setIsOpen(true)}>Open</button>
      <ReactModal isOpen={isOpen} ariaHideApp={false}>
        <button onClick={() => setIsOpen(false)}>Close</button>
      </ReactModal>
    </div>
  );
};
