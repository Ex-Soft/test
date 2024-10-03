import { setup, assign } from "xstate";

export enum TrafficLightSectionColours {
  red = "red",
  yellow = "yellow",
  green = "green",
}

export enum TrafficLightStates {
  stop = "stop",
  warnBeforeGo = "warnBeforeGo",
  go = "go",
  warnDuringGo = "warnDuringGo",
  wait = "wait",
}

export enum TrafficLightEvents {
  TOGGLE = "TOGGLE",
}

export enum TrafficLightActions {
  setTrafficLightSections = "setTrafficLightSections",
  setCanGo = "setCanGo",
}

export enum TrafficLightGuards {
  isStateStop = "isStateStop",
  isStateWarnBeforeGo = "isStateWarnBeforeGo",
  isStateGo = "isStateGo",
  isStateWarnDuringGo = "isStateWarnDuringGo",
  isStateWait = "isStateWait",
}

export enum TrafficLightSectionStates {
  off = "off",
  on = "on",
  blinking = "blinking",
}

export interface TrafficLight {
  [TrafficLightSectionColours.red]: TrafficLightSectionStates;
  [TrafficLightSectionColours.yellow]: TrafficLightSectionStates;
  [TrafficLightSectionColours.green]: TrafficLightSectionStates;
}

export interface TrafficLightMachineContext {
  trafficLight: TrafficLight;
  canGo: boolean;
}

export type TrafficLightMachineEvents = { type: TrafficLightEvents.TOGGLE };

export type TrafficLightMachineStates =
  | { value: TrafficLightStates.stop; context: TrafficLightMachineContext }
  | {
      value: TrafficLightStates.warnBeforeGo;
      context: TrafficLightMachineContext;
    }
  | { value: TrafficLightStates.go; context: TrafficLightMachineContext }
  | {
      value: TrafficLightStates.warnDuringGo;
      context: TrafficLightMachineContext;
    }
  | { value: TrafficLightStates.wait; context: TrafficLightMachineContext };

export const trafficLightMachine = setup({
  types: {} as {
    context: TrafficLightMachineContext;
    events: TrafficLightMachineEvents;
  },
  actions: {
    [TrafficLightActions.setTrafficLightSections]: (
      actionArgs,
      params: { trafficLight: TrafficLight }
    ) => {
      actionArgs.context.trafficLight[TrafficLightSectionColours.red] =
        params.trafficLight[TrafficLightSectionColours.red];
      actionArgs.context.trafficLight[TrafficLightSectionColours.yellow] =
        params.trafficLight[TrafficLightSectionColours.yellow];
      actionArgs.context.trafficLight[TrafficLightSectionColours.green] =
        params.trafficLight[TrafficLightSectionColours.green];
    },
    [TrafficLightActions.setCanGo]: assign({
      canGo: ({ context }) => {
        console.log("%o", context);
        return (
          context.trafficLight[TrafficLightSectionColours.green] ===
          TrafficLightSectionStates.on
        );
      },
    }),
  },
  guards: {
    [TrafficLightGuards.isStateStop]: ({ context: { trafficLight } }) => {
      console.log(trafficLight);
      return (
        trafficLight[TrafficLightSectionColours.red] ===
          TrafficLightSectionStates.on &&
        trafficLight[TrafficLightSectionColours.yellow] ===
          TrafficLightSectionStates.off &&
        trafficLight[TrafficLightSectionColours.green] ===
          TrafficLightSectionStates.off
      );
    },
    [TrafficLightGuards.isStateWarnBeforeGo]: ({ context: { trafficLight } }) =>
      trafficLight[TrafficLightSectionColours.red] ===
        TrafficLightSectionStates.on &&
      trafficLight[TrafficLightSectionColours.yellow] ===
        TrafficLightSectionStates.on &&
      trafficLight[TrafficLightSectionColours.green] ===
        TrafficLightSectionStates.off,
    [TrafficLightGuards.isStateGo]: ({ context: { trafficLight } }) =>
      trafficLight[TrafficLightSectionColours.red] ===
        TrafficLightSectionStates.off &&
      trafficLight[TrafficLightSectionColours.yellow] ===
        TrafficLightSectionStates.off &&
      trafficLight[TrafficLightSectionColours.green] ===
        TrafficLightSectionStates.on,
    [TrafficLightGuards.isStateWarnDuringGo]: ({ context: { trafficLight } }) =>
      trafficLight[TrafficLightSectionColours.red] ===
        TrafficLightSectionStates.off &&
      trafficLight[TrafficLightSectionColours.yellow] ===
        TrafficLightSectionStates.off &&
      trafficLight[TrafficLightSectionColours.green] ===
        TrafficLightSectionStates.blinking,
    [TrafficLightGuards.isStateWait]: ({ context: { trafficLight } }) =>
      trafficLight[TrafficLightSectionColours.red] ===
        TrafficLightSectionStates.off &&
      trafficLight[TrafficLightSectionColours.yellow] ===
        TrafficLightSectionStates.on &&
      trafficLight[TrafficLightSectionColours.green] ===
        TrafficLightSectionStates.off,
  },
}).createMachine({
  id: "trafficLightMachine",
  context: {
    trafficLight: {
      [TrafficLightSectionColours.red]: TrafficLightSectionStates.on,
      [TrafficLightSectionColours.yellow]: TrafficLightSectionStates.off,
      [TrafficLightSectionColours.green]: TrafficLightSectionStates.off,
    },
    canGo: false,
  },
  initial: TrafficLightStates.stop,
  states: {
    [TrafficLightStates.stop]: {
      entry: (actionArgs, actionParams) => {
        console.log(
          "trafficLightMachine.%s.entry(%o, %o)",
          TrafficLightStates.stop,
          actionArgs,
          actionParams
        );
      },
      exit: (actionArgs, actionParams) => {
        console.log(
          "trafficLightMachine.%s.exit(%o, %o)",
          TrafficLightStates.stop,
          actionArgs,
          actionParams
        );
      },
      on: {
        [TrafficLightEvents.TOGGLE]: {
          actions: [
            {
              type: TrafficLightActions.setTrafficLightSections,
              params: {
                trafficLight: {
                  [TrafficLightSectionColours.red]:
                    TrafficLightSectionStates.on,
                  [TrafficLightSectionColours.yellow]:
                    TrafficLightSectionStates.on,
                  [TrafficLightSectionColours.green]:
                    TrafficLightSectionStates.off,
                } as TrafficLight,
              },
            },
            { type: TrafficLightActions.setCanGo },
          ],
          target: TrafficLightStates.warnBeforeGo,
          guard: { type: TrafficLightGuards.isStateStop },
        },
      },
    },
    [TrafficLightStates.warnBeforeGo]: {
      entry: (actionArgs, actionParams) => {
        console.log(
          "trafficLightMachine.%s.entry(%o, %o)",
          TrafficLightStates.warnBeforeGo,
          actionArgs,
          actionParams
        );
      },
      exit: (actionArgs, actionParams) => {
        console.log(
          "trafficLightMachine.%s.exit(%o, %o)",
          TrafficLightStates.warnBeforeGo,
          actionArgs,
          actionParams
        );
      },
      on: {
        [TrafficLightEvents.TOGGLE]: {
          actions: [
            {
              type: TrafficLightActions.setTrafficLightSections,
              params: {
                trafficLight: {
                  [TrafficLightSectionColours.red]:
                    TrafficLightSectionStates.off,
                  [TrafficLightSectionColours.yellow]:
                    TrafficLightSectionStates.off,
                  [TrafficLightSectionColours.green]:
                    TrafficLightSectionStates.on,
                } as TrafficLight,
              },
            },
            { type: TrafficLightActions.setCanGo },
          ],
          target: TrafficLightStates.go,
          guard: { type: TrafficLightGuards.isStateWarnBeforeGo },
        },
      },
    },
    [TrafficLightStates.go]: {
      entry: (actionArgs, actionParams) => {
        console.log(
          "trafficLightMachine.%s.entry(%o, %o)",
          TrafficLightStates.go,
          actionArgs,
          actionParams
        );
      },
      exit: (actionArgs, actionParams) => {
        console.log(
          "trafficLightMachine.%s.exit(%o, %o)",
          TrafficLightStates.go,
          actionArgs,
          actionParams
        );
      },
      on: {
        [TrafficLightEvents.TOGGLE]: {
          actions: [
            {
              type: TrafficLightActions.setTrafficLightSections,
              params: {
                trafficLight: {
                  [TrafficLightSectionColours.red]:
                    TrafficLightSectionStates.off,
                  [TrafficLightSectionColours.yellow]:
                    TrafficLightSectionStates.off,
                  [TrafficLightSectionColours.green]:
                    TrafficLightSectionStates.blinking,
                } as TrafficLight,
              },
            },
            { type: TrafficLightActions.setCanGo },
          ],
          target: TrafficLightStates.warnDuringGo,
          guard: { type: TrafficLightGuards.isStateGo },
        },
      },
    },
    [TrafficLightStates.warnDuringGo]: {
      entry: (actionArgs, actionParams) => {
        console.log(
          "trafficLightMachine.%s.entry(%o, %o)",
          TrafficLightStates.warnDuringGo,
          actionArgs,
          actionParams
        );
      },
      exit: (actionArgs, actionParams) => {
        console.log(
          "trafficLightMachine.%s.exit(%o, %o)",
          TrafficLightStates.warnDuringGo,
          actionArgs,
          actionParams
        );
      },
      on: {
        [TrafficLightEvents.TOGGLE]: {
          actions: [
            {
              type: TrafficLightActions.setTrafficLightSections,
              params: {
                trafficLight: {
                  [TrafficLightSectionColours.red]:
                    TrafficLightSectionStates.off,
                  [TrafficLightSectionColours.yellow]:
                    TrafficLightSectionStates.on,
                  [TrafficLightSectionColours.green]:
                    TrafficLightSectionStates.off,
                } as TrafficLight,
              },
            },
            { type: TrafficLightActions.setCanGo },
          ],
          target: TrafficLightStates.wait,
          guard: { type: TrafficLightGuards.isStateWarnDuringGo },
        },
      },
    },
    [TrafficLightStates.wait]: {
      entry: (actionArgs, actionParams) => {
        console.log(
          "trafficLightMachine.%s.entry(%o, %o)",
          TrafficLightStates.wait,
          actionArgs,
          actionParams
        );
      },
      exit: (actionArgs, actionParams) => {
        console.log(
          "trafficLightMachine.%s.exit(%o, %o)",
          TrafficLightStates.wait,
          actionArgs,
          actionParams
        );
      },
      on: {
        [TrafficLightEvents.TOGGLE]: {
          actions: [
            {
              type: TrafficLightActions.setTrafficLightSections,
              params: {
                trafficLight: {
                  [TrafficLightSectionColours.red]:
                    TrafficLightSectionStates.on,
                  [TrafficLightSectionColours.yellow]:
                    TrafficLightSectionStates.off,
                  [TrafficLightSectionColours.green]:
                    TrafficLightSectionStates.off,
                } as TrafficLight,
              },
            },
            { type: TrafficLightActions.setCanGo },
          ],
          target: TrafficLightStates.stop,
          guard: { type: TrafficLightGuards.isStateWait },
        },
      },
    },
  },
});
