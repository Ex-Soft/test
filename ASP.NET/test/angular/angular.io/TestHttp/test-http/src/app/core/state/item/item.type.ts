export interface IItemDto {
  id: number;
  name: string;
  dateTime: string;
}

export interface IItem {
    id: number;
    name: string;
    dateTime: Date;
}

export const createItem = (params: Partial<IItemDto>) =>
  ({ ...params, dateTime: (!!params.dateTime ? new Date(params.dateTime) : new Date()) } as IItem);

export const createItems = (params: Array<Partial<IItemDto>>) =>
  params.map(item => createItem(item)) as IItem[];
