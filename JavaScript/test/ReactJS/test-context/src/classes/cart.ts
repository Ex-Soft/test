import { ICartProduct, ICart } from "../interfaces/icart";

export class CartProduct implements ICartProduct {
  constructor(
    public name?: string,
    public price?: number,
    public quantity?: number
  ) {
    console.log("CartProduct.ctor()");
  }
}

export class Cart implements ICart {
  constructor(public products?: ICartProduct[]) {
    console.log("Cart.ctor()");
  }

  get total(): number {
    console.log("Cart.total()");
    return Array.isArray(this.products)
      ? this.products?.reduce((acc, item) => {
          return acc + (item.price || 0) * 2 * ((item.quantity || 0) * 2);
        }, 0)
      : 0;
  }
}
