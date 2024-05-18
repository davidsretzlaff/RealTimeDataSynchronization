import { HubConnection, LogLevel } from "@microsoft/signalr";
import { HubConnectionBuilder } from "@microsoft/signalr/dist/esm/HubConnectionBuilder";
import { useState } from "react";
import { Button, Col, Form, Row } from "react-bootstrap";



function WaitingRoom(): React.ReactElement {
    const [userName, setUserName] = useState('');
    const [chatRoom, setChatRoom] = useState('');
    const [conn, setConnection] = useState<HubConnection | undefined>(undefined);
    const [message, setMessage] = useState('');
  
    const joinChatRoom = async (userName: string, chatRoom: string) => {
        try {
          const conn = new HubConnectionBuilder().withUrl('http://localhost:5092/chat').configureLogging(LogLevel.Information).build();
    
          conn.on('JoinSpecificChatRoom', (userName, message) => {
            console.log('msg', message);
          });
    
          conn.on('ReceiveSpecificMessage', (userName,msg) => {
            setMessage(message => msg)
          });
    
          await conn.start();
          await conn.invoke('JoinSpecificChatRoom', userName, chatRoom);
    
          setConnection(conn);
    
        } catch (error) { 
          console.error(error);
        }
      }
    return (
            <Form onSubmit={e => {
                e.preventDefault(); 
                joinChatRoom(userName, chatRoom);
            }}>
                <Row className="px-5 py-5">
                    <Form.Group>
                        <Col sm={12}> 
                            <Form.Control 
                                placeholder="username" 
                                onChange={e => setUserName(e.target.value)} />
                                
                            <Form.Control 
                                placeholder="chatRoom" 
                                onChange={e => setChatRoom(e.target.value)} />
                        </Col>
                        <Col sm={12}> 
                            <hr />
                            <Button variant='success' type='submit'>Join</Button>
                        </Col>
                    </Form.Group>
                </Row>

                <Row className="px-5 py-5">
                    <Form.Group>
                        <Col sm={12}> 
                           
                           <label> {message} </label>
                        </Col>
                    </Form.Group>
                </Row>
            </Form>
        );
}

export default WaitingRoom