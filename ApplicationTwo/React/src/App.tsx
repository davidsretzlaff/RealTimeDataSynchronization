import React, { useState } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Col, Container, Row } from 'react-bootstrap';

import MessageComponent from './components/MessageComponent';




function App() {
  return (
    <>
      <header className="App-header">
          <h3 className="text-center mb-4">Real Time Messages</h3>
      </header>
      <MessageComponent></MessageComponent>
    </> 
  );
}

export default App;
