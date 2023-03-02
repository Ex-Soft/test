import { Routes, Route } from 'react-router-dom';
import { lazy, Suspense } from 'react';
import { NavBar, Home, TestAxios, TestUseEffect, TestUseCallback, TestFromChildToParent, Products, ProductDetails } from './components';
import './App.css';

const NoMatch = lazy(() => import('./components/pages/NoMatch'));

const App = () => {
  return (
    <div className="App">
      <NavBar />
      <Suspense fallback={<div className="container">Loading...</div>}>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/testaxios" element={<TestAxios />} />
          <Route path="/testuseeffect" element={<TestUseEffect />} />
          <Route path="/testusecallback" element={<TestUseCallback />} />
          <Route path="/testfromchildtoparent" element={<TestFromChildToParent />} />
          <Route path="/products" element={<Products />} />
          <Route path="/products/:id" element={<ProductDetails />} />
          <Route path="*" element={<NoMatch />} />
        </Routes>
      </Suspense>
    </div>
  );
};

export default App;

// yarn create react-app any-test --template typescript
// yarn add react-router-dom
// https://hygraph.com/blog/routing-in-react
