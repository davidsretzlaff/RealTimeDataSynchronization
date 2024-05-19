import React, { useState } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Col, Container, Row } from 'react-bootstrap';
import Home from './components/Home';
import MessageComponent from './components/MessageComponent';




function App() {
  return (
    <>
    <header className="App-header">
        <h3 className="text-center mb-4">Application Two</h3>
    </header>

    <MessageComponent></MessageComponent>
    </> 
    // <div >
    //   <main>
    //     {/* <Container>
    //       <Row class='px-5 my-5'>
    //         <Col sm={12}> 
    //           <h1 className='font-weight-light'>Welcome to the Test</h1>
    //         </Col>
    //       </Row> */}
        
    //       {/* </Container>       */}
    //   </main>
    // </div>
  );
}

export default App;
