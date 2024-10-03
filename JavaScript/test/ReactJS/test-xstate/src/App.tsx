import { useMachine } from "@xstate/react";
import {
  simpleMachine,
  trafficLightMachine,
  TrafficLightEvents,
  temperatureMachine,
  testMachine,
  FlightContext,
} from "./machines";
import {
  Header,
  TripSelector,
  DateSelector,
  BookButton,
  TrafficLight,
} from "./components";
import { TODAY } from "./utils";
import "./App.css";

function App() {
  const [simpleMachineState, simpleMachineSend] = useMachine(simpleMachine);
  const [trafficLightMachineState, trafficLightMachineSend] =
    useMachine(trafficLightMachine);
  const [temperatureMachineState, temperatureMachineSend] =
    useMachine(temperatureMachine);
  const [testMachineState, testMachineSend] = useMachine(testMachine);

  const { send } = FlightContext.useActorRef();
  const state = FlightContext.useSelector((state) => state);
  const { departDate, returnDate } = state.context;
  const isRoundTrip = state.matches({ scheduling: "roundTrip" });
  const isBooking = state.matches("booking");
  const isBooked = state.matches("booked");
  const isValidDepartDate = departDate >= TODAY;
  const isValidReturnDate = returnDate >= departDate;

  return (
    <div>
      <div>
        <span className="machineTitle">Simple Machine</span>
        <input
          type="button"
          value={`${
            simpleMachineState.value === "inactive"
              ? "Click to activate"
              : "Active! Click to deactivate"
          } (${simpleMachineState.value})`}
          onClick={() => {
            simpleMachineSend({ type: "TOGGLE" });
            console.log(simpleMachineState);
          }}
        />
      </div>
      <hr />
      <div>
        <span className="machineTitle">Traffic Light Machine</span>
        <TrafficLight
          trafficLight={trafficLightMachineState.context.trafficLight}
        />
        <span className="machineTitle">
          State: {trafficLightMachineState.value as string}
        </span>
        <input
          type="button"
          value="TOGGLE"
          onClick={() => {
            trafficLightMachineSend({ type: TrafficLightEvents.TOGGLE });
            console.log(trafficLightMachineState);
          }}
        />
      </div>
      <hr />
      <div>
        <span className="machineTitle">{`Temperature Machine ({ tempC: ${temperatureMachineState.context.tempC}, tempF: ${temperatureMachineState.context.tempF} })`}</span>
        <input
          type="button"
          value="CELSIUS"
          onClick={() => {
            temperatureMachineSend({ type: "CELSIUS", value: "36.6" });
            console.log(temperatureMachineState);
          }}
        />
        <input
          type="button"
          value="FAHRENHEIT"
          onClick={() => {
            temperatureMachineSend({ type: "FAHRENHEIT", value: "36.6" });
            console.log(temperatureMachineState);
          }}
        />
        <input
          type="button"
          value="State"
          onClick={() => {
            console.log(temperatureMachineState);
          }}
        />
      </div>
      <hr />
      <div>
        <span className="machineTitle">{`Test Machine ({ count: ${testMachineState.context.count} })`}</span>
        <input
          type="button"
          value="inc"
          onClick={() => {
            testMachineSend({ type: "inc", value: 2 });
            console.log(testMachineState);
          }}
        />
        <input
          type="button"
          value="dec"
          onClick={() => {
            testMachineSend({ type: "dec" });
            console.log(testMachineState);
          }}
        />
        <input
          type="button"
          value="State"
          onClick={() => {
            console.log(testMachineState);
          }}
        />
      </div>
      <hr />
      <div>
        <Header>Book Flight</Header>
        <TripSelector
          id="Trip Type"
          isBooking={isBooking}
          isBooked={isBooked}
          tripType={isRoundTrip ? "roundTrip" : "oneWay"}
        />
        <DateSelector
          id="Depart Date"
          value={departDate}
          isValidDate={isValidDepartDate}
          disabled={isBooking || isBooked}
          onChange={(e: React.ChangeEvent<HTMLInputElement>) =>
            send({
              type: "CHANGE_DEPART_DATE",
              value: e.currentTarget.value,
            })
          }
        />
        <DateSelector
          id="Return Date"
          value={returnDate}
          isValidDate={isValidReturnDate}
          disabled={!isRoundTrip}
          onChange={(e: React.ChangeEvent<HTMLInputElement>) =>
            send({
              type: "CHANGE_RETURN_DATE",
              value: e.currentTarget.value,
            })
          }
        />
        <BookButton
          eventType={isRoundTrip ? "BOOK_RETURN" : "BOOK_DEPART"}
          isBooking={isBooking}
          isBooked={isBooked}
        />
      </div>
      <hr />
    </div>
  );
}

export default App;
