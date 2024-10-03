import { setup, assign } from "xstate";

export interface SimpleMachineContext {
  count: number;
  maxCount: number;
}

export type SimpleMachineEvents = { type: "TOGGLE" };

export type SimpleMachineStates =
  | { value: "inactie"; context: SimpleMachineContext }
  | { value: "actie"; context: SimpleMachineContext };

export const simpleMachine = setup({
  types: {} as {
    context: SimpleMachineContext;
    events: SimpleMachineEvents;
  },
}).createMachine({
  id: "simpleMachine",
  initial: "inactive",
  context: { count: 0, maxCount: 10 },
  states: {
    inactive: {
      entry: assign({
        count: ({ context }) => context.count + 1,
      }),
      on: {
        TOGGLE: {
          target: "active",
          guard: ({ context }) => context.count < 10,
        },
      },
    },
    active: {
      on: { TOGGLE: "inactive" },
    },
  },
});
