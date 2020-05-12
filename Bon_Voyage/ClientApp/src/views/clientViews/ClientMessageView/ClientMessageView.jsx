import React from "react";
import classNames from "classnames";
import { Bar } from "react-chartjs-2";
import * as getListActions from "./reducer";
import { connect } from "react-redux";
import get from "lodash.get";


import {
    Button,
    Card,
    CardBody,
    CardFooter,
    CardGroup,
    Col,
    Container,
    Form,
    Input,
    InputGroup,
    InputGroupAddon,
    InputGroupText,
    Row,
    FormGroup,
    Label,
    FormText,
} from "reactstrap";

class ClientMessageView extends React.Component {
    state = {
        
    }


    render() {
        const { clientMessage } = this.props;
        console.log("render", clientMessage);
        const form = (
            <div className="app flex-row" style={{ position: 'absolute', left: '15%', top: '10%', }}>
                <div className="card text-center"></div>
                <Container>
                    <div className="content-align-center">
                        <Form>
                            <FormGroup>
                                <Label for="exampleSelect">Виберіть тематику</Label>
                                <Input type="select" name="select" id="exampleSelect">
                                    <option>Як замовити квиток</option>
                                    <option>Гарячі квитки</option>
                                    <option>Візова підтримка</option>
                                    <option>Не можу зайти в кабінет</option>
                                    <option>Білет анульовано</option>
                                </Input>
                            </FormGroup>
                            <FormGroup>
                                <Label for="exampleText">Текст повідомлення</Label>
                                <Input type="textarea" name="text" id="exampleText" />
                            </FormGroup>
                            <Button>Відправити</Button>
                        </Form>
                    </div>
                </Container>
            </div>
        );
        return form;
    }
}

const mapStateToProps = (state) => {
    return {
        listClients: get(state, "clientmessage.list.data"),
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(ClientMessageView);
