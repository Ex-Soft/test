import CartProducerContainer from "../CartProducerContainer";
import CartConsumerContainer from "../CartConsumerContainer";
import "./index.css";

const CartContainer: React.FC = () => {
  return (
    <div className="cart-container">
      <CartProducerContainer />
      <CartConsumerContainer />
    </div>
  );
};

export default CartContainer;
