import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { createStore } from 'redux';
import rootReducer from './reducers';
import App from './App';
import * as serviceWorker from './serviceWorker';
import { VisibilityFilters, setNextTodoId } from './actions';

const initState = {
  todos: [
    {id: 0, text: '111', completed: false},
    {id: 1, text: '222', completed: true},
    {id: 2, text: '333', completed: false}
  ],
  visibilityFilter: VisibilityFilters.SHOW_COMPLETED
};

const store = createStore(rootReducer, initState)

setNextTodoId(initState.todos.length + 1);

ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <App />
    </Provider>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
