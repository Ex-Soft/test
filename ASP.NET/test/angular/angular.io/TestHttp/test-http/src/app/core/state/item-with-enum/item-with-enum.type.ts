export enum TestEnum {
  Zero = 'Zero',
  First = 'First',
  Second = 'Second',
  Third = 'Third',
  Fourth = 'Fourth',
  Fifth = 'Fifth'
}

export interface IItemWithEnumDto {
    id: number;
    value: TestEnum;
}

export const createItemWithEnum = (params: Partial<IItemWithEnumDto>) => ({ ...params } as IItemWithEnumDto);

export const createItemsWithEnum = (params: Array<Partial<IItemWithEnumDto>>) =>
  params.map(item => createItemWithEnum(item)) as IItemWithEnumDto[];
