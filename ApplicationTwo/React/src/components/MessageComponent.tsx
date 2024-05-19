import React, { useState } from 'react';
import { Container, Form, Button, Row, Col, InputGroup } from 'react-bootstrap';
import './MessageComponent.css';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

const MessageComponent = () => {
    const [message, setMessage] =useState('');
    const [result, setResult] = useState('This is the message received from the one application');
    const [validated, setValidated] = useState(false);

    const conn = new HubConnectionBuilder()
            .withUrl('https://localhost:32768/synchub')
            .configureLogging(LogLevel.Information)
            .build();

    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
      const form = event.currentTarget;
      if (form.checkValidity() === false) {
        event.preventDefault();
        event.stopPropagation();
      }
  
      setValidated(true);
    };        
    const joinChatRoom = async () => {
        try {
          if(message === '') {
            return;
          }
          await conn.start().catch(err => console.error(err));
          await conn.invoke('SendFromAppTwo', message);          
          conn.on('ReceiveFromAppOne', (message) => {
            setResult(message)
          });
          setValidated(true)
          setMessage('')
        } catch (error) { 
          console.error(error);
        }
      }
  return (
    <Container fluid className="message-container">
      <Row className="vh-90 justify-content-center align-items-start">
        <Col md={10} lg={8} xl={6} className='margin-top'>
          <div className="message-box p-4 shadow-sm rounded">
            <h3 className="text-center mb-4">Real Time Messages</h3>
            <Form noValidate validated={validated} onSubmit={handleSubmit} className="d-flex flex-column h-500">
              <Form.Group controlId="formReceivedMessage" className="flex-grow-1 mb-4 ">
                <Form.Control
                  as="textarea"
                  readOnly
                  value={result}
                  className="received-message flex-grow-1 message"
                />
              </Form.Group>
              <Form.Group controlId="formMessage">
                <InputGroup>
                  <Form.Control
                    type="text"
                    placeholder="Type your message"
                    value={message}
                    required
                    onChange={(e) => setMessage(e.target.value)}
                    className="message-input"
                  />
                  <Button variant="secondary" type="submit" onClick={(e) => joinChatRoom()} className="send-button">
                    Send
                  </Button>
                </InputGroup>
              </Form.Group>
            </Form>
          </div>
        </Col>
      </Row>
    </Container>
  );
};

export default MessageComponent;
