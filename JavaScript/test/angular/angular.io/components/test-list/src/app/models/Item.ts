import { IItem } from './IItem';

export class Item implements IItem {
    total: number;
    checked: boolean;

    constructor(public id: number, public name: string, public price: number, public count: number) {
        this.total = this.price * this.count;
    }
}
