import { IItem } from './IItem';
import { IOrder } from './IOrder';

export class Order implements IOrder {
    total: number;

    constructor(public id: number, public date: Date, public items: IItem[]) {
        this.total = items.reduce((accumulator, currentValue) => accumulator + currentValue.total, 0);
    }
}
