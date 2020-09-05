// https://www.typescriptlang.org/docs/handbook/advanced-types.html
// https://github.com/Microsoft/TypeScript/blob/master/doc/spec.md#3.10

type Second = number;

let time: Second = 10;

type Container<T> = { value: T };

type Tree<T> = {
    value: T;
    left?: Tree<T>;
    right?: Tree<T>;
};

interface IAnimal {
    name: string
}

type Animal = {
    name: string
}

interface IBear extends Animal {
    honey: boolean
}

type Bear = Animal & {
    honey: Boolean
}
