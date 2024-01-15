import ErrorBoundary from "./ErrorBoundary";
import ComponentWithError from "./ComponentWithError";
import UserOnlineStatus from "./UserOnlineStatus";
import "./index.css";

export type TestConditionalRenderingProps = {
  booleanValue?: boolean;
  numberValue?: number;
};

const TestConditionalRendering: React.FC<TestConditionalRenderingProps> = ({
  booleanValue = undefined,
  numberValue = undefined,
}) => {
  let content1;
  if (booleanValue)
    content1 = <p>{`1. If/Else Statements (booleanValue=${booleanValue})`}</p>;
  else
    content1 = <p>{`1. If/Else Statements (booleanValue=${booleanValue})`}</p>;

  let content4 = numberValue ?? "Not available";

  let content5;
  switch (booleanValue) {
    case false: {
      content5 = (
        <p>{`5. Switch Case Statements (booleanValue=${booleanValue})`}</p>
      );
      break;
    }
    case true: {
      content5 = (
        <p>{`5. Switch Case Statements (booleanValue=${booleanValue})`}</p>
      );
      break;
    }
  }

  const renderStatus = (isOnline: boolean | undefined | null) => {
    if (isOnline === null) {
      return <p>Checking status...</p>;
    }

    if (isOnline) {
      return <p>Welcome, user! You are online.</p>;
    } else {
      return <p>You are offline. Please check your connection.</p>;
    }
  };

  return (
    <>
      <div>
        <h1>Test ConditionalRendering</h1>
      </div>
      <div>
        {content1}
        {booleanValue ? (
          <p>{`2. Ternary Operator (?) (booleanValue=${booleanValue})`}</p>
        ) : (
          <p>{`2. Ternary Operator (?) (booleanValue=${booleanValue})`}</p>
        )}
        {booleanValue && (
          <p>{`3. Logical AND (&&) (booleanValue=${booleanValue})`}</p>
        )}
        {!booleanValue && (
          <p>{`3. Logical AND (&&) (booleanValue=${booleanValue})`}</p>
        )}
        <p>4. Nullish Coalescing Operator (??) (numberValue={content4})</p>
        {content5}
        <div>
          <h1>6. Error Boundaries</h1>
          <ErrorBoundary fallback={<h1>Something went wrong.</h1>}>
            <ComponentWithError />
          </ErrorBoundary>
        </div>
        <div>
          <h1>7. Higher-Order Components (HOCs)</h1>
          <p>
            Higher-order components are not commonly used in modern React code.
          </p>
        </div>
        <div>
          <h1>8. Render Props</h1>
          <UserOnlineStatus render={renderStatus} />
        </div>
      </div>
    </>
  );
};

export default TestConditionalRendering;
