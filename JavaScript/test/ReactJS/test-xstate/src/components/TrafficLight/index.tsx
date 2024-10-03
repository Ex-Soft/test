import {
  TrafficLight as TrafficLightSections,
  TrafficLightSectionStates,
  TrafficLightSectionColours,
} from "../../machines";
import "./index.css";

export type TrafficLightProps = {
  trafficLight: TrafficLightSections;
};

const getTrafficLightSectionColorClassName = (
  trafficLight: TrafficLightSections,
  sectionColor: TrafficLightSectionColours
): string =>
  `traffic-light-section-${
    (trafficLight as { [key: string]: any })[sectionColor] ===
      TrafficLightSectionStates.on ||
    (trafficLight as { [key: string]: any })[sectionColor] ===
      TrafficLightSectionStates.blinking
      ? sectionColor
      : "black"
  }`;

const TrafficLight: React.FC<TrafficLightProps> = ({ trafficLight }) => {
  return (
    <>
      <span
        className={`traffic-light-section ${getTrafficLightSectionColorClassName(
          trafficLight,
          TrafficLightSectionColours.red
        )}`}
      >
        &bull;
      </span>
      <span
        className={`traffic-light-section ${getTrafficLightSectionColorClassName(
          trafficLight,
          TrafficLightSectionColours.yellow
        )}`}
      >
        &bull;
      </span>
      <span
        className={`traffic-light-section ${getTrafficLightSectionColorClassName(
          trafficLight,
          TrafficLightSectionColours.green
        )}${
          trafficLight.green === TrafficLightSectionStates.blinking
            ? " traffic-light-section-blinking"
            : ""
        }`}
      >
        &bull;
      </span>
    </>
  );
};

export default TrafficLight;
