import { IProduct } from "./iproduct";

export interface ICartProduct extends IProduct {
    quantity?: number;
}

export interface ICart {
    products?: ICartProduct[];
    total?: number;
}