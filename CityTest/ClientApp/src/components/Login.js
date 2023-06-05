import React, { Component } from 'react';

export class Login extends Component {
    static displayName = Login.name;

    state = {
        custName: ''
    };

    handleInputClicked = event => {
        event.preventDefault();

 /*       helper.onTouchFieldScroll(event.target, 120);*/
    };

    render() {
        return (
            <div>
                <h1>Login</h1>
                <div style={{ alignContent: 'center' }}>
                    <label>Customer Name:</label>
                    <input type="text"
                        name="custName"
                        id="custName"
                        defaultValue={this.state.custName}
                        onClick={this.handleInputClicked}

                        e
                    ></input>
                    <br/>
                    <br />

                    <input type="button" value="Submit"/>
                </div>

            </div>
            
            );
    }
}