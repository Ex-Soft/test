import React from 'react';
import { render, screen } from '@testing-library/react';
import App from './App';

test('renders isDate result', () => {
  render(<App />);
  const pElement = screen.getByText(/isDate\(".+?"\)=(true|false)/i);
  expect(pElement).toBeInTheDocument();
});
