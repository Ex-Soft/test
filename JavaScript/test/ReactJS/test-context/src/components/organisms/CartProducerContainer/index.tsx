import { Cart, CartProduct } from "../../../classes";
import { useCart } from "../../../contexts/cart";

const CartProducerContainer: React.FC = () => {
  const { addProduct } = useCart();

  return (
    <div className="cart-producer-container">
      <input
        type="button"
        value="Add product"
        onClick={() => {
          console.log("Add product");
          addProduct?.(new CartProduct("1", 1, 1));
        }}
      />
    </div>
  );
};

export default CartProducerContainer;
