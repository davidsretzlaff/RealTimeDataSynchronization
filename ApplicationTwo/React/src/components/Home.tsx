import { HubConnection, LogLevel } from "@microsoft/signalr";
import { HubConnectionBuilder } from "@microsoft/signalr/dist/esm/HubConnectionBuilder";
import { useState } from "react";
import { Button, Col, Form, Row } from "react-bootstrap";



function Home(): React.ReactElement {
    const [userName, setUserName] = useState('');
    const [chatRoom, setChatRoom] = useState('');
    const [conn, setConnection] = useState<HubConnection | undefined>(undefined);
    const [message, setMessage] = useState('');
    const [result, setResult] = useState('');
    const joinChatRoom = async (user: string, chatRoom: string) => {
        try {
            // const conn = new HubConnectionBuilder().withUrl('https://localhost:32768/chat').configureLogging(LogLevel.Information).build();
    
          const conn = new HubConnectionBuilder()
            .withUrl('http://localhost:5092/synchub')
            .configureLogging(LogLevel.Information)
            .build();
    
          await conn.start().catch(err => console.error(err));
          await conn.invoke('SendFromApp2', message);

          conn.on('ReceiveFromApp1', (message) => {
            console.log('ReceiveFromApp1',message)
            setResult(message)
          });
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
                                placeholder="message" 
                                onChange={e =>  setMessage(e.target.value)} />
                        </Col>
                        <Col sm={12}> 
                            <hr />
                            <Button variant='success' type='submit'>Send</Button>
                        </Col>
                    </Form.Group>
                </Row>

                <Row className="px-5 py-5">
                    <Form.Group>
                        <Col sm={12}> 
                        <h3 className='font-weight-light'>Output</h3>
                        </Col>
                        <Col sm={12}>                             
                            <label> {result} </label>
                        </Col>
                    </Form.Group>
                </Row>
            </Form>
        );
}

export default Home