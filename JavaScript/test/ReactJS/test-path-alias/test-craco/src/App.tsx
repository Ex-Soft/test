// https://plusreturn.com/blog/how-to-configure-a-path-alias-in-a-react-typescript-app-for-cleaner-imports/
// https://dev.to/brandonwie/absolute-paths-in-cra-setting-using-craco-feat-typescript-and-ts-jest-2301

import { isDate } from "@/utils";
import './App.css';

function App() {
  const victim = "blah-blah-blah";

  return (
    <div>
      <p>isDate(&quot;{victim}&quot;)={isDate(victim).toString()}</p>
    </div>
  );
}

export default App;

// yarn create react-app test-craco --template typescript
// yarn add @craco/craco
// yarn add --dev ts-jest
