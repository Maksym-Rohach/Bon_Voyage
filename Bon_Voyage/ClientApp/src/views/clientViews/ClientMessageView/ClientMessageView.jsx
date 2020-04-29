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
    state = {};

    render() {
        const { clientMessage } = this.props;
        console.log("render", clientMessage);
        const form = (
            <div className="app flex-row">
                <Container>
                    <Form>
                        <FormGroup>
                            <Label for="exampleEmail">Введіть Email</Label>
                            <Input type="email" name="email" id="exampleEmail" placeholder="введіть пошту  на яку потрібно відповісти." />
                        </FormGroup>

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
                        <FormGroup>
                            <Label for="exampleFile">Загрузіть файл (якщо потрібно)</Label>
                            <Input type="file" name="file" id="exampleFile" />
                            <FormText color="muted">
                                This is some placeholder block-level help text for the above input.
                        It's a bit lighter and easily wraps to a new line.</FormText>
                        </FormGroup>
                        <FormGroup check>
                            <Label check>
                                <Input type="checkbox" />{' '}
                                Check me out</Label>
                        </FormGroup>
                        <Button>Submit</Button>
                    </Form>
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
