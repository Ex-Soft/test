import React, { useState } from 'react';
import logo from './logo.svg';
import './App.css';
import { Table, Button, Span } from './components';

function App() {
  const [data, setData] = useState([
    { id: 1, value: 'Value# 1' },
    { id: 2, value: 'Value# 2' }
  ]);

  return (
    <div className="App">
      <Table data={data} />
      <Button data={data} stateChanger={setData} />
      <div>
        <p>
          <Span text='Span# 1' /><Span text='Span# 1' /><Span text='Span# 2' />
        </p>
      </div>
    </div>
  );
}

export default App;

// yarn create react-app any-test --template typescript
