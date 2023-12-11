import React from 'react';
import ReactDOM from 'react-dom/client';
import './style.css';
import App from './App';
import "./i18n"
import StandardErrorBoundary from "./components/ErrorBoundary"

const root = ReactDOM.createRoot(document.getElementById('root'));
document.getElementsByTagName('html')[0].classList.add('sm:scroll-smooth');


root.render(
  <React.StrictMode>
    <StandardErrorBoundary>
      <App />
    </StandardErrorBoundary>
  </React.StrictMode>
);