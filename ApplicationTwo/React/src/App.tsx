import React, { useState } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Col, Container, Row } from 'react-bootstrap';
import Home from './components/Home';




function App() {
  return (
    <div >
      <main>
        <Container>
          <Row class='px-5 my-5'>
            <Col sm={12}> 
              <h1 className='font-weight-light'>Welcome to the Test</h1>
            </Col>
          </Row>
          <Home></Home>
          </Container>      
      </main>
    </div>
  );
}

export default App;
