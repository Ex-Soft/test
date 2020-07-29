import { IItem } from './IItem';

export interface IOrder {
    id: number;
    date: Date;
    total: number;
    items: IItem[];
}
