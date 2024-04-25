import { useEffect, useState } from "react";
import { useCart } from "../../../contexts/cart";

const CartConcumerContainer: React.FC = () => {
  const { cart } = useCart();
  const [count, setCount] = useState<number | null | undefined>(0);
  const [total, setTotal] = useState<number | null | undefined>(0);

  useEffect(() => {
    setCount(cart?.products?.length);
    setTotal(cart?.total);
  }, [cart]);

  return (
    <div className="cart-consumer-container">
      <div className="cart-label">Count</div>
      <div className="cart-value">{count}</div>
      <div className="cart-label">Total</div>
      <div className="cart-value">{total}</div>
    </div>
  );
};

export default CartConcumerContainer;
