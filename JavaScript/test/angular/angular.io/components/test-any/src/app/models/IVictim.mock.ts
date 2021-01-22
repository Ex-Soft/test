import faker from 'faker';

import { IVictim, IVictimSubGroup } from './IVictim';

type DeepPartial<T> = T extends object ? { [K in keyof T]?: DeepPartial<T[K]> } : T;

export function createVictimSubGroup(controlledValues: DeepPartial<IVictimSubGroup> = {}): IVictimSubGroup {
    return {
        id: faker.random.number(),
        p1: faker.random.alpha(),
        p2: faker.random.alpha(),
        p3: faker.random.alpha(),
        ...controlledValues,
    };
}

export function createVictim(
    controlledValues: DeepPartial<IVictim> = {}
): IVictim {
    const {
        subGroup1: subGroup1Config,
        subGroup2: subGroup2Config,
        subGroup3: subGroup3Config,
        ...rest
    } = controlledValues;

    const result = {
        id: faker.random.number(),
        p1: faker.random.alpha(),
        p2: faker.random.alpha(),
        p3: faker.random.alpha(),
        p4: faker.random.alpha(),
        p5: faker.random.alpha(),
        ...controlledValues,
    } as IVictim;

    result.subGroup1 = createVictimSubGroup(subGroup1Config);
    result.subGroup2 = createVictimSubGroup(subGroup2Config);
    result.subGroup3 = createVictimSubGroup(subGroup3Config);

    return result;
}
