import { setup, assign } from "xstate";

export interface TestMachineContext {
  count: number;
}

export type TestMachineEvents =
  | { type: "inc"; value?: number }
  | { type: "dec"; value?: number };

export type TestMachineStates = {
  value: "chooseInitial";
  context: TestMachineContext;
};

export const testMachine = setup({
  types: {} as {
    context: TestMachineContext;
    events: TestMachineEvents;
  },
  actions: {
    increment: assign({
      count: ({ event, context }) => context.count + (event.value || 1),
    }),
    decrement: assign({
      count: ({ event, context }) => context.count - (event.value || 1),
    }),
  },
}).createMachine({
  id: "testMachine",
  initial: "chooseInitial",
  context: { count: 0 },
  on: {
    inc: { actions: "increment" },
    dec: { actions: "decrement" },
  },
  states: {
    chooseInitial: {
      entry: (actionArgs, actionParams) => {
        console.log(
          "testMachine.chooseInitial.entry(%o, %o)",
          actionArgs,
          actionParams
        );
      },
      exit: (actionArgs, actionParams) => {
        console.log(
          "testMachine.chooseInitial.exit(%o, %o)",
          actionArgs,
          actionParams
        );
      },
    },
  },
});
