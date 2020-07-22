import React, { Component } from 'react';

export class TestMail extends Component {

    constructor(props) {
        super(props);
        this.sendEmail = this.sendEmail.bind(this);
    }

    sendEmail() {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' }
        };
        fetch('testmail', requestOptions)
            .then(response => response.json())
    }

    render() {
        return (
            <div>
                <button className="btn btn-primary" onClick={this.sendEmail}>Send Email</button>
            </div>
        );
    }
}
