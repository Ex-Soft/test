import { Modal } from "./components/ui/Modal";
import { triggerCustomEvent } from "./hooks/useEventListener/triggerCustomEvent/triggerCustomEvent";
import "./App.css";

function App() {
  const handleButtonClick = (action: "open" | "close") => {
    if (!action) return;
    console.log(action);
    triggerCustomEvent("modal-event", { action });
  };

  return (
    <div className="App">
      <button onClick={() => handleButtonClick("open")}>Open</button>
      <button onClick={() => handleButtonClick("close")}>Close</button>
      <Modal />
    </div>
  );
}

export default App;

// yarn create react-app test-custom-evenys --template typescript
// yarn add react-modal
// yarn add @types/react-modal --dev
