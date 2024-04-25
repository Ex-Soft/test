import { useContext } from "react";
import { CartContext, ICartContextProps } from "./context";
import { useCartContextController } from "./controller";

const CartContextProvider: React.FC<{ children: any }> = ({ children }) => {
  return (
    <CartContext.Provider value={{ ...useCartContextController() }}>
      {children}
    </CartContext.Provider>
  );
};

function useCart(): ICartContextProps {
  const context = useContext(CartContext);

  if (!context) {
    throw new Error("useCart must be used within a CartContextProvider.");
  }

  return context;
}

export { CartContextProvider, useCart };
