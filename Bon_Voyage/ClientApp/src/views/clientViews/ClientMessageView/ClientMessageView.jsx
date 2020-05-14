import React from "react";
import classNames from "classnames";
import { Bar } from "react-chartjs-2";
import * as reducer from './reducer';
import { connect } from "react-redux";
import get from "lodash.get";
import * as getListActions from "./reducer"


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
        Theme: "",
        Message:"",
        isSuccess: true
    }
    onSubmitForm = (e) => {
        e.preventDefault();
        const { Theme, Message } = this.state;

        const model = {
            Theme: Theme,
            Message: Message
        };
        this.props.sendmessage(model);
        refreshPage();
    }

    componentWillReceiveProps = (nextProps) => { 
        this.setState(
            {
                isSuccess: nextProps.addsuccess
            }
        )
    }

    handleChange = e => {
        this.setState({ [e.target.name]: e.target.value });
    };

    render() {
        const form = (
            <div className="app flex-row" style={{ position: 'center', left: '15%', top: '10%', }}>
                <div className="card text-center"></div>
                <Container>
                    <div className="content-align-center">
                        <Form onSubmit={this.onSubmitForm}>
                            <FormGroup>
                                <Label for="exampleSelect">Виберіть тематику</Label>
                                <Input type="select" name="Theme" id="exampleSelect" value={this.state.Theme} onChange={this.handleChange}>
                                    <option>Як замовити квиток</option>
                                    <option>Гарячі квитки</option>
                                    <option>Візова підтримка</option>
                                    <option>Білет анульовано</option>
                                    <option>Відміна покупки білету</option>
                                    <option>Інші запитання</option>
                                </Input>
                            </FormGroup>
                            <FormGroup>
                                <Label for="exampleText">Текст повідомлення</Label>
                                <Input type="textarea" name="Message" id="exampleText" value={this.state.Message} onChange={this.handleChange}/>
                            </FormGroup>
                            <Button label="success" className="p-button-success">Відправити</Button>
                        </Form>
                    </div>
                </Container>
            </div>
        );
        return form;
    }
}
function refreshPage() {
    window.location.reload(false);
  }

function mapStateToProps(state) {
    return {
        listClients: get(state, "clientmessage.list.data"),
        addsuccess: get(state, "clientMessage.list.success"),
    };
}

const mapDispatch = {
    sendmessage: (model) =>{
        return reducer.sendmessage(model);
    }
}

export default connect(mapStateToProps, mapDispatch)(ClientMessageView);