import { createContext } from "react";
import { ICart, ICartProduct } from "../../interfaces/icart";

export interface ICartContextProps {
  cart?: ICart;
  setCart?: (cart?: ICart) => void;
  addProduct?: (product?: ICartProduct) => void;
}

export const CartContext = createContext<ICartContextProps>({
  cart: undefined,
  setCart: (cart?: ICart) => {},
  addProduct: (product?: ICartProduct) => {},
});
