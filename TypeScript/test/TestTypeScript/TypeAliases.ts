export function TestTypeAliases() {
  // https://www.typescriptlang.org/docs/handbook/advanced-types.html
  // https://github.com/Microsoft/TypeScript/blob/master/doc/spec.md#3.10

  type CustomType = "1st" | "2nd" | "3rd" | "4th" | "5th";
  let ct: CustomType = "3rd";
  
  type P = keyof CustomType;
  type KeyOfUnion<T> = T extends T ? keyof T : never;
  type AvailableKeys = KeyOfUnion<CustomType>;

  type Second = number;

  let time: Second = 10;

  type Container<T> = { value: T };

  type Tree<T> = {
    value: T;
    left?: Tree<T>;
    right?: Tree<T>;
  };

  interface IAnimal {
    name: string;
  }

  type Animal = {
    name: string;
  };

  interface IBear extends Animal {
    honey: boolean;
  }

  type Bear = Animal & {
    honey: Boolean;
  };

  interface ICar {
    manufacturer: string;
    model: string;
    year: number;
  }

  let taxi: ICar = {
    manufacturer: "Toyota",
    model: "Camry",
    year: 2014,
  };

  let carProps: keyof ICar = "manufacturer";

  interface IPersonSubset {
    name?: string;
    age?: number;
  }

  interface IPersonReadonly {
    readonly name: string;
    readonly age: number;
  }

  type DeepPartial<T> = T extends object
    ? { [K in keyof T]?: DeepPartial<T[K]> }
    : T;

  let personalSubset = {} as DeepPartial<IPersonSubset>;

  let o2: IPersonSubset = { age: 99 } as IPersonSubset;
  let o1: IPersonSubset = { age: 33, ...o2 };
  console.log("%o", o1);
}
