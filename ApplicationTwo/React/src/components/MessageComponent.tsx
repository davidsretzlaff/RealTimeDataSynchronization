import React, { useState } from 'react';
import { Container, Form, Button, Row, Col, InputGroup } from 'react-bootstrap';
import './MessageComponent.css';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

const MessageComponent = () => {
    const [message, setMessage] =useState('');
    const [result, setResult] = useState('This is the message received from the one application');
    const [validated, setValidated] = useState(true);
    const [validatedCharacterCount, setValidatedCharacterCount] = useState(true);
    const signalrUrl = process.env.REACT_APP_SIGNALR_URL;

    const conn = new HubConnectionBuilder()
            .withUrl(signalrUrl!)
            .configureLogging(LogLevel.Information)
            .build();

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
      if (message.length <= 300) {
        setValidatedCharacterCount(true)
      } 
      if (message.length >= 0) {
        setValidated(true)
      }
      setMessage(e.target.value);
    };        
    const joinChatRoom = async () => {
        try {
          if (message === '') {
            setValidated(false)
            return;
          }
          if (message.length >= 300) {
            setValidatedCharacterCount(false)
            return;
          }
          
          await conn.start().catch(err => console.error(err));
          await conn.invoke('SendFromAppTwo', message); 
          console.log('SendFromAppTwo')         
          conn.on('ReceiveFromAppOne', (message) => {
            setResult(message)
            console.log('result',message)    
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
            <Form className="d-flex flex-column h-500">
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
                    onChange={handleChange}
                    className={`message-input ${!validated || !validatedCharacterCount ? 'is-invalid' : ''}`}
                  />
                   
                  <Button variant="secondary" onClick={(e) => joinChatRoom()} className="send-button">
                    Send
                  </Button>
                  { !validatedCharacterCount && (
                    <div className="invalid-feedback">
                      Your message must be 300 characters or less.
                    </div>
                  )}
                  { !validated && (
                    <div className="invalid-feedback">
                      The field must not be empty.
                    </div>
                  )}
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
