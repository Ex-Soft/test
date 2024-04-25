import { useState, useCallback } from "react";
import { ICart, ICartProduct } from "../../interfaces/icart";
import { Cart } from "../../classes";
import { ICartContextProps } from "./context";

export const useCartContextController = (): ICartContextProps => {
  const [cart, setCart] = useState<ICart | undefined>();

  const addProduct = useCallback(
    (product?: ICartProduct) => {
      const _cart = Object.create(cart || new Cart());

      if (!Array.isArray(_cart.products)) _cart.products = [];

      if (product) _cart.products?.push(product);

      console.log("addProduct(): _cart.total = %i", _cart.total);

      setCart(_cart);
    },
    [cart, setCart]
  );

  return { cart, addProduct };
};
