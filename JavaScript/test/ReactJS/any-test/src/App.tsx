import { Routes, Route } from 'react-router-dom';
import { lazy, Suspense } from 'react';
import { NavBar, Home, TestAxios, TestUseState, TestUseEffect, TestUseCallback, TestUseMemo, TestUseRef, TestUseContext, TestFromChildToParent, Products, ProductDetails, TestMUI, CustomDropdown, TestFormik, CustomControls, TestCustomDataFetchingHook, TestDebounce, TestConditionalRendering } from './components';
import { ImpersonatedUserContextProvider, useImpersonatedUser } from './contexts';
import './App.css';

const NoMatch = lazy(() => import('./components/pages/NoMatch'));

const App = () => {
  const { setState:setImpersonatedUser } = useImpersonatedUser();

  setImpersonatedUser("setImpersonatedUser()");

  return (
    <div className="App">
      <ImpersonatedUserContextProvider>
        <NavBar />
        <Suspense fallback={<div className="container">Loading...</div>}>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/testaxios" element={<TestAxios />} />
            <Route path="/testusestate" element={<TestUseState />} />
            <Route path="/testuseeffect" element={<TestUseEffect />} />
            <Route path="/testusecallback" element={<TestUseCallback />} />
            <Route path="/testusememo" element={<TestUseMemo />} />
            <Route path="/testuseref" element={<TestUseRef />} />
            <Route path="/testusecontext" element={<TestUseContext />} />
            <Route path="/testfromchildtoparent" element={<TestFromChildToParent />} />
            <Route path="/products" element={<Products />} />
            <Route path="/products/:id" element={<ProductDetails />} />
            <Route path="/testmui" element={<TestMUI />} />
            <Route path="/customdropdown" element={<CustomDropdown />} />
            <Route path="/testformik" element={<TestFormik />} />
            <Route path="/customcontrols" element={<CustomControls />} />
            <Route path="/testcustomdatafetchinghook" element={<TestCustomDataFetchingHook />} />
            <Route path="/testdebonce" element={<TestDebounce />} />
            <Route path="/testconditionalrendering" element={<TestConditionalRendering booleanValue={true} />} />
            <Route path="*" element={<NoMatch />} />
          </Routes>
        </Suspense>
      </ImpersonatedUserContextProvider>
    </div>
  );
};

export default App;

// yarn create react-app any-test --template typescript
// yarn add <package...> [--dev/-D]
// yarn add axios
// yarn add react-router-dom
// yarn install
// yarn install --check-files
// yarn upgrade
// yarn add @mui/material @emotion/react @emotion/styled
// yarn add formik
// yarn add @mui/lab @react-spring/web
// yarn remove @mui/lab
// yarn add @mui/x-tree-view
// yarn add react-modal
// yarn add lodash @types/lodash
// yarn add material-ui-dropzone
// yarm start
// https://hygraph.com/blog/routing-in-react
//
// yarn build
// yarn global add serve
// path %localappdata%\Yarn\bin
// serve -s build
